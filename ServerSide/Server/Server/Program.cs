using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        const int port = 61555;
        static IPAddress ip;
        static TcpListener listener;
        static void Main(string[] args)
        {
            ip = IPAddress.Parse("127.0.0.1");
            while (true)
            {
                try
                {
                    RequestHandler dB = new RequestHandler();
                    listener = new TcpListener(ip, port);
                    listener.Start();
                    Console.WriteLine("Ожидание подключений...");

                    while (true)
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        ClientObj clientObject = new ClientObj(client, dB);

                        // создаем новый поток для обслуживания нового клиента
                        Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                        clientThread.Start();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (listener != null)
                        listener.Stop();
                }
            }
           
            
        }
    }
}
