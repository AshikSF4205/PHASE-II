using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEmailServer
{
    public enum StatusEnum{Read, Unread, Delete}
    /// <summary>
    /// Used to contain MaiLBox  details
    /// </summary>
    public class MailBox
    {
        // field
        /// <summary>
        /// Static field used for auto-increment and it uniquely identify an instance <see cref="MailBox"/> class 
        /// For further reference, click <see href="www.syncfusion.com" > Syncfusion </see>
        /// </summary>
        private static int s_id = 500;
        /// <summary>
        /// Private field used to access the MailNumber property
        /// </summary>
        private string _mailNumber;

        // property
        /// <summary>
        /// Property name used to provide mail number for a MailBox in a object of <see cref="MailBox"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string MailNumber { get{
            return _mailNumber;
        }}
        /// <summary>
        /// Property name used to provide fromMailId for a MailBox in a object of <see cref="MailBox"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string FromMailID { get; set; }
        /// <summary>
        /// Property name used to provide TomailId  for a MailBox in a object of <see cref="MailBox"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string ToMailID { get; set; }
        /// <summary>
        /// Property name used to provide Subject for a MailBox in a object of <see cref="MailBox"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string Subject { get; set; }
        /// <summary>
        /// Property name used to provide Description for a MailBox in a object of <see cref="MailBox"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string Description { get; set; }
        /// <summary>
        /// Property name used to provide Date mailed for a MailBox in a object of <see cref="MailBox"/> Class's object 
        /// </summary>
        /// <value>It requires DateTime value</value>
        public DateTime DateMailed { get; set; }
        /// <summary>
        /// Property name used to provide status for a MailBox in a object of <see cref="MailBox"/> Class's object 
        /// </summary>
        /// <value>It requires StatusEnum value</value>
        public StatusEnum Status { get; set; }

        // constructor
        /// <summary>
        /// Constructor used to get Mail Box details
        /// </summary>
        /// <param name="fromMailID"></param>
        /// <param name="toMailID"></param>
        /// <param name="subject"></param>
        /// <param name="description"></param>
        /// <param name="dateMailed"></param>
        /// <param name="status"></param>
        public MailBox(string fromMailID, string toMailID, string subject, string description, DateTime dateMailed, StatusEnum status){
            s_id++;
            _mailNumber = "MN"+s_id;
            FromMailID = fromMailID;
            ToMailID = toMailID;
            Subject = subject;
            Description =  description;
            DateMailed = dateMailed;
            Status = status;
        }
    }
}
