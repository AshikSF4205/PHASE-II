using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineHospitalManagement
{
    public class DoctorDetails
    {
        private static int s_id = 300;
        private string _doctorID;

        public string DoctorID
        {
            get
            {
                return _doctorID;
            }
        }
        public string DoctorName { get; set; }
        public int Experience { get; set; }
        public string Specialization { get; set; }
        public double Fees { get; set; }
        public List<string> AvailableSlotsList { get; set; }

        public DoctorDetails(string doctorName, int experience, string specialization, double fees, List<string> availableSlotsList)
        {
            _doctorID = $"DID{++s_id}";
            DoctorName = doctorName;
            Experience = experience;
            Specialization = specialization;
            Fees = fees;
            AvailableSlotsList = availableSlotsList;
        }
    }
}