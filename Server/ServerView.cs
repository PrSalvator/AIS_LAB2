using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;

namespace Server
{
    class ServerView
    {
        static void Main(string[] args)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                SqlParameter param = new SqlParameter("@INDEX", 3);
                db.Database.ExecuteSqlCommand("exec DeleteCars @INDEX", param);
            }
            Console.ReadKey();
            //    ServerController serverController = ServerController.Initialize();

            //    Console.WriteLine("UDP-сервер запущен");

            //    Task.Run(serverController.ReceiveDataForReadAsync);

            //    Task.Run(serverController.ReceiveDataForWriteAsync);

            //    Task.Run(serverController.RecieveDataForDeleteAsync);

            //    Console.ReadKey();


        }
    }
}
