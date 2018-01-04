using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

namespace MessagesManager
{


    public class Program
    {
        public async Task<Dinosaur> Run()
        {


            var firebase = new FirebaseClient("https://azure-sending-messages.firebaseio.com/");
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
        [JsonProperty(PropertyName = "Height")]
        public double Height { get; set; }
    }
}
