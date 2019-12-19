using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ChatRoom;



namespace ChatAppForm
{

    public partial class Form1 : Form, ChatRoom.ChatForm
    {
        ChatAPI chatCore;
        public Form1()
        {
            InitializeComponent();
        }

        public void BindChatAPI(ChatAPI chatAPI)
        {
            chatCore = chatAPI;
        }

        public void DisplayMessage(ChatRoom.Message message)
        {
            //MessageBox.Show(message.MessageValue);
            this.listBoxMsg.Items.Add(message.MessageValue);
        }

        public void SendMessage(ChatRoom.Message message)
        {
            chatCore.SendMessage(message);
        }

        private void messageBox_MouseClick(object sender, MouseEventArgs e)
        {
            if(messageBox.Text == "Unesite poruku ovde...")
            {
                messageBox.Text = "";
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            ChatRoom.Message theMessage = new ChatRoom.Message(chatCore.UserName, new ChatRoom.Color(255, 255, 0, 0), messageBox.Text, "");
            chatCore.SendMessage(theMessage);
            //chatBox.addChatMessage(theMessage, 0);
            messageBox.Text = "Unesite poruku ovde...";
        }

        private void listBoxMsg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
