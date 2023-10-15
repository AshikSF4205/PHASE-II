using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Used to contain the Syncfusion Adventure Park Ride Ticketing Application and its elements.
/// </summary>
namespace AdventureParkTicketApp
{
    /// <summary>
    /// class <see cref="UserDetails"/> Used to collect User Details for Syncfusion Adventure Park Ride Ticketing Application.
    /// </summary>
    public class UserDetails
    {

        /*
        •	CardID (Auto Increment - CID1001)
        •	UserName
        •	Age
        •	Weight
        •	PhoneNumber
        •	WalletBalance

        */

        //Fields
        /// <summary>
        /// Static field used to auto increment and it uniquely identify and instance of
        /// <see cref="UserDetails"/> class
        /// For further reference, click <see href="www.syncfusion.com"> Syncfusion </see>
        /// </summary>
        private static int s_id = 1000;

        /// <summary>
        /// Private field used to access the User's Card ID property.
        /// </summary>
        private string _cardId;

        //Properties
        public string Park { get; set; }

        public string CardID
        {
            get
            {
                return _cardId;
            }
        }

        /// <summary>
        /// Property UserName used to provide name for a user in a object of <see cref="UserDetails"/> class's object.
        /// </summary>
        /// <value>It requires string value.</value>
        public string UserName { get; set; }

        /// <summary>
        /// Property Age used to provide age of a user in a object of <see cref="UserDetails"/> class's object.
        /// </summary>
        /// <value>It requires a int value.</value>
        public int Age { get; set; }

        /// <summary>
        /// Property Weight used to provide weight of a user in a object of <see cref="UserDetails"/> class's object
        /// </summary>
        /// <value>It requires a double value.</value>
        public double Weight { get; set; }

        /// <summary>
        /// Property PhoneNumber used to provide phone number of a user in a object of <see cref="UserDetails"/> class's object.
        /// </summary>
        /// <value>It requires a long value.</value>
        public long PhoneNumber { get; set; }

        /// <summary>
        /// Property WalletBalance used to provide money wallet balance of a user in a object of <see cref="UserDetails"/> class's object.
        /// </summary>
        /// <value>It requires a double value.</value>
        public double WalletBalance { get; set; }

        //Constructors

        //Default Constructor
        public UserDetails() { }


        /// <summary>
        /// Constructor of <see cref="UserDetails"/> class used to initiate value to its properties.
        /// </summary>
        /// <param name="name">Parameter name used to initiate a user's name to its property.</param>
        /// <param name="age">Parameter fatherName used to initiate a user's age to its property.</param>
        /// <param name="weight">Parameter dob used to initiate a user's weight to its property.</param>
        /// <param name="phoneNumber">Parameter gender used to inititate a user's phone number to its property.</param>
        /// <param name=" walletBalance">Parameter math used to inititate a user's wallet balance to its property.</param>
        public UserDetails(string name, int age, double weight, long phoneNumber, double walletBalance)
        {


            Park = "Syncfusion Adventure Park";
            s_id++;
            _cardId = "CID" + s_id;
            UserName = name;
            Age = age;
            Weight = weight;
            PhoneNumber = phoneNumber;
            WalletBalance = walletBalance;

        }


        //Methods
        /// <summary>
        /// Method WalletRecharge used to Reacharge User's Wallet.
        /// </summary>
        /// <param name="amount">Parameter amount used to provide amount to be recharged to the wallet.</param>
        public void WalletRecharge(double amount)
        {
            WalletBalance += amount;
        }

        /// <summary>
        /// Method DeductBalance used to Deduce amount from User's Wallet.
        /// </summary>
        /// <param name="amount">Parameter amount used to provide amount to be deduced from the wallet.</param>
        public void DeductBalance(double amount)
        {
            WalletBalance -= amount;
        }
    }
}

