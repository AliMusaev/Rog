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
        static TcpListener listener;
        static void Main(string[] args)
        {

            while (true)
            {
                try
                {
                    DBController dB = new DBController();
                    listener = new TcpListener(IPAddress.Parse("192.168.0.104"), port); //192.168.0.104
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
