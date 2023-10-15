using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AIS_LAB2.Controllers
{
    class ClientController
    {


        private IPAddress localAddress = IPAddress.Parse(ConfigurationManager.AppSettings.Get("LocalAddress"));
        private int localPort = int.Parse(ConfigurationManager.AppSettings.Get("LocalPort"));
        private int remotePortGetBodyTypes = int.Parse(ConfigurationManager.AppSettings.Get("RemotePortGetBodyTypes"));
        private int remotePortGetCarTypes = int.Parse(ConfigurationManager.AppSettings.Get("RemotePortGetCarTypes"));
        private ClientController()
        {

        }

        private static ClientController clientController = null;

        public static ClientController Initialyze()
        {
            if (clientController == null) clientController = new ClientController();
            return clientController;
        }
        public List<Models.CarType> GetCarTypes()
        {
            using (UdpClient sender = new UdpClient())
            {
                byte[] data = Encoding.UTF8.GetBytes("");
                // и отправляем на 127.0.0.1:remotePort
                sender.Send(data, data.Length, new IPEndPoint(localAddress, remotePortGetCarTypes));
                List<Models.CarType> answer = JsonSerializer.Deserialize<List<Models.CarType>>(ReceiveDataFromServer());
                return answer;
            }
        }
        public List<Models.BodyType> GetBodyTypes()
        {
            using (UdpClient sender = new UdpClient())
            {
                byte[] data = Encoding.UTF8.GetBytes("");
                // и отправляем на 127.0.0.1:remotePort
                sender.Send(data, data.Length, new IPEndPoint(localAddress, remotePortGetBodyTypes));
                List<Models.BodyType> answer = JsonSerializer.Deserialize<List<Models.BodyType>>(ReceiveDataFromServer());
                return answer;
            }
        }
        public string ReceiveDataFromServer() // Вывод данных
        {
            using (UdpClient receiver = new UdpClient(localPort))
            {
                // получаем данные
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(localAddress, localPort);
                var result = receiver.Receive(ref RemoteIpEndPoint);
                return Encoding.UTF8.GetString(result);
            }
        }
        public string SendMessage(int remotePort, string message = "")
        {
            using (UdpClient sender = new UdpClient())
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                // и отправляем на 127.0.0.1:remotePort
                sender.Send(data, data.Length, new IPEndPoint(localAddress, remotePort));
                string answer = ReceiveDataFromServer();
                return answer;
            }
        }
    }
}
