using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using MessagesManager.Models;

namespace MessagesManager.Startup
{
    public class MessageManagerImpl : IMessagesManager
    {
        

        private ICollection<Channel> _channels;
        private FirebaseClient _firebase;

        public MessageManagerImpl(string userId, ICollection<Channel> channels) : base(userId)
        {
            _channels = channels;
            _firebase = new FirebaseClient(FBConfigurations.FIREBASE_PROJ_URL);
        }

        public MessageManagerImpl(string userId) : base(userId)
        {
            _channels = new List<Channel>();
            _firebase = new FirebaseClient(FBConfigurations.FIREBASE_PROJ_URL);
        }

        public override void addChannel(Channel newChannel)
        {

        }

        public override void addListenerToChannel(Channel newChannel, EventHandler handler)
        {
            throw new NotImplementedException();
        }

        public override void removeChannel(Channel newChannel)
        {
            throw new NotImplementedException();
        }

        public override void sendMessageToChannel(Channel channel, Message message)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
