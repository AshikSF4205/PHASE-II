using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class ProductDetails
    {
        /*
       Details Needed
       •	ProductID (Auto Increment – PID101)
       •	ProductName
       •	Price
       •	Stock 
       •	ShippingDuration
       */

        //Fields
        private static int s_id = 100;

        private string _productId;

        //Properties
        public string Ecommerce { get; set; }
        public string ProductID
        {
            get
            {
                return _productId;
            }
        }

        public string ProductName { get; set; }

        public int Stock { get; set; }

        public double Price { get; set; }

        public int ShippingDuration { get; set; }
        
        //Constructor
        public ProductDetails() { }

        public ProductDetails(string productName, int stock, double price, int shippingDuration)
        {

            Ecommerce = "SynCart";
            s_id++;
            _productId = "PID" + s_id;
            ProductName = productName;
            Stock = stock;
            Price = price;
            ShippingDuration = shippingDuration;

        }

    }
}