//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class GeneralStats
    {
        public int UserId { get; set; }
        public Nullable<int> Hp { get; set; }
        public Nullable<int> AP { get; set; }
        public Nullable<int> Dp { get; set; }
        public Nullable<int> Steps { get; set; }
        public Nullable<int> Gold { get; set; }
    
        public virtual User User { get; set; }
    }
}
