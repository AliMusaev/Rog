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
        private TcpClient client;
        private GeneralRequestHandler dB;
        public ClientObj(TcpClient tcpClient, GeneralRequestHandler dB)
        {
            client = tcpClient;
            this.dB = dB;
        }

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[255]; // буфер для получаемых данных
                string MYIpClient = Convert.ToString(((System.Net.IPEndPoint)client.Client.RemoteEndPoint).Address);
                // получаем сообщение
                StringBuilder builder = new StringBuilder();
                int bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                // Запрос в БД
                string answer = dB.HanldeRequest(builder.ToString(), MYIpClient);
                // отправляем обратно сообщение
                data = Encoding.Unicode.GetBytes(answer);

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
