using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class ServerView
    {
        static void Main(string[] args)
        {
            ServerController serverController = ServerController.Initialize();

            Console.WriteLine("UDP-сервер запущен");

            Task.Run(serverController.ReceiveDataForReadAsync);

            Task.Run(serverController.ReceiveDataForWriteAsync);

            Task.Run(serverController.RecieveDataForDeleteAsync);

            Console.ReadKey();

          
        }
    }
}
