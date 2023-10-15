using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{

    public enum OrderStatusEnum { Default, Ordered, Cancelled }
    public class OrderDetails
    {
        /*
       Details Needed
       •	OrderID (Auto Increment – OID1001)
       •	CustomerID
       •	ProductID
       •	TotalPrice 
       •	PurchaseDate
       •	Quantity
       •	OrderStatus – (Enum- Default, Ordered, Cancelled)

       */

        //Fields
        private static int s_id = 1000;

        private string _orderId;

        //Properties
        public string Ecommerce { get; set; }

        public string OrderID
        {
            get
            {
                return _orderId;
            }
        }

        public string CustomerID { get; set; }

        public string ProductID { get; set; }

        public int Quantity { get; set; }

        public double TotalPrice { get; set; }

        public DateTime PurchaseDate { get; set; }

        public OrderStatusEnum OrderStatus { get; set; }

        //Constructor
        public OrderDetails() { }

        public OrderDetails(string customerID, string productID, int count, double totalPrice, DateTime purchaseDate, OrderStatusEnum orderStatus)
        {


            Ecommerce = "SynCart";
            s_id++;
            _orderId = "OID" + s_id;
            CustomerID = customerID;
            ProductID = productID;
            Quantity = count;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            OrderStatus = orderStatus;

        }

    }
}