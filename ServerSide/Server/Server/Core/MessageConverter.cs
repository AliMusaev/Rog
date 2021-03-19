using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core
{
    class MessageConverter
    {
        public List<string> DecompileRequest(string inputString, out string reqType, out string timeStamp)
        {
            try
            {
                List<string> retVal = new List<string>(inputString.Split('|'));
                reqType = retVal[0];
                timeStamp = retVal[1];
                retVal.Remove(retVal[0]);
                retVal.Remove(retVal[1]);
                return retVal;
            }
            catch (Exception)
            {

                throw;
            }
        }




        public string CompileAnswer(string answerType, byte opResult, string outputData)
        {
            return $"{answerType}|{opResult}|{outputData}";
        }
        public string CompileAnswer(string answerType, byte opResult)
        {
            return $"{answerType}|{opResult}";
        }
    }
}
