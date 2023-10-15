using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApplication
{
    public class CustomerDetails
    {

        //Fields
        private static int s_id = 1000;
        private string _customerId;
        
        //Properties
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string IFSC { get; set; }
        public string CustomerId
        {
            get
            {
                return _customerId;
            }
        }

        public string CustomerName { get; set; }

        public double Balance { get; set; }

        public long PhoneNumber { get; set; }

        public string MailId { get; set; }

        public DateTime DOB { get; set; }

        public GenderEnum Gender { get; set; }

        public CustomerDetails() { }

        public CustomerDetails(string customerName, long phoneNumber, string mailId, DateTime dob, GenderEnum gender, double balance)
        {


            Bank = "HDFC BANK";
            Branch = "Syncfusion";
            IFSC = "HDFC0000124";
            s_id++;
            _customerId = "HDFC" + s_id;
            CustomerName = customerName;
            PhoneNumber = phoneNumber;
            MailId = mailId;
            DOB = dob;
            Gender = gender;
            Balance = balance;

        }

        public double Deposit(double amountToBeDeposited)
        {
            return Math.Round(Balance + amountToBeDeposited, 2);
        }

        public double Withdraw(double amountToBeWithdrawed)
        {
            return Math.Round(Balance - amountToBeWithdrawed);
        }

    }
}