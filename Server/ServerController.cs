using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace Server
{
    class ServerController
    {
        private IPAddress localAddress = IPAddress.Parse("127.0.0.1");
        
        private int localPortRead = int.Parse(ConfigurationManager.AppSettings.Get("LocalPortRead")); // для вывода данных
        private int localPortWrite = int.Parse(ConfigurationManager.AppSettings.Get("LocalPortWrite")); // для добавления данных
        private int localPortDelete = int.Parse(ConfigurationManager.AppSettings.Get("LocalPortDelete"));
        private int remotePort = int.Parse(ConfigurationManager.AppSettings.Get("RemotePort"));

        private DataController dataController = DataController.Initialyze(ConfigurationManager.AppSettings.Get("Path"));

        private static ServerController serverController = null;
        protected ServerController()
        {

        }

        public static ServerController Initialize()
        {
            if(serverController == null) serverController = new ServerController();
            return serverController;
        }

        public async Task ReceiveDataForReadAsync() // Вывод данных
        {
            using (UdpClient receiver = new UdpClient(localPortRead))
            {
                while (true)
                {
                    // получаем данные
                    var result = await receiver.ReceiveAsync();
                    var message = Encoding.UTF8.GetString(result.Buffer);
                    try
                    {
                        if (int.TryParse(message, out int index)) // Чтение по индексу
                        {
                            await SendMessageAsync(dataController.ReadData(index));
                            continue;
                        }
                        // Чтение файла полностью
                        await SendMessageAsync(dataController.ReadData());
                    }
                    catch(Exception e)
                    {
                        await SendMessageAsync(e.Message);
                    }
                }
            }
        }

        public async Task ReceiveDataForWriteAsync()
        {
            using (UdpClient receiver = new UdpClient(localPortWrite))
            {
                while (true)
                {
                    var result = await receiver.ReceiveAsync();
                    var message = Encoding.UTF8.GetString(result.Buffer);
                    try
                    {
                        dataController.WriteData(message);
                        await SendMessageAsync("Добавление машины прошло успешно");
                    }
                    catch (Exception e)
                    {
                        await SendMessageAsync(e.Message);
                    }
                }
            }
        }

        public async Task RecieveDataForDeleteAync()
        {
            using (UdpClient receiver = new UdpClient(localPortDelete))
            {
                while (true)
                {
                    var result = await receiver.ReceiveAsync();
                    var message = Encoding.UTF8.GetString(result.Buffer);
                    try
                    {
                        if (int.TryParse(message, out int index)) // Чтение по индексу
                        {
                            dataController.DeleteData(index);
                            await SendMessageAsync("Удаление записи прошло успешно");
                            continue;
                        }
                        // Чтение файла полностью
                        dataController.DeleteData();
                        await SendMessageAsync("Все записи удалены");
                    }
                    catch (Exception e)
                    {
                        await SendMessageAsync(e.Message);
                    }
                }
            }
        }

        public async Task SendMessageAsync(string message)
        {
            using (UdpClient sender = new UdpClient())
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                // и отправляем на 127.0.0.1:remotePort
                await sender.SendAsync(data, data.Length, new IPEndPoint(localAddress, remotePort));
            }
        }
    }
}
