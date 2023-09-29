using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Threading;
using System.Diagnostics;

namespace AIS_LAB2
{
    class ClientController
    {


        private IPAddress localAddress = IPAddress.Parse(ConfigurationManager.AppSettings.Get("LocalAddress"));
        private int localPort = int.Parse(ConfigurationManager.AppSettings.Get("LocalPort"));
        private ClientController()
        {

        }

        private static ClientController clientController = null;

        public static ClientController Initialyze()
        {
            if (clientController == null) clientController = new ClientController();
            return clientController;
        }

        public string ReceiveDataFromServerAsync() // Вывод данных
        {
            using (UdpClient receiver = new UdpClient(localPort))
            {
                // получаем данные
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(localAddress, localPort);
                var result = receiver.Receive(ref RemoteIpEndPoint);

                return Encoding.UTF8.GetString(result);
            }
        }
        public string SendMessageAsync(int remotePort, string message = "")
        {
            using (UdpClient sender = new UdpClient())
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                // и отправляем на 127.0.0.1:remotePort
                sender.Send(data, data.Length, new IPEndPoint(localAddress, remotePort)); 
                string answer = ReceiveDataFromServerAsync();
                return answer;
            }
        }
    }
}
