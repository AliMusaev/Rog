using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;

namespace Server.Core
{
    class Authorization
    {
        private readonly object __lockObj = new object();
        private RogDBEntities context;
        public Authorization(RogDBEntities context)
        {
            this.context = context;
        }
        public byte Authorize(List<string> reqFields, string userIp, out string retVal)
        {
            var retId = new ObjectParameter("Id", typeof(int));
            var opResult = new ObjectParameter("opResult", typeof(byte));
            
                try
                {
                    // Call db procedure authorize
                    lock (__lockObj)
                    {
                        context.uspLogin(reqFields[2], reqFields[3], userIp, opResult, retId);
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
                }
                if ((byte)opResult.Value == 0)
                {
                    retVal = retId.Value.ToString();
                }
                else
                {
                    retVal = "-1";
                }
            return (byte)opResult.Value;
        }
       
    }
}
