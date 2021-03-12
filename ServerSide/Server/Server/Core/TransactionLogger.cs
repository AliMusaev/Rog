using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core
{
    class TransactionLogger
    {
        RogDBEntities context;
        public TransactionLogger(RogDBEntities context)
        {
            this.context = context;
        }

        public byte AddNewTransaction(string transType, string timeStamp, string userIp)
        {
            var retValue = new ObjectParameter("opResult", typeof(byte));
            context.AddTransLog(transType, timeStamp, userIp, retValue);
            return (byte)retValue.Value;
        }
    }
}
