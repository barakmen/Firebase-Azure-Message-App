using MessagesManager;
using System;

namespace WebApp
{
    class MainClass
    {
        static void Main(string[] args)
        {
            new Program().Run().Wait();
            Console.ReadLine();
        }
    }
}
