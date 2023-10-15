using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Used to contain college admission application and its elements.
/// </summary>
namespace CollegeAdmission
{

    /// <summary>
    /// Used to select gender
    /// </summary>
    public enum GenderEnum { Select, Male, Female, Other }
    /// <summary>
    /// class<see cref="StudentDetails"/> Used to collect student details to admission process.
    /// </summary>
    public class StudentDetails
    {
        //Field

        /// <summary>
        /// Static feild used to auto increment and it uniquely identify an instance of
        /// <see cref="StudentDetails"/> class
        /// For furthur reference, click <see href="www.syncfusion.com">Syncfusion</see>
        /// </summary>
        private static int s_id = 1000;

        /// <summary>
        /// Private used to access the student id property
        /// </summary>
        private string _studentId;

        //Properties
        public string StudentId
        {
            get
            {
                return _studentId;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string StudentName { get; set; }

        public string FatherName { get; set; }

        public DateTime DOB { get; set; }

        public string CollegeName { get; set; }

        public int PhysicsMark { get; set; }

        public int ChemistryMark { get; set; }

        public int MathsMark { get; set; }

        public GenderEnum Gender { get; set; }

        //Constructor
        public StudentDetails(string name, string fatherName, DateTime dob, int phyMark, int chemMark, int matMark, GenderEnum gender)
        {
            s_id++;
            _studentId = "SF" + s_id;
            StudentName = name;
            FatherName = fatherName;
            DOB = dob;
            CollegeName = "Loyola";
            PhysicsMark = phyMark;
            ChemistryMark = chemMark;
            MathsMark = matMark;
            Gender = gender;


        }

        public StudentDetails()
        {

        }

        public int TotalMarks()
        {
            return PhysicsMark + ChemistryMark + MathsMark;
        }

        public bool IsEligible()
        {
            return (TotalMarks() / 3) >= 75;
        }



    }
}