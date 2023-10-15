using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Used to contain the Syncfusion Adventure Park Ride Ticketing Application and its elements.
/// </summary>
namespace AdventureParkTicketApp
{
    /// <summary>
    /// used to select Ride Booking Status information.
    /// </summary>
    public enum RideStatusEnum { Default, Booked, Cancelled }

    /// <summary>
    /// class <see cref="RideHistoryDetails"/>Used to collect User's Ride Details of Syncfusion Adventure Park Ride Ticketing Application.
    /// </summary>
    public class RideHistoryDetails
    {
        /*
        •	RideHistoryID (Auto Increment -RHID5001)
        •	CardID
        •	RideID
        •	RideType (Fetch the Enum value From Ride List)
        •	RideTime (Time when the user can take the ride)
        •	RideStatus (Enum – Default, Booked, Cancelled)
        */

        //Fields
        /// <summary>
        /// Static field used to auto increment and it uniquely identify and instance of
        /// <see cref="RideHistoryDetails"/> class
        /// For further reference, click <see href="www.syncfusion.com"> Syncfusion </see>
        /// </summary>
        private static int s_id = 5000;

        private string _rideHisId;

        //Properties
        public string Park { get; set; }

        public string RideHistoryID
        {
            get
            {
                return _rideHisId;
            }
        }

        /// <summary>
        /// Property CardID used to provide user's card id in a object of <see cref="RideHistoryDetails"/> class's object.
        /// </summary>
        /// <value>It requires double value.</value>
        public string CardID { get; set; }

        /// <summary>
        /// Property RideID used to provide ride id in a object of <see cref="RideHistoryDetails"/> class's object.
        /// </summary>
        /// <value>It requires double value.</value>
        public string RideID { get; set; }

        /// <summary>
        /// Property RideType used to provide ride type in a object of <see cref="RideHistoryDetails"/> class's object.
        /// </summary>
        /// <value>It requires double value.</value>
        public RideTypeEnum RideType { get; set; }

        /// <summary>
        /// Property RideTime used to provide ride start time in a object of <see cref="RideHistoryDetails"/> class's object.
        /// </summary>
        /// <value>It requires double value.</value>
        public DateTime RideTime { get; set; }

        /// <summary>
        /// Property RideStatus used to provide ride booking status in a object of <see cref="RideHistoryDetails"/> class's object.
        /// </summary>
        /// <value>It requires RideStatusEnum value.</value>
        public RideStatusEnum RideStatus { get; set; }

        //Constructor

        //Default Constructor
        public RideHistoryDetails() { }

        /// <summary>
        /// Constructor of <see cref="RideDetails"/> class used to initiate value to its properties.
        /// </summary>
        /// <param name="cardID">Parameter rideName used to initiate user card ID to its property.</param>
        /// <param name="rideID">Parameter rideID used to initiate ride ID to its property.</param>
        /// <param name="rideType">Parameter rideType used to initiate type of the ride to its property.</param>
        /// <param name="rideTime">Parameter rideTime used to inititate start time of a ride to its property.</param>
        /// <param name="rideStatus">Parameter rideStatus used to initiate ride booking status of a ride to its property.</param>

        public RideHistoryDetails(string cardID, string rideID, RideTypeEnum rideType, DateTime rideTime, RideStatusEnum rideStatus)
        {

            Park = "Syncfusion Adventure Park";
            s_id++;
            _rideHisId = "RHID" + s_id;
            CardID = cardID;
            RideID = rideID;
            RideType = rideType;
            RideTime = rideTime;
            RideStatus = rideStatus;

        }

    }
}
