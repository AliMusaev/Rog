using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core
{
    class MainStatsHandler
    {
        private readonly int FPbyLevelUp = 25;
        private MessageConverter converter;
        private RogDBEntities context;
        public MainStatsHandler(RogDBEntities context)
        {
            this.context = context;
            this.converter = new MessageConverter();
        }
       
        public string UpdatePlayerCurrency(string input, string userIp)
        {
            
            var opResult = new ObjectParameter("opResult", typeof(byte));

            List<string> reqFields = converter.DecompileReq(input);

            bool isUniqueOp = AddNewTransaction(reqFields[0], reqFields[1], userIp);

            if (isUniqueOp)
            {
                int id = int.Parse(reqFields[1]);
                int gold = int.Parse(reqFields[2]);
                context.UpdateUserGold(id, gold, opResult);
            }
            else
            {
                // Set error number 98
                opResult.Value = 98;
            }
            return converter.CompileAnswer("golA", (byte)opResult.Value);
        }



        private bool AddNewTransaction(string transType, string transId, string userIp)
        {
            var retValue = new ObjectParameter("responseMessage", typeof(bool));
            context.AddTransLog(transType, transId, userIp, retValue);
            return (bool)retValue.Value;
        }


    }
}
