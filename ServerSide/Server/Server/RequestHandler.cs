using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using Server.Core;

namespace Server
{
    public class RequestHandler
    {
        private RogDBEntities context;
        private Authorization authorization;
        private Registration registration;
        private MainStatsHandler mainStats;
        private MessageConverter converter;
        private TransactionLogger logger;

        public RequestHandler()
        {
            context = new RogDBEntities();
            converter = new MessageConverter();
            registration = new Registration(context);
            authorization = new Authorization(context);
            mainStats = new MainStatsHandler(context);
            logger = new TransactionLogger(context);

        }

        public string Procces(string inputString, string userIp)
        {
            string outputString = null;
            // Convert input string to list of string and return reqType
            List<string> inputData  = converter.DecompileRequest(inputString, out string reqType, out string timeStamp);

            byte isUniqueOperation = logger.AddNewTransaction(reqType, timeStamp, userIp);

            if (isUniqueOperation == 0)
            {
                outputString = OperateRequest(reqType, inputData, userIp);
            }
            else
            {
                outputString = CompileErrorMessage(isUniqueOperation);
            }

            return outputString;
        }
        
        private string OperateRequest(string reqType, List<string> inputData, string userIp)
        {
            string retVal = null;
            if (reqType == "regQ")
            {
                retVal = converter.CompileAnswer($"regA", registration.Register(inputData, userIp));
            }
            else if (reqType == "logQ")
            {
                retVal = converter.CompileAnswer($"logA", authorization.Authorize(inputData, userIp, out string outputData), outputData);
            }
            else if (reqType == "golQ")
            {
                retVal = converter.CompileAnswer($"golA", mainStats.UpdatePlayerCurrency(inputData, userIp, out string outputData), outputData);
            }
            return retVal;
        }
        private string CompileErrorMessage(byte errCode)
        {
            return  converter.CompileAnswer($"comA", errCode);
        }

    }
}
