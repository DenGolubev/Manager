//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Manager
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public bool status { get; set; }
        public System.DateTime date_out { get; set; }
        public string order_composition { get; set; }
        public string delivery_method { get; set; }
        public string communication_method { get; set; }
        public decimal order_amount { get; set; }
        public decimal delivery_amount { get; set; }
        public decimal prepayment { get; set; }
        public string celebration { get; set; }
        public System.DateTime date_in { get; set; }
        public int customer_id { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
