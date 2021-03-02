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
        private DBController dB;
        public ClientObj(TcpClient tcpClient, DBController dB)
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
                byte[] data = new byte[64]; // буфер для получаемых данных

                // получаем сообщение
                StringBuilder builder = new StringBuilder();
                int bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                // Запрос в БД
                string answer = dB.HanldeUseRequest(builder.ToString());
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
