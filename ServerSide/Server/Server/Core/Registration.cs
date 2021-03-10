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
        private MessageConverter converter;
        private RogDBEntities context;
        public Registration(RogDBEntities context)
        {
            this.context = context;
            converter = new MessageConverter();
        }
        public string Register(string input, string userIp)
        {
            // method result value
            string compiledAnswer = null;
            // Returned values from DB. responseMessage - error message else empty, opResult - result code (looks in ResultsCodeTable)
            var retMessage = new ObjectParameter("responseMessage", typeof(string));
            var opResult = new ObjectParameter("opResult", typeof(byte));

            List<string> reqFields = converter.DecompileReq(input);
            byte isUniqueOp = AddNewTransaction(reqFields[0], reqFields[1], userIp);
            // If request already added into table then skip further handle
            if (isUniqueOp == 0)
            {
                try
                {
                    // Call db procedure to create new user
                    lock (__lockObj)
                    {
                        context.uspAddUser(reqFields[0], reqFields[1], reqFields[2], userIp, opResult, retMessage);
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
                // When registration return err message 
                if (retMessage.Value.ToString().Length > 0)
                {
                    Console.WriteLine(retMessage.Value.ToString());
                }
                
                compiledAnswer = converter.CompileAnswer("RegA", (byte)opResult.Value);
            }
            else
            {
                compiledAnswer = converter.CompileAnswer("RegA", isUniqueOp);
            }
            // Return registration result
            return compiledAnswer;

        }
        private byte AddNewTransaction(string transType, string transId, string userIp)
        {
            var retValue = new ObjectParameter("opResult", typeof(byte));
            context.AddTransLog(transType, transId, userIp, retValue);
            return (byte)retValue.Value;
        }
    }
}
