using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using MessagesManager.FirebaseConnection;
using MessagesManager.Models;

namespace MessagesManager.Startup
{
    public class MessageManagerImpl : IMessagesManager
    {


        private ICollection<Channel> _channels;
        private FirebaseClient _firebase;
        private string globalChannelsPath = "";
        private string userChannelsPath = "";
        private string userPath = "";
        public MessageManagerImpl(User user, ICollection<Channel> channels) : base(user)
        {
            _channels = channels;
            init();
        }

        public MessageManagerImpl(User user) : base(user)
        {
            _channels = new List<Channel>();
            init();
        }

        private void init() {
            _firebase = new FirebaseClient(FBConfigurations.FIREBASE_PROJ_URL);
            userChannelsPath = FBConfigurations.ROOT_USERS + "/" + this.USER_ID  + "/Channels";
            globalChannelsPath = "Channels";
        }

        public override void addChannel(Channel newChannel)
        {

            FBManaging.addData(_firebase, userChannelsPath, newChannel.NAME).Wait();
            FBManaging.addStructuredData(_firebase, globalChannelsPath, newChannel).Wait();
        }

        public override void removeChannel(Channel newChannel)
        {
            FBManaging.removeData(_firebase, userChannelsPath, newChannel.NAME).Wait();
            FBManaging.removeStructuredData(_firebase, globalChannelsPath, newChannel).Wait();
        }

        public override void sendMessageToChannel(User user,Channel channel, Message message)
        { 
            if (!isChannelExists(channel))
            {
                this.addChannel(channel);
            }
          /*  if (!isUserExists(user))
            {
                this.addUser(user);
            }*/
            FBManaging.addData(_firebase, globalChannelsPath + "/" + channel.NAME , message).Wait();
        }

        public override void addListenerToChannel(Channel newChannel, EventHandler handler)
        {
            throw new NotImplementedException();
        }

        public override void getAllMessagesFromChannel(Channel channel)
        {
            throw new NotImplementedException();
        }

        private bool isChannelExists(Channel channel)
        {
            return FBManaging.isDataInPathExist(_firebase, globalChannelsPath + "/" + channel.NAME).GetAwaiter().GetResult();
        }


        private bool isUserExists(User user)
        {
            return FBManaging.isDataInPathExist(_firebase, FBConfigurations.ROOT_USERS + "/" + user.NAME).GetAwaiter().GetResult();
        }

        public override void addUser(User user)
        {
            
        }
    }
}
