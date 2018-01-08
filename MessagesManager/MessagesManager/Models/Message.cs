using MessagesManager.FirebaseConnection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagesManager.Models
{
    public class Message
    {
        private string text;
        private string senderId;

        public string TEXT
        {
            get
            {
                return this.text;
            }

            set
            {
                this.text = value;
            }
        }
        
        public string SENDER_ID
        {
            get
            {
                return this.senderId;
            }
            set
            {
                this.senderId = value;
            }
        }

        public Message(string text,string senderId)
        {
            this.text = text;
            this.senderId = senderId;
        }
    }
}
