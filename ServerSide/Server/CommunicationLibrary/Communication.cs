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
        private MsgCodeInterpretator msgInterpretator;

        public Communication()
        {
            msgInterpretator = new MsgCodeInterpretator();
        }

        public bool RegistrationRequest(string login, string password, string email, out string retMessage)
        {
            
            bool retVal = false;
            try
            {
                NetworkStream stream = OpenStream();
                
                string request = $"regQ|{login}+{DateTime.Now}|{login}|{password}|{email}";

                string answer = Communicate(request, stream);

                List<string> decompileAnswer = DecompileAnswer(answer);

                retVal = msgInterpretator.GetResultInformation(decompileAnswer[0], out retMessage);
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
        public bool GoldUpdate(string key, int id, int gold, out string retMessage)
        {

            bool retVal = false;
            try
            {
                NetworkStream stream = OpenStream();

                string request = $"golQ|{key}|{id}|{gold}";

                string answer = Communicate(request, stream);

                List<string> decompileAnswer = DecompileAnswer(answer);

                retVal = msgInterpretator.GetResultInformation(decompileAnswer[0], out retMessage);
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
        public string LoginRequest(string login, string password, out int userId)
        {
            string retVal = null;

            try
            {
                NetworkStream stream = OpenStream();

                string request = $"logQ|{login}+{DateTime.Now}|{login}|{password}";

                string answer = Communicate(request, stream);

                List<string> decompileAnswer = DecompileAnswer(answer);

                bool opResult = msgInterpretator.GetResultInformation(decompileAnswer[0], out retVal);

                if (opResult)
                {
                    int.TryParse(decompileAnswer[1], out userId);
                }
                else
                {
                    userId = -1;
                }
            }
            catch (Exception ex)
            {
                retVal = ex.Message;
                userId = -1;
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
            data = new byte[255];
            StringBuilder builder = new StringBuilder();
            // data length
            int bytes = 0;
            // read answer from server
            bytes = stream.Read(data, 0, data.Length);
            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            return builder.ToString();
        }
        private List<string> DecompileAnswer(string message)
        {
            // Parse user request and create new list
            List<string> retVal = new List<string>(message.Split('|'));
            // Remove request identificator
            retVal.Remove(retVal[0]);
            return retVal;
        }
    }

}
