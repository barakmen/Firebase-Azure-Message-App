using Firebase.Database;
using Firebase.Database.Query;
using MessagesManager.FirebaseConnection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MessagesManager.Startup
{

    /***
     * 
     * Firebase methods that allow add, delete, get, listen a data:
     * 
     ***/
    public static class FBManaging
    {

        public static async Task addData(FirebaseClient firebase, string path, Object data)
        {
            await firebase
             .Child(path)
             .PostAsync(data);
            Console.WriteLine("Node: '" + data + "' added to path: '" + path + "'");
        }

        public static async Task addStructuredData(FirebaseClient firebase, string path, IFirebaseData data)
        {
            
            await firebase
             .Child(path + "/" + data.NAME)
             .PutAsync(data);
            Console.WriteLine("Node: '" + data + "' added to path: '" + path + "'");
        }

        public static async Task removeData(FirebaseClient firebase, string path, Object data)
        {
            await firebase
              .Child(path + "/" + data)
              .DeleteAsync();
            Console.WriteLine("Node: '" + data + "' removed from path: '" + path + "'");
        }

        public static async Task removeStructuredData(FirebaseClient firebase, string path, IFirebaseData data)
        {

            await firebase
              .Child(path + "/" + data.NAME)
              .DeleteAsync();
            Console.WriteLine("Node: '" + data.NAME + "' removed from path: '" + path + "'");
        }

        public static async Task<bool> isDataInPathExist(FirebaseClient firebase, string path)
        {
            var res = await firebase
                .Child(path)
                .OnceAsync<Object>();

            Console.WriteLine("Look for path: '" + path + "' found '" + res.Count + "' results.");

            return res.Count != 0;
        }

    }
}
