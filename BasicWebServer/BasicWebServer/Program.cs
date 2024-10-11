using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace BasicWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var ipAddress = IPAddress.Parse("127.0.0.1");
            var port = 8080;
            var serverListener = new TcpListener(ipAddress, port);
            serverListener.Start();
            Console.WriteLine($"Server started on port{port}.");
            Console.WriteLine("Listening for requests...");
            while (true)
            {
                var connection = serverListener.AcceptTcpClient();
                var networkStream = connection.GetStream();
                var content = "Hello there!";
               
                connection.Close();
            }
           
        }
    }
}
