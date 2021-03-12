using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;

namespace Server.Core
{
    class Registration
    {
        private readonly object __lockObj = new object();
        private RogDBEntities context;
        public Registration(RogDBEntities context)
        {
            this.context = context;
        }
        public byte Register(List<string> reqFields, string userIp)
        {
            // Returned values from DB. responseMessage - error message else empty, opResult - result code (looks in ResultsCodeTable)
            var opResult = new ObjectParameter("opResult", typeof(byte));

                try
                {
                    // Call db procedure to create new user
                    lock (__lockObj)
                    {
                        context.uspAddUser(reqFields[2], reqFields[3], reqFields[4], userIp, opResult);
                    }
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
                catch (Exception ex1)
                {
                    Console.WriteLine(ex1);
                }
            return (byte)opResult.Value;

        }
    }
}
