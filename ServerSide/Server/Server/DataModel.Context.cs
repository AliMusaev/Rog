﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RogDBEntities : DbContext
    {
        public RogDBEntities()
            : base("name=RogDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<GeneralStats> GeneralStats { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAuthorizationLog> UserAuthorizationLog { get; set; }
        public virtual DbSet<UserEquip> UserEquip { get; set; }
        public virtual DbSet<UserInventory> UserInventory { get; set; }
        public virtual DbSet<UserRegistrationLog> UserRegistrationLog { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TransactionLog> TransactionLog { get; set; }
    
        public virtual int InsertToLog(Nullable<bool> inRegTable, string userLogin, string ipAdress, Nullable<byte> opResult, string message)
        {
            var inRegTableParameter = inRegTable.HasValue ?
                new ObjectParameter("InRegTable", inRegTable) :
                new ObjectParameter("InRegTable", typeof(bool));
    
            var userLoginParameter = userLogin != null ?
                new ObjectParameter("UserLogin", userLogin) :
                new ObjectParameter("UserLogin", typeof(string));
    
            var ipAdressParameter = ipAdress != null ?
                new ObjectParameter("IpAdress", ipAdress) :
                new ObjectParameter("IpAdress", typeof(string));
    
            var opResultParameter = opResult.HasValue ?
                new ObjectParameter("opResult", opResult) :
                new ObjectParameter("opResult", typeof(byte));
    
            var messageParameter = message != null ?
                new ObjectParameter("Message", message) :
                new ObjectParameter("Message", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertToLog", inRegTableParameter, userLoginParameter, ipAdressParameter, opResultParameter, messageParameter);
        }
    
        public virtual int uspAddUser(string pLogin, string pPassword, string pEmail, string pIp, ObjectParameter opResult)
        {
            var pLoginParameter = pLogin != null ?
                new ObjectParameter("pLogin", pLogin) :
                new ObjectParameter("pLogin", typeof(string));
    
            var pPasswordParameter = pPassword != null ?
                new ObjectParameter("pPassword", pPassword) :
                new ObjectParameter("pPassword", typeof(string));
    
            var pEmailParameter = pEmail != null ?
                new ObjectParameter("pEmail", pEmail) :
                new ObjectParameter("pEmail", typeof(string));
    
            var pIpParameter = pIp != null ?
                new ObjectParameter("pIp", pIp) :
                new ObjectParameter("pIp", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspAddUser", pLoginParameter, pPasswordParameter, pEmailParameter, pIpParameter, opResult);
        }
    
        public virtual int uspLogin(string pLoginName, string pPassword, string pIp, ObjectParameter opResult, ObjectParameter id)
        {
            var pLoginNameParameter = pLoginName != null ?
                new ObjectParameter("pLoginName", pLoginName) :
                new ObjectParameter("pLoginName", typeof(string));
    
            var pPasswordParameter = pPassword != null ?
                new ObjectParameter("pPassword", pPassword) :
                new ObjectParameter("pPassword", typeof(string));
    
            var pIpParameter = pIp != null ?
                new ObjectParameter("pIp", pIp) :
                new ObjectParameter("pIp", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspLogin", pLoginNameParameter, pPasswordParameter, pIpParameter, opResult, id);
        }
    
        public virtual int AddTransLog(string transType, string timeStamp, string userIp, ObjectParameter opResult)
        {
            var transTypeParameter = transType != null ?
                new ObjectParameter("transType", transType) :
                new ObjectParameter("transType", typeof(string));
    
            var timeStampParameter = timeStamp != null ?
                new ObjectParameter("timeStamp", timeStamp) :
                new ObjectParameter("timeStamp", typeof(string));
    
            var userIpParameter = userIp != null ?
                new ObjectParameter("userIp", userIp) :
                new ObjectParameter("userIp", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddTransLog", transTypeParameter, timeStampParameter, userIpParameter, opResult);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int UpdateUserGold(Nullable<int> userId, Nullable<int> addedGold, ObjectParameter newValue, ObjectParameter opResult)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            var addedGoldParameter = addedGold.HasValue ?
                new ObjectParameter("addedGold", addedGold) :
                new ObjectParameter("addedGold", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateUserGold", userIdParameter, addedGoldParameter, newValue, opResult);
        }
    }
}
