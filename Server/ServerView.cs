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
        static async Task Main(string[] args)
        {
            ServerController serverController = ServerController.Initialize();

            Console.WriteLine("UDP-сервер запущен");

            Task.Run(serverController.ReceiveDataForReadAsync);

            //Task.Run(ReadMessageAsync);

            Console.ReadKey();

            //async Task ReceiveMessageAsync()
            //{
            //    using (UdpClient receiver = new UdpClient(3000))
            //    {
            //        while (true)
            //        {
            //            // получаем данные
            //            var result = await receiver.ReceiveAsync();
            //            var message = Encoding.UTF8.GetString(result.Buffer);
            //            // выводим сообщение
            //            Console.WriteLine(message);
            //        }
            //    }
            //}

            //async Task SendMessageAsync()
            //{
            //    using (UdpClient sender = new UdpClient())
            //    {
            //        Console.WriteLine("Для отправки сообщений введите сообщение и нажмите Enter");
            //        // отправляем сообщения
            //        while (true)
            //        {
            //            var message = Console.ReadLine(); // сообщение для отправки
            //                                              // если введена пустая строка, выходим из цикла и завершаем ввод сообщений
            //            if (string.IsNullOrWhiteSpace(message)) break;
            //            // иначе добавляем к сообщению имя пользователя
            //            message = $"Сервер: {message}";
            //            byte[] data = Encoding.UTF8.GetBytes(message);
            //            // и отправляем на 127.0.0.1:remotePort
            //            await sender.SendAsync(data, message.Length, new IPEndPoint(localAddress, remotePort));
            //        }
            //    }
            //}
        }
        //async Task SendMessageAsync()
        //{
        //    using (UdpClient sender = new UdpClient())
        //    {
        //        Console.WriteLine("Для отправки сообщений введите сообщение и нажмите Enter");
        //        // отправляем сообщения
        //        while (true)
        //        {
        //            var message = Console.ReadLine(); // сообщение для отправки
        //                                              // если введена пустая строка, выходим из цикла и завершаем ввод сообщений
        //            if (string.IsNullOrWhiteSpace(message)) break;
        //            // иначе добавляем к сообщению имя пользователя
        //            message = $"Сервер: {message}";
        //            byte[] data = Encoding.UTF8.GetBytes(message);
        //            // и отправляем на 127.0.0.1:remotePort
        //            await sender.SendAsync(data, message.Length, new IPEndPoint(localAddress, 3001));
        //        }
        //    }
        //}
        // Получение сообщений
        //async Task ReceiveMessageAsync()
        //{
        //    using (UdpClient receiver = new UdpClient(5555))
        //    {
        //        while (true)
        //        {
        //            // получаем данные
        //            var result = await receiver.ReceiveAsync();
        //            var message = Encoding.UTF8.GetString(result.Buffer);
        //            // выводим сообщение
        //            Console.WriteLine(message);
        //        }
        //    }
        //}
    }
}
