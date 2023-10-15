using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbBillCalculator
{
    public class UserDetails
    {
        //Fields
        private static int s_id = 1000;

        private string _userId;

        //Properties


        public string MeterID
        {
            get
            {
                return _userId;
            }
        }

        public string UserName { get; set; }

        public long PhoneNumber { get; set; }

        public int Age { get; set; }

        public string MailId { get; set; }

        public double Units { get; set; }

        public double Amount { get; set; }

        //Constructor
        public UserDetails() { }

        public UserDetails(string userName, long phoneNumber, string mailId)
        {

            s_id++;
            _userId = "EB" + s_id;
            UserName = userName;
            PhoneNumber = phoneNumber;
            MailId = mailId;
            Units = 0;
            Amount = 0;

        }

        public double CalculateAmount(double units)
        {

            return units * 5;

        }
    }
}