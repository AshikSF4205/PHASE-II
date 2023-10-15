using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    public class UserDetails
    {

        /*
        Details Needed
        a.UserID(UID1001)
        b.UserName
        c.Age
        d.City
        e.PhoneNumber
        f.Balance
        */

        //Fields
        private static int s_id = 1000;

        private string _userId;
        
        //Properties
        public string MedicalStore { get; set; }
        
        public string UserID
        {
            get
            {
                return _userId;
            }
        }

        public string UserName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public long PhoneNumber { get; set; }

        public double Balance { get; set; }

        //Constructor
        public UserDetails() { }

        public UserDetails(string userName, int age, string city, long phoneNumber, double balance)
        {


            MedicalStore = "Syncfusion";
            s_id++;
            _userId = "UID" + s_id;
            UserName = userName;
            Age = age;
            City = city;
            PhoneNumber = phoneNumber;
            Balance = balance;

        }

    }
}