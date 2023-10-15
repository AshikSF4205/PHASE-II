using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEmailServer
{
    /// <summary>
    /// Used to contain SentItems  details
    /// </summary>
    public class SentItems
    {
        // field
        /// <summary>
        /// Static field used for auto-increment and it uniquely identify an instance <see cref="SentItems"/> class 
        /// For further reference, click <see href="www.syncfusion.com" > Syncfusion </see>
        /// </summary>
        private static int s_id = 100;
        /// <summary>
        /// Private field used to access the sentmailNumber property
        /// </summary>
        private string _sentMailNumber;

        // property
        
        /// <summary>
        /// Property name used to provide sent mail number for a sent items in a object of <see cref="SentItems"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string SentMailNumber { get{
            return _sentMailNumber;
        } }
        /// <summary>
        /// Property name used to provide fromID for a sent items in a object of <see cref="SentItems"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string FromID { get; set; }
        /// <summary>
        /// Property name used to provide ToID for a sent items in a object of <see cref="SentItems"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string ToID { get; set; }
        /// <summary>
        /// Property name used to provide DateTime for a sent items in a object of <see cref="SentItems"/> Class's object 
        /// </summary>
        /// <value>It requires DateTime value</value>
        public DateTime Date { get; set; }
        /// <summary>
        /// Property name used to provide subject for a sent items in a object of <see cref="SentItems"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string Subject { get; set; }
        /// <summary>
        /// Property name used to provide description for a sent items in a object of <see cref="SentItems"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string Description { get; set; }

        // constructor
        /// <summary>
        /// Constructor used to get Send Items details
        /// </summary>
        /// <param name="fromID"></param>
        /// <param name="toID"></param>
        /// <param name="date"></param>
        /// <param name="subject"></param>
        /// <param name="description"></param>
        public SentItems(string fromID, string toID, DateTime date, string subject, string description){
            s_id++;
            _sentMailNumber = "SM"+s_id;
            FromID = fromID;
            ToID = toID;
            Date = date;
            Subject = subject;
            Description = description;
        }
    }
}

