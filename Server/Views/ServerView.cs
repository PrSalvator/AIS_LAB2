using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;
using System.Text.Json;
using Server.Controllers;

namespace Server
{
    class ServerView
    {
        static void Main(string[] args)
        {
            ServerController serverController = ServerController.Initialize();

            Console.WriteLine("UDP-сервер запущен");

            Task.Run(serverController.SendBodyTypes);

            Task.Run(serverController.SendCarTypes);

            Task.Run(serverController.ReceiveDataForReadAsync);

            Task.Run(serverController.ReceiveDataForWriteAsync);

            Task.Run(serverController.RecieveDataForDeleteAsync);

            Console.ReadKey();


        }
    }
}
