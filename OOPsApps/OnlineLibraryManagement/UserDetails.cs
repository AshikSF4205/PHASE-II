using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public enum GenderEnum{Male,Female,Other};
    public enum DepartmentEnum{ECE,EEE,CSE};
    
    /// <summary>
    /// Class used to UserDetails Datatype creation
    /// </summary>
    public class UserDetails
    {
        // Field
        /// <summary>
        /// Static field for auto-incrementing the user id <see cref="UserDetails"/> class
        /// </summary>
        private static int s_id=3000;
        /// <summary>
        /// Static field for return the user id <see cref="UserDetails"/> class
        /// </summary>
        private string _userId;

        // property
        /// <summary>
        /// Property name used to get userId
        /// </summary>
        /// <value>string returnType</value>
        public string UserId { get{
            return _userId;
        } }
        // property
        /// <summary>
        /// Property name used to get user name
        /// </summary>
        /// <value>string returnType</value>
        public string UserName { get; set; }
        // property
        /// <summary>
        /// Property name used to get gender
        /// </summary>
        /// <value>GenderEnum returnType</value>
        public GenderEnum Gender{get; set; }
        // property
        /// <summary>
        /// Property name used to get department
        /// </summary>
        /// <value>DepartmentEnum returnType</value>
        public DepartmentEnum Department{get; set; }
        // property
        /// <summary>
        /// Property name used to get Mobile number
        /// </summary>
        /// <value>long returnType</value>
        public long MobileNumber{get; set; }
        // property
        /// <summary>
        /// Property name used to get mailId
        /// </summary>
        /// <value>string returnType</value>
        public string MailId{get; set; }
        // property
        /// <summary>
        /// Property name used to get wallet balance
        /// </summary>
        /// <value>double returnType</value>
        public double WalletBalance{get; set; }

        // constructor
        /// <summary>
        /// string userName, GenderEnum gender, DepartmentEnum department, long mobileNumber, string mailId, double walletBalance
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="gender"></param>
        /// <param name="department"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="mailId"></param>
        /// <param name="walletBalance"></param>
        public UserDetails(string userName, GenderEnum gender, DepartmentEnum department, long mobileNumber, string mailId, double walletBalance){
            s_id++;
            _userId = "SF"+s_id;
            UserName = userName;
            Gender = gender;
            Department = department;
            MobileNumber = mobileNumber;
            MailId = mailId;
            WalletBalance = walletBalance;

        }

        // Method for recharging the wallet
        /// <summary>
        /// Method used to recharge the wallet
        /// </summary>
        /// <param name="rechargeAmount"></param>
        public void WalletRecharge(double rechargeAmount){
            WalletBalance += rechargeAmount;
        }

        // Method for deducting amount from wallet
        /// <summary>
        /// Method used to deduct the balance
        /// </summary>
        /// <param name="deductAmount"></param>
        public void DeductBalance(double deductAmount){
            WalletBalance -= deductAmount;
        }
    }
}