using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    public class MedicineDetails
    {
        /*
       Details Needed
       a.MedicineID (MD100)
       b.MedicineName
       c.AvailableCount
       d.Price
       e.DateOfExpiry
       */

        //Fields
        private static int s_id = 100;

        private string _medId;

        //Properties
        public string MedicalStore { get; set; }

        public string MedicineID
        {
            get
            {
                return _medId;
            }
        }

        public string MedicineName { get; set; }

        public int AvailableCount { get; set; }

        public double Price { get; set; }

        public DateTime DateOfExpiry { get; set; }

        //Constructor
        public MedicineDetails() { }

        public MedicineDetails(string medicineName, int availableCount, double price, DateTime dateOfExpiry)
        {

            MedicalStore = "Syncfusion";
            s_id++;
            _medId = "MD" + s_id;
            MedicineName = medicineName;
            AvailableCount = availableCount;
            Price = price;
            DateOfExpiry = dateOfExpiry;

        }

    }
}