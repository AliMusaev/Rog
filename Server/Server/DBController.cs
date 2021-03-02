using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class DBController
    {
        TestDbEntities1 context;

        public DBController()
        {
            context = new TestDbEntities1();
        }

        public string RequestHandler(string message)
        {
            string retVal = null;
            if (message.StartsWith("a1"))
            {
                retVal = CreateUser(message);
            }

            return retVal;
            
        }

        private string CreateUser(string message)
        {
            string[] values = message.Split('|');
            int id;
            Int32.TryParse(values[1], out id);

            UserAccount userAccount = new UserAccount { Id = id, Email = values[2], Loign = values[3], Pass = values[4]};
            context.UserAccount.Add(userAccount);
            context.SaveChanges();
            return $"User {values[3]} has been created";
        }
    }
}
