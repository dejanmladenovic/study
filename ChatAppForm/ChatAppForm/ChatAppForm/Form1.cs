﻿using System;
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
using System.Threading;
namespace ChatAppForm
{
    delegate void SetTextCallback(ChatRoom.Message message);

    public partial class Form1 : Form, ChatRoom.ChatForm
    {
        ChatAPI chatCore;
        ChatRoom.Message msg;
        public Form1()
        {
            InitializeComponent();
        }

        public void BindChatAPI(ChatAPI chatAPI)
        {
            chatCore = chatAPI;
        }

        private void SetText(ChatRoom.Message msg)
        {
            //this.listBoxMsg.Items.Add(text);
            ChatRoom.Message m = new ChatRoom.Message(msg.UserName, msg.MessageColor, msg.MessageValue, "");
            if (chatCore.UserName.Equals(msg.UserName))
                chatBox.addChatMessage(m, 0);
            else
                chatBox.addChatMessage(m, 1);
        }

        public void DisplayMessage(ChatRoom.Message message)
        {
            //MessageBox.Show(message.MessageValue);
            this.msg = message;
            Thread th = new Thread(new ThreadStart(this.ThreadProcSafe));
            th.Start();
       
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
            ChatRoom.Message theMessage = new ChatRoom.Message(chatCore.UserName, new ChatRoom.Color(255, 0, 0, 0), messageBox.Text, "");
            chatCore.SendMessage(theMessage);
            //chatBox.addChatMessage(theMessage, 0);

            messageBox.Text = "Unesite poruku ovde...";
        }

        private void listBoxMsg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ThreadProcSafe()
        {
            Thread.Sleep(50);
            if (this.chatBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { msg }) ;
            }
        }
    }
}
