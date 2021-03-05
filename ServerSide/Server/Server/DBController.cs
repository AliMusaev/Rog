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
        private RogDBEntities3 context;
        public DBController()
        {
            context = new RogDBEntities3();
        }

        public string HanldeUserRequest(string req)
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
            // 
            var retMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(string));
            var retVal = new System.Data.Entity.Core.Objects.ObjectParameter("opResult", typeof(bool));
            try
            {
                // Call db procedure to create new user
                context.uspAddUser(req[0], req[1], req[2], retVal, retMessage);
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
            }
            catch(Exception ex1)
            {
                Console.WriteLine(ex1);
            }
            finally
            {

            }
            // Return registration result
            return Convert.ToString(retVal.Value);
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
