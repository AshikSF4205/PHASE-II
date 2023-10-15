using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineHospitalManagement
{
    public enum Gender{Select, Male, Female}
    public class PatientDetails
    {
        private static int s_id = 1000;
        private string _patientID;

        public string PatientID
        {
            get
            {
                return _patientID;
            }
        }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public double WalletBalance { get; set; }

        public PatientDetails(string patientName, int age, Gender gender, double walletBalance)
        {
            _patientID = $"PID{++s_id}";
            PatientName = patientName;
            Age = age;
            Gender = gender;
            WalletBalance = walletBalance;
        }
    }
}