using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class DBController
    {
        private RogDBEntities2 context;
        public DBController()
        {
            context = new RogDBEntities2();
        }

        public string HanldeUseRequest(string req)
        {
            string retVal = null;
            if (req.StartsWith("regQ"))
            {
                retVal = RegistrationReq(DecompileReq(req));

            }
            return retVal;
        }
        private string RegistrationReq(List<string> req)
        {
            string retVal = null;
            UserAccount userAccount = new UserAccount();
            userAccount.UserLogin = req[0];
            userAccount.UserPassword = req[1];
            userAccount.Email = req[2];
            try
            {
                context.UserAccount.Add(userAccount);
                context.SaveChanges();
                retVal = $"User has been created";
                Console.WriteLine($"User has been created");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
                //Console.WriteLine(ex.Message);
                //retVal = $"Error";
            }
            finally
            {
                
            }
            return retVal;
        }
        private List<string> DecompileReq(string req)
        {
            // Parse user request and create new list
            List<string> retVal = new List<string>(req.Split('|'));
            // Remove request identificator
            retVal.Remove(retVal[0]);
            return retVal;
        }
        //private string CompileAnswer()
        //{

        //}
    }
}
