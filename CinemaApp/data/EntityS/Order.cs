//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaApp.data.EntityS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int id_Order { get; set; }
        public int id_User { get; set; }
        public Nullable<decimal> Grand_Total { get; set; }
        public string Order_Details { get; set; }
        public int id_Ticket { get; set; }
        public string id_Session { get; set; }
    
        public virtual Ticket Ticket { get; set; }
    }
}
