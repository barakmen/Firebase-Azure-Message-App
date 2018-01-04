using MessagesManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagesManager.Startup
{
    public abstract class IMessagesManager
    {
        private string _userId;
        public string USER_ID
        {
            get
            {
                return this._userId;
            }
        }

        public IMessagesManager(string userId)
        {
            this._userId = userId;
        }
        

        abstract public void addChannel(Channel newChannel);
        abstract public void removeChannel(Channel newChannel);
        abstract public void addListenerToChannel(Channel newChannel, EventHandler handler);
        abstract public void sendMessageToChannel(Channel channel, Message message);


       


    }
}
