using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Orders
{
    public class Order
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
        double cake_price;
        double total_price;
        string celebration;
        DateTime date_in;
        int customer_id;

        public bool Status { get { return status; } set { status = value; } } //Статус выполнения
        public DateTime DateOut { get { return date_out; } set { date_out = value; } } //Дата готовности
        public string OrderComposition { get { return order_composition; } set { order_composition = value; } } //Состав заказа
        public string DeliveryMethod { get { return delivery_method; } set { delivery_method = value; } } //Способ доставки
        public string CommunicationMethod { get { return communication_method; } set { communication_method = value; } } //Способ связи
        public double OrderAmount { get { return order_amount; } set { order_amount = value; } } //Сумма заказа
        public double DeliveryAmount { get { return delivery_amount; } set { delivery_amount = value; } } // Стоимость доставки
        public double Prepayment { get { return prepayment; } set { prepayment = value; } } //Предоплата
        public double CakePrice { get { return cake_price; } set { cake_price = value; } } //Стоимость торта
        public double TotalPrice { get { return total_price; } set { total_price = value; } } //Всего к оплате
        public string Celebration { get { return celebration; } set { celebration = value; } } //На какое тожество
        public DateTime DateIn { get { return date_in; } set { date_in = value; } } //Дата поступления
        public int CustomerId { get { return customer_id; } set { customer_id = value; } } //id Покупателя

        public Order() { }

        public Order( DateTime date_out, string order_composition, string delivery_method, string communication_method, double order_amount, double delivery_amount, double prepayment, double cake_price, double total_price,
            string celebration,DateTime date_in, int customer_id, bool status = false)
        {
            this.status = status; 
            this.date_out = date_out; this.order_composition = order_composition; this.delivery_method = delivery_method; this.communication_method = communication_method;
            this.order_amount = order_amount; this.delivery_amount = delivery_amount; this.prepayment = prepayment; this.cake_price = cake_price; this.total_price = total_price; this.celebration = celebration; this.date_in = date_in; this.customer_id = customer_id;
        }
    }
}
