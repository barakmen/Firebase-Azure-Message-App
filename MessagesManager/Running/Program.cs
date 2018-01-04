using Firebase.Database;
using Firebase.Database.Query;
using MessagesManager.Startup;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


/***
 * all data takes from: 
 * https://github.com/step-up-labs/firebase-database-dotnet
***/
namespace Running
{
    class MainProgram
    {
        static void Main(string[] args)
        {

            
            new Program().listen();
            //new Program().getData().Wait();
            //new Program().addData().Wait();
            //new Program().removeData().Wait();


            Console.Write("Done");
            Console.ReadLine();
        }
    }


    public class Program
    {

        public async Task removeData()
        {
            var firebase = new FirebaseClient(FBConfigurations.FIREBASE_PROJ_URL);

            // delete given child node
            await firebase
              .Child("dinosaurs")
              .Child("t-rex")
              .DeleteAsync();
        }

        public async Task addData()
        {
            var firebase = new FirebaseClient(FBConfigurations.FIREBASE_PROJ_URL);

            // add new item to list of data and let the client generate new key for you (done offline)
            /*var dino = await firebase
            //  .Child("dinosaurs")
              .PostAsync(new Dinosaur());*/

            // note that there is another overload for the PostAsync method which delegates the new key generation to the firebase server

            //  Console.WriteLine($"Key for the new dinosaur: {dino.Key}");

            // add new item directly to the specified location (this will overwrite whatever data already exists at that location)
            await firebase
             .Child("dinosaurs")
             .Child("t-rex")
             .PutAsync(new Dinosaur(555));


        }

        public void listen()
        {
            var firebase = new FirebaseClient(FBConfigurations.FIREBASE_PROJ_URL);
            var observable = firebase
              .Child("dinosaurs")
              .AsObservable<Dinosaur>()
              .Subscribe(d => Console.WriteLine(d.Object.Height));

        }

        public async Task<Dinosaur> getData()
        {
            var firebase = new FirebaseClient(FBConfigurations.FIREBASE_PROJ_URL);
            

            var dinos = await firebase
              .Child("dinosaurs")
              .OnceAsync<Dinosaur>();

            foreach (var dino in dinos)
            {
                Console.WriteLine($"{dino.Key} is {dino.Object.Height}m high.");
            }

            return null;
        }
    }
    public class Dinosaur
    {
        public Dinosaur(double height)
        {
            Height = height;
        }
        public double Height { get; set; }
    }
}
