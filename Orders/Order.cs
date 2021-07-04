using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Orders
{
    class Order
    {
        public int id { get; set; }
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
        int customer_id;

        public bool Status => status; //Статус выполнения
        public DateTime DateOut => date_out; //Дата готовности
        public string OrderComposition => order_composition; //Состав заказа
        public string DeliveryMethod => delivery_method; //Способ доставки
        public string CommunicationMethod => communication_method; //Способ связи
        public double OrderAmount => order_amount; //Сумма заказа
        public double DeliveryAmount => delivery_amount; // Стоимость доставки
        public double Prepayment => prepayment; //Предоплата
        public string Celebration => celebration; //На какое тожество
        public DateTime DateIn => date_in; //Дата поступления
        public int CustomerId => customer_id; //id Покупателя


        public Order(bool status, DateTime date_out, string order_composition, string delivery_method, string communication_method, double order_amount, double delivery_amount, double prepayment, string celebration,
            DateTime date_in, int customer_id)
        {
            this.status = status; this.date_out = date_out; this.order_composition = order_composition; this.delivery_method = delivery_method; this.communication_method = communication_method;
            this.order_amount = order_amount; this.delivery_amount = delivery_amount; this.prepayment = prepayment; this.celebration = celebration; this.date_in = date_in; this.customer_id = customer_id;
        }



    }
}
