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
    public class GeneralRequestHandler
    {
        private RogDBEntities context;
        private Authorization authorization;
        private Registration registration;
        private MainStatsHandler mainStats;
        private MessageConverter converter;
        private TransactionLogger logger;

        public GeneralRequestHandler()
        {
            context = new RogDBEntities();
            registration = new Registration(context);
            authorization = new Authorization(context);
            mainStats = new MainStatsHandler(context);
            converter = new MessageConverter();
            logger = new TransactionLogger(context);
        }

        public string HanldeRequest(string input, string userIp)
        {
            string answer = null;
            List<string> reqFields = converter.DecompileReq(input);

            byte isUniqueOperation = logger.AddNewTransaction(reqFields[0], reqFields[1], userIp);
            if (isUniqueOperation == 0)
            {
                answer = CallOperation(reqFields, userIp);
            }
            else
            {
                answer = ReturnDefMessage(isUniqueOperation);
            }
            return answer;
        }
        
        private string CallOperation(List<string> reqFields, string userIp)
        {
            string retVal = null;
            if (reqFields[0]=="regQ")
            {
                retVal = converter.CompileAnswer($"regA", registration.Register(reqFields, userIp));

            }
            else if (reqFields[0] == "logQ")
            {
                retVal = converter.CompileAnswer($"logA", authorization.Authorize(reqFields, userIp, out string userId), userId);
            }
            else if (reqFields[0] == "golQ")
            {
                retVal = converter.CompileAnswer($"golA", mainStats.UpdatePlayerCurrency(reqFields, userIp, out string userGold), userGold);
            }
            return retVal;
        }
        private string ReturnDefMessage(byte errCode)
        {
            return  converter.CompileAnswer($"comA", errCode);
        }

    }
}
