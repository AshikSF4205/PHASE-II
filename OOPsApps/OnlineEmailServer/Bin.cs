using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEmailServer
{
    /// <summary>
    /// Used to contain Bin  details
    /// </summary>
    public class Bin
    {
        // field
        /// <summary>
        /// Static field used for auto-increment and it uniquely identify an instance <see cref="Bin"/> class 
        /// For further reference, click <see href="www.syncfusion.com" > Syncfusion </see>
        /// </summary>
        private static int s_id = 000;
        /// <summary>
        /// Private field used to access the bin ID property
        /// </summary>
        private string _binID;

        // property
        /// <summary>
        /// Property name used to provide ID for a bin in a object of <see cref="bin"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string BinID { get{
            return _binID;
        } }
        /// <summary>
        /// Property name used to provide from mail ID for a bin in a object of <see cref="bin"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string FromMailID { get; set; }
        /// <summary>
        /// Property name used to provide To mail ID for a bin in a object of <see cref="bin"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string ToMailID { get; set; }
        /// <summary>
        /// Property name used to provide Subject for a bin in a object of <see cref="bin"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string Subject { get; set; }
        /// <summary>
        /// Property name used to provide Description for a bin in a object of <see cref="bin"/> Class's object 
        /// </summary>
        /// <value>It requires string value</value>
        public string Description { get; set; }
        /// <summary>
        /// Property name used to provide Datetime for a bin in a object of <see cref="bin"/> Class's object 
        /// </summary>
        /// <value>It requires DateTime value</value>
        public DateTime DateMailed { get; set; }
        /// <summary>
        /// Property name used to provide status for a bin in a object of <see cref="bin"/> Class's object 
        /// </summary>
        /// <value>It requires StatusEnum value</value>
        public StatusEnum Status { get; set;}

        // constructor
        /// <summary>
        /// Constructor used to get Bin details
        /// </summary>
        /// <param name="fromMailID"></param>
        /// <param name="toMailID"></param>
        /// <param name="subject"></param>
        /// <param name="description"></param>
        /// <param name="dateMailed"></param>
        /// <param name="status"></param>
        public Bin(string fromMailID, string toMailID, string subject, string description, DateTime dateMailed, StatusEnum status){
            s_id++;
            _binID = "B"+s_id;
            FromMailID = fromMailID;
            ToMailID = toMailID;
            Subject = subject;
            Description =  description;
            DateMailed = dateMailed;
            Status = status;
        }
    }
}
