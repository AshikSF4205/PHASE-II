using System;

namespace OnlineHospitalManagement
{
    public enum AppointmentStatus{Select, Booked, Cancelled}
    public class AppointmentDetails
    {

        private static int s_id = 500;
        private string _appointmentID;

        public string AppointmentID
        {
            get
            {
                return _appointmentID;
            }
        }
        public string PatientID { get; set; }
        public string DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentSlot { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public double Fee { get; set; }

        public AppointmentDetails(string patientID, string doctorID, DateTime appointmentDate, string appointmentSlot, AppointmentStatus appointmentStatus, double fee)
        {
            _appointmentID = $"AID{++s_id}";
            PatientID = patientID;
            DoctorID = doctorID;
            AppointmentDate = appointmentDate;
            AppointmentSlot = appointmentSlot;
            AppointmentStatus = appointmentStatus;
            Fee = fee;
        }
    }
}