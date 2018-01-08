using Firebase.Database;
using Firebase.Database.Query;
using MessagesManager.FirebaseConnection;
using MessagesManager.Models;
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

            var firebase = new FirebaseClient(FBConfigurations.FIREBASE_PROJ_URL);
            User user = new User("44666");
            IMessagesManager mm = new MessageManagerImpl(user);
            string channelId = "111111421252";
            Channel channel = new Channel(channelId);
            //mm.addChannel(new Channel(channelId));
            //mm.removeChannel(new Channel(channelId));
            mm.sendMessageToChannel(user, channel, new Message("my message",  user.ID));
            
            //new Program().listen(firebase);
            //new Program().getData(firebase).Wait();
            //new Program().addData(firebase).Wait();
            //new Program().removeData(firebase).Wait();


            Console.Write("Done");
            Console.ReadLine();
        }
    }


    public class Program
    {

        public async Task removeData(FirebaseClient firebase)
        {


            // delete given child node
            await firebase
              .Child("dinosaurs/t-rex")
              .DeleteAsync();
        }

        public async Task addData(FirebaseClient firebase)
        {
            // add new item to list of data and let the client generate new key for you (done offline)
            var dino = await firebase
              .Child("dinosaurs")
              .PostAsync(new Dinosaur(1));

            // note that there is another overload for the PostAsync method which delegates the new key generation to the firebase server

            Console.WriteLine($"Key for the new dinosaur: {dino.Key}");

            // add new item directly to the specified location (this will overwrite whatever data already exists at that location)
            await firebase
              .Child("dinosaurs")
              .Child("t-rex")
              .PutAsync(new Dinosaur(2));



        }

        public void listen(FirebaseClient firebase, Object data)
        {
            var observable = firebase
              .Child("dinosaurs")
              .AsObservable<Dinosaur>()
              .Subscribe(d => Console.WriteLine(d.Object.Height));

        }

        public async Task<Dinosaur> getData(FirebaseClient firebase, Object data)
        {
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
