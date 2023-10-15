using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace EmployeePayrollManagement
{

    public enum Gender { Select, Male, Female }
    public enum Location { Select, Chennai, Bangalore, Hyderabad, Mumbai };

    public class EmployeeDetails
    {

        private static int _empID = 1000;

        private string _employeeID;

        public string EmployeeID
        {
            get
            {
                return _employeeID;
            }
        }

        public string Name { get; set; }
        public string Role { get; set; }
        public Location Location { get; set; }
        public string TeamName { get; set; }
        public DateTime DOJ { get; set; }
        public int DaysWorked { get; set; }
        public int LeaveTaken { get; set; }
        public Gender Gender { get; set; }

        public double CalculateSalary()
        {
            return (DaysWorked - LeaveTaken) * 500;
        }

        public EmployeeDetails(string name, string role, Location location, string teamName, DateTime doj, int daysWorked, int leaveTaken, Gender gender)
        {
            _employeeID = $"SF{++_empID}";
            Name = name;
            Role = role;
            Location = location;
            TeamName = teamName;
            DOJ = doj;
            DaysWorked = daysWorked;
            LeaveTaken = leaveTaken;
            Gender = gender;
        }
    }
}