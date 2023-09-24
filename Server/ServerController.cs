using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerController
    {
        private IPAddress localAddress = IPAddress.Parse("127.0.0.1");
        private int localPort0 = 3000; // для добавления данных
        private int localPort1 = 3001; // для вывода данных
        private int remotePort = 3002;

        private static ServerController serverController = null;
        protected ServerController()
        {

        }

        public static ServerController Initialize()
        {
            if(serverController == null) serverController = new ServerController();
            return serverController;
        }

        public async Task ReceiveDataForReadAsync()
        {
            using (UdpClient receiver = new UdpClient(localPort0))
            {
                while (true)
                {
                    // получаем данные
                    var result = await receiver.ReceiveAsync();
                    var message = Encoding.UTF8.GetString(result.Buffer);
                    // выводим сообщение
                    if (message == "") 
                    {

                    }
                    else
                    {
                        int index = int.Parse(message);
                    }
                }
            }
        }
    }
}
