using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class CustomerDetails
    {

        /*
        Details Needed
        •	CustomerID (Auto Increment -CID1000)
        •	Name
        •	City
        •	MobileNumber
        •	WalletBalance
        •	EmailID

        */

        //Fields
        private static int s_id = 1000;

        private string _custId;

        //Properties
        public string Ecommerce { get; set; }

        public string CustomerID
        {
            get
            {
                return _custId;
            }
        }

        public string Name { get; set; }

        public string City { get; set; }

        public long MobileNumber { get; set; }

        public double WalletBalance { get; set; }

        public string EmailID { get; set; }

        //Constructor
        public CustomerDetails() { }

        public CustomerDetails(string name, string city, long mobileNumber, string emailID, double walletBalance)
        {


            Ecommerce = "SynCart";
            s_id++;
            _custId = "CID" + s_id;
            Name = name;
            City = city;
            MobileNumber = mobileNumber;
            WalletBalance = walletBalance;
            EmailID = emailID;

        }

        public void WalletRecharge(double amount)
        {

            WalletBalance += amount;

        }

        public void DeductBalance(double amount)
        {
            WalletBalance -= amount;
        }
    }
}
