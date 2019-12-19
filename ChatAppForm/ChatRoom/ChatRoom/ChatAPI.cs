using StackExchange.Redis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChatRoom
{
    public class ChatAPI
    {
        private string redisConnectionString;
        private static ConnectionMultiplexer connection = null;
        private static object objLock = new object();
        private string chatChannel;
        private string userName;
        private ChatForm chatForm;
        private ISubscriber pubsub;
        private string nameListUserName;
        private List<string> listMutedUserName;

        public ChatAPI()
        {
            listMutedUserName = new List<string>();
            nameListUserName = "usersList";
            //eksperimentalno sa Singleton
            this.redisConnectionString = "localhost";
            if (connection == null)
            {
                lock (objLock)
                {
                    if (connection == null)
                        connection = ConnectionMultiplexer.Connect(redisConnectionString);
                }
            }
            this.chatChannel = "ChatChannel";
            this.pubsub = connection.GetSubscriber();
            //this.chatForm = chatForm;
            //chatForm.BindChatAPI(this);
            //addUserNameInList();
            pubsub.Subscribe(chatChannel, (channel, message) => MessageAction(message));
            
        }

        public List<string> ListMutedUserName
        {
            get
            {
                return this.listMutedUserName;
            }
            set
            {
                this.listMutedUserName = value;
            }
        }
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        public ChatForm ChatFormWindow
        {
            get { return this.chatForm; }
            set
            {
                this.chatForm = value;
            }
        }

        public void SendMessage(Message message)    
        {
            string msg = JsonConvert.SerializeObject(message);
            pubsub.Publish(chatChannel, msg);
        }

        public void MessageAction(string message)
        {
            Message msg = Newtonsoft.Json.JsonConvert.DeserializeObject<Message>(message);
           // ChatRoom.Message msg = new ChatRoom.Message("joca", new ChatRoom.Color(255, 255, 0, 0), "aaaaaaaa", "");
            //ako neko mutira nekog onda njemu ne treba da stizu poruke od tog kog je mutirao
            if(!ExistsInTheList(listMutedUserName, msg.UserName))             //ako je korisnik koji je mutiran poslao poruku, ne trebamo je prikazati
                chatForm.DisplayMessage(msg);
            if (msg.Type.Equals("disconected"))
            {
                ListMutedUserName.Remove(msg.UserName);
            }
        }

        public void addInMutedList(string userName)                       //mutira korisnika, dodaje u listu mutiranih i proverava da li je taj korisnik uopste dostupan
        {
            IDatabase baza = connection.GetDatabase();
            if (ExistsInTheList(baza.ListRange(nameListUserName), userName)){
                listMutedUserName.Add(userName);
                chatForm.DisplayMessage(new Message("", new Color(255,0,0,0), "Uspesno ste mutirali korisnika "+userName, ""));
            }
            else
                chatForm.DisplayMessage(new Message("", new Color(255, 0, 0, 0), "Korisnik sa zadatim imenom ne postoji",""));
        }

        public void DeleteFromListMuted(string userName)            //ukoliko zelimo da odmutiramo korisnika
        {
            listMutedUserName.Remove(userName);
        }

        public bool addUserNameInList(string name)     // prilikom "logovanja" poziva se da bi rigistrovala korisnika, proverava da li je korisnik sa zadatim imenom vec dostupan
        {
            IDatabase baza = connection.GetDatabase();
           
            while (ExistsInTheList(baza.ListRange(nameListUserName), name))
            {
                return false;
            }
            baza.ListRightPush(nameListUserName, name);

            this.userName = name;
            chatForm.DisplayMessage(new Message(UserName, new Color(255, 0, 0, 0), "Korisnik " + "'" + UserName + "'" + " se pridruzio grupi",""));           
            return true;
        }
        public bool ExistsInTheList(RedisValue[] lista, string name)   
        {
            
            foreach(var el in lista)
            {
                if (el.ToString().Equals(name))
                    return true;
            }
            return false;
        }

        public bool ExistsInTheList(List<string> lista, string name)
        {
            foreach (string el in lista)
            {
                if (el.ToString().Equals(name))
                    return true;
            }
            return false;
        }


        public void Disconected()                                 //poziva se prilikom napustanja cet sobe, salje poruku tipa disconected da bi se kod ostalih korisnika izbacio iz liste mutiranih, 
        {                                                          //ukoliko je kod nekog korisnika mutiran. Takodje brise svoje korisnicko ime iz liste ulogovanih korisnika
            this.SendMessage(new Message(userName, new Color(255, 0, 0, 0), "", "disconected"));
            IDatabase baza = connection.GetDatabase();
            baza.ListRemove(nameListUserName, userName);
         
        }
        

    }
}