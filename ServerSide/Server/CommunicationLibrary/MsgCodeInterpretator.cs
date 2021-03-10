using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLibrary
{
    class MsgCodeInterpretator
    {
        private Dictionary<byte,string> codeCollection;
        public MsgCodeInterpretator()
        {
            codeCollection = new Dictionary<byte, string>() { { 0, "Success" }, { 1, "This email is already used" }, { 2, "Invalid login or password" }, { 4, "This login is already used" },{ 98, "Repeated request" }, { 99, "System error when trying to create an account" } };
        }
        public bool GetResultInformation(string code, out string msg)
        {
            byte value;
            byte.TryParse(code, out value);
            msg = codeCollection[value];
            if (value == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
