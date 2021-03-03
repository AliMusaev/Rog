using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLibrary
{
    public class Communication
    {
        private TcpClient client;


        public string CreateNewAccRequest(string login, string password, string email)
        {
            string retVal = null ;
            try
            {
                NetworkStream stream = OpenStream();
                
                string request = $"regQ|{login}|{password}|{email}";

                Communicate(request, stream);

            }
            catch (Exception ex)
            {
                retVal = ex.Message;
            }
            finally
            {
                if (client != null)
                    client.Close();
            }
            return retVal;
        }
        private NetworkStream OpenStream()
        {
            int port = 61555;
            string address = "127.0.0.1";  //95.31.4.144
            client = new TcpClient(address, port);
            NetworkStream stream = null;
            stream = client.GetStream();
            return stream;
        }
        private string Communicate(string request, NetworkStream stream)
        {
            // SEND REQUEST

            // Convert message
            byte[] data = Encoding.Unicode.GetBytes(request);
            // Send request to server
            stream.Write(data, 0, data.Length);

            // RECIVE ANSWER

            // Data buffer
            data = new byte[64];
            StringBuilder builder = new StringBuilder();
            // data length
            int bytes = 0;
            // read answer from server
            bytes = stream.Read(data, 0, data.Length);
            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            string retVal = builder.ToString();
            return retVal;
        }
    }

}
