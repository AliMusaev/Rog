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


        public bool RegistrationRequest(string login, string password, string email, out string retMessage)
        {
            retMessage = null;
            bool retVal = false;
            try
            {
                NetworkStream stream = OpenStream();
                
                string request = $"regQ|{login}|{password}|{email}";

                retVal = Communicate(request, stream, out retMessage);

            }
            catch (Exception ex)
            {
                retMessage = ex.Message;
            }
            finally
            {
                if (client != null)
                    client.Close();
            }
            return retVal;
        }
        public bool LoginRequest(string login, string password, out string retMessage)
        {
            retMessage = null;
            bool retVal = false;

            try
            {
                NetworkStream stream = OpenStream();

                string request = $"logQ|{login}|{password}";

                retVal = Communicate(request, stream, out retMessage);
            }
            catch (Exception ex)
            {
                retMessage = ex.Message;
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
        private bool Communicate(string request, NetworkStream stream, out string retMessage)
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

            bool retVal = false;
            try
            {
                retVal = bool.Parse(builder.ToString());
            }
            catch (Exception ex)
            {

                retMessage = ex.Message;
            }
            finally
            {
                retMessage = builder.ToString();
                retVal = false;
            }
            return retVal;
        }
    }

}
