using System;
using System.Collections.Generic;
using System.Text;

namespace MessagesManager.FirebaseConnection
{
    public abstract class IFirebaseData
    {
        private string _name;
        public string NAME
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public IFirebaseData(string name)
        {
            this._name = this.GetType().Name + "-" +name;
        }

    }
}
