using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientObj
    {
        TcpClient client;
        DBController dBController;
        public ClientObj(TcpClient tcpClient, DBController controller)
        {
            client = tcpClient;
            dBController = controller;
        }

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[64]; // буфер для получаемых данных

                // получаем сообщение
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));

                string input = builder.ToString();
                string retVal = dBController.RequestHandler(input);


                // отправляем обратно сообщение
                data = Encoding.Unicode.GetBytes(retVal);

                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }

    }
}
