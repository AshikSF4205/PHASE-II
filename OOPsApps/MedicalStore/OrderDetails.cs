using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    public enum OrderStatusEnum { Purchased = 1, Cancelled = 2 }
    public class OrderDetails
    {
        /*
       Details Needed
       a.OrderID (OID2001)
       b.UserID
       c.MedicineID
       d.MedicineCount
       e.TotalPrice
       f.OrderDate
       g.OrderStatus {Enum – Purchased, Cancelled}
       */

        //Fields
        private static int s_id = 2000;

        private string _orderId;

        //Properties
        public string MedicalStore { get; set; }

        public string OrderID
        {
            get
            {
                return _orderId;
            }
        }

        public string UserID { get; set; }

        public string MedicineID { get; set; }

        public int MedicineCount { get; set; }

        public double TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatusEnum OrderStatus { get; set; }

        //Constructor
        public OrderDetails() { }

        public OrderDetails(string userId, string medicineId, int medicineCount, double totalPrice, DateTime orderDate, OrderStatusEnum orderStatus)
        {


            MedicalStore = "Syncfusion";
            s_id++;
            _orderId = "UID" + s_id;
            UserID = userId;
            MedicineID = medicineId;
            MedicineCount = medicineCount;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            OrderStatus = orderStatus;

        }

    }
}