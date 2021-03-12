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
        private RogDBEntities context;
        public MainStatsHandler(RogDBEntities context)
        {
            this.context = context;
        }
       
        public byte UpdatePlayerCurrency(List<string> reqFields, string userIp, out string retVal)
        {
            
            var opResult = new ObjectParameter("opResult", typeof(byte));
            var newValue = new ObjectParameter("NewValue", typeof(int));
            int id = int.Parse(reqFields[1]);
            int gold = int.Parse(reqFields[2]);
            context.UpdateUserGold(id, gold, newValue, opResult);
            retVal = newValue.Value.ToString();
            return (byte)opResult.Value;
        }



       

    }
}
