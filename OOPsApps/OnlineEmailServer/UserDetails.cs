using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEmailServer
{
    public enum GenderEnum{Male,Female,Other}
    /// <summary>
    /// Used to contain userDetails  details
    /// </summary>
    public class UserDetails
    {
        // property
        /// <summary>
        /// Property name used to provide Name for a Userdetails in a object of <see cref="UserDetails"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string Name { get; set; }
        /// <summary>
        /// Property name used to provide FatherName for a Userdetails in a object of <see cref="UserDetails"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string FatherName { get; set; }
        /// <summary>
        /// Property name used to provide DOB for a Userdetails in a object of <see cref="UserDetails"/> Class's object 
        /// </summary>
        /// <value>It requires DateTime value</value>
        public DateTime DOB { get; set; }
        /// <summary>
        /// Property name used to provide Phone Number for a Userdetails in a object of <see cref="UserDetails"/> Class's object 
        /// </summary>
        /// <value>It requires long value</value>
        public long PhoneNumber { get; set; }
        /// <summary>
        /// Property name used to provide Gender for a Userdetails in a object of <see cref="UserDetails"/> Class's object 
        /// </summary>
        /// <value>It requires GenderEnum value</value>
        public GenderEnum Gender { get; set; }
        /// <summary>
        /// Property name used to provide mailId for a Userdetails in a object of <see cref="UserDetails"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string PreferredMailID{ get; set; }
        /// <summary>
        /// Property name used to provide Password for a Userdetails in a object of <see cref="UserDetails"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string Password { get; set; }

        // constructor
        /// <summary>
        /// Constructor used to get user details
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fatherName"></param>
        /// <param name="dob"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="gender"></param>
        /// <param name="preferredMailID"></param>
        /// <param name="password"></param>
        public UserDetails(string name, string fatherName, DateTime dob, long phoneNumber, GenderEnum gender, string preferredMailID, string password){
            Name = name;
            FatherName = fatherName;
            DOB = dob;
            PhoneNumber = phoneNumber;
            Gender = gender;
            PreferredMailID = preferredMailID;
            Password = password;

        }
    }
}
