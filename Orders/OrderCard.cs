using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Orders
{
    class OrderCard
    {
        bool status;
        DateTime date_out;
        string order_composition;
        string delivery_method;
        string communication_method;
        double order_amount;
        double delivery_amount;
        double prepayment;
        string celebration;
        DateTime date_in;

        public bool Status { get; set; }
        DateTime DateOut { get; set; }
        public string OrderComposition { get; set; }
        public string DeliveryMethod { get; set; }
        
        public double OrderAmount { get; set; }
        public double DeliveryAmount { get; set; }
        public double Prepayment { get; set; }
        public string Celebration { get; set; }
        public DateTime DateIn { get; set; }

        public OrderCard() { }



    }
}
