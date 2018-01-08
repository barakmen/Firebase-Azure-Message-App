using MessagesManager.FirebaseConnection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagesManager.Models
{
    public class User : IFirebaseData
    {
        public string ID
        {
            get
            {
                return this.NAME;
            }
        }
        public User(string id) : base(id)
        {
        }
        
    }
}
