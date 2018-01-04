using Firebase.Database;
using Firebase.Database.Query;
using MessagesManager.Startup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TestFirebaseConnection
{
    [TestClass]
    public class CRUDFirebase
    {
        FirebaseClient firebase = null;

       [TestInitialize]
        public void init()
        {
            FirebaseClient firebase = new FirebaseClient(FBConfigurations.FIREBASE_PROJ_URL);
        }

        [TestMethod]
        public void getDataTest()
        {
            object data = getData();
            Assert.AreNotEqual(null, data);

        }

        [TestMethod]
        public void addDataTest()
        {
             addData();
            Assert.AreNotEqual(false, true);

        }

        public async Task addData()
        {
            await firebase
             .Child("dinosaurs")
             .Child("t-rex")
             .PutAsync(new Dinosaur());
            
        }

        public async Task<object> getData()
        {
          

            var dinos = await firebase
              .Child("dinosaurs")
              .OnceAsync<Dinosaur>();

            foreach (var dino in dinos)
            {
                Console.WriteLine($"{dino.Key} is {dino.Object.Height}m high.");
            }

            return dinos;
        }


        [TestCleanup]
        public void finish()
        {
            firebase = null;
        }

    }

    public class Dinosaur
    {
        public double Height { get; set; }
    }
}
