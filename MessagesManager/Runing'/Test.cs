using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Firebase.Database;
using Firebase.Database.Query;
using MessagesManager.Startup;
using Newtonsoft.Json;

namespace Ranning
{


    public class Program
    {

        


        public async Task<Dinosaur> Run()
        {
            var firebase = new FirebaseClient(FBConfigurations.FIREBASE_PROJ_URL);

            var dinoadd = await firebase
            .Child("dinosaurs")
            .PostAsync(new Dinosaur());

            

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
        public double Height { get; set; }
    }
}
