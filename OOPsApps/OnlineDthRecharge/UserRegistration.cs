using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDthRecharge
{
    public class UserRegistration
    {
        private static int s_id=1000;
        public string UserId { get; set; }
        public string UserName { get; set; }
        public long MobileNuber { get; set; }
        public string  EmailId { get; set; }
        public double WalletBalance { get; set; }

        public UserRegistration(string userName,long mobileNumber,string emailId,double balance){
            UserId="UID"+(++s_id);
            UserName=userName;
            MobileNuber=mobileNumber;
            emailId=EmailId;
            WalletBalance=balance;
        }
        
    }
}