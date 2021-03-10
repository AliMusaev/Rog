using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core
{
    class MessageConverter
    {
        public List<string> DecompileReq(string req)
        {
            // Parse user request and create new list
            List<string> retVal = new List<string>(req.Split('|'));
            // Remove request identificator
            return retVal;
        }
        public string CompileAnswer(string ansId, byte opResult, string data)
        {
            return $"{ansId}|{opResult}|{data}";
        }
        public string CompileAnswer(string ansId, byte opResult)
        {
            return $"{ansId}|{opResult}";
        }
    }
}
