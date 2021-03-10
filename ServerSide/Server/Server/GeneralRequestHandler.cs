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

        public GeneralRequestHandler()
        {
            context = new RogDBEntities();
            registration = new Registration(context);
            authorization = new Authorization(context);
            mainStats = new MainStatsHandler(context);
        }

        public string HanldeRequest(string input, string userIp)
        {
            string retVal = null;

            if (input.StartsWith("regQ"))
            {
                retVal = registration.Register(input, userIp);

            }
            else if (input.StartsWith("logQ"))
            {
                retVal = authorization.Authorize(input, userIp);
            }
            else if (input.StartsWith("golQ"))
            {
                retVal = mainStats.UpdatePlayerCurrency(input, userIp);
            }
            return retVal;
        }
      

        
    }
}
