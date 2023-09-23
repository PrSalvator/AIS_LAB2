using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace AIS_LAB2
{
    class ClientView
    {
        static async Task Main(string[] args)
        {
            IPAddress localAddress = IPAddress.Parse("127.0.0.1");
            int localPort = 3001;
            int remotePort = 3000;


            Console.WriteLine("Клиент запущен...");

            await SendMessageAsync();

            Console.WriteLine("Началась отправка сообщений");

            async Task ReceiveMessageAsync()
            {
                using (UdpClient receiver = new UdpClient(localPort))
                {
                    while (true)
                    {
                        // получаем данные
                        var result = await receiver.ReceiveAsync();
                        var message = Encoding.UTF8.GetString(result.Buffer);
                        // выводим сообщение
                        Console.WriteLine(message);
                    }
                }
            }

            async Task SendMessageAsync()
            {
                using (UdpClient sender = new UdpClient())
                {
                    Console.WriteLine("Для отправки сообщений введите сообщение и нажмите Enter");
                    // отправляем сообщения
                    while (true)
                    {
                        var message = Console.ReadLine(); // сообщение для отправки
                                                          // если введена пустая строка, выходим из цикла и завершаем ввод сообщений
                        if (string.IsNullOrWhiteSpace(message)) break;
                        // иначе добавляем к сообщению имя пользователя
                        message = $"{message}";
                        byte[] data = Encoding.UTF8.GetBytes(message);
                        // и отправляем на 127.0.0.1:remotePort
                        await sender.SendAsync(data, message.Length, new IPEndPoint(localAddress, remotePort));
                    }
                }
            }
        }

    }
}
