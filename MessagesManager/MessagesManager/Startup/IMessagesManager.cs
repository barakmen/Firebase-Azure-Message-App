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

        public IMessagesManager(User user)
        {
            this._userId = user.NAME;
        }
        

        abstract public void addChannel(Channel newChannel);
        abstract public void removeChannel(Channel newChannel);
        abstract public void addListenerToChannel(Channel newChannel, EventHandler handler);
        abstract public void sendMessageToChannel(User user, Channel channel, Message message);
        abstract public void getAllMessagesFromChannel(Channel channel);

        abstract public void addUser(User user);
    }
}
