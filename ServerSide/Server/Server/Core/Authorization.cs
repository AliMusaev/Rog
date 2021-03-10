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
        private MessageConverter converter;
        private RogDBEntities context;
        public Authorization(RogDBEntities context)
        {
            this.context = context;
            converter = new MessageConverter();
        }
        public string Authorize(string input, string userIp)
        {
            // method result value
            string compiledAnswer = null;
            // Returned values from DB. Id - returned user ID if authorization has been successed, opResult - result code (looks in ResultsCodeTable)
            var retId = new ObjectParameter("Id", typeof(int));
            var opResult = new ObjectParameter("opResult", typeof(byte));
            // Decompile client request
            List<string> reqFields = converter.DecompileReq(input);
            // Register this request in TransactionLog. 
            byte isUniqueOp = AddNewTransaction(reqFields[0], reqFields[1], userIp);
            // If request already added into table then skip further handle
            if (isUniqueOp == 0)
            {
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
                    // If after db procedure opResult == 0 then operation complete successed
                    compiledAnswer = converter.CompileAnswer("LogA", (byte)opResult.Value, retId.Value.ToString());
                }
                else
                {
                    // If after db procedure opResult != 0 then operation complete with some error
                    compiledAnswer = converter.CompileAnswer("LogA", (byte)opResult.Value);
                }
            }
            else
            {
                // If transaction is not unique then return opResult from AddNewTransaction method
                compiledAnswer = converter.CompileAnswer("LogA", isUniqueOp);
            }

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
