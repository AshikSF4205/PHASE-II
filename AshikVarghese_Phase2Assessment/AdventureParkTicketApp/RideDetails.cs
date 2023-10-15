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
    /// used to select Ride Type information.
    /// </summary>
    public enum RideTypeEnum { Select, Water, Dry }

    /// <summary>
    /// class <see cref="RideDetails"/> Contains Ride Details of Syncfusion Adventure Park.
    /// </summary>
    public class RideDetails
    {
        /*
        •	RideID (Auto Increment – RID201)
        •	RideName
        •	RideType (Enum – Select/ Water/ Dry )
        •	MinAgeLimit
        •	MaxAgeLimit
        •	MinWeight
        •	MaxWeight
        •	RidePrice 
        */

        //Fields
        /// <summary>
        /// Static field used to auto increment and it uniquely identify and instance of
        /// <see cref="RideDetails"/> class
        /// For further reference, click <see href="www.syncfusion.com"> Syncfusion </see>
        /// </summary>
        private static int s_id = 200;

        /// <summary>
        /// Private field used to access the Ride ID property.
        /// </summary>
        private string _rideId;

        //Properties
        public string Park { get; set; }

        public string RideID
        {
            get
            {
                return _rideId;
            }
        }

        /// <summary>
        /// Property RideName used to provide name of a ride  in a object of <see cref="RideDetails"/> class's object.
        /// </summary>
        /// <value>It requires string value.</value>
        public string RideName { get; set; }

        /// <summary>
        /// Property RideType used to provide type of a ride in a object of <see cref="RideDetails"/> class's object.
        /// </summary>
        /// <value>It requires RideTypeEnum value.</value>
        public RideTypeEnum RideType { get; set; }

        /// <summary>
        /// Property MaxAgeLimit used to provide maximum age limit for a ride in a object of <see cref="RideDetails"/> class's object.
        /// </summary>
        /// <value>It requires int value.</value>
        public int MaxAgeLimit { get; set; }

        /// <summary>
        /// Property MinAgeLimit used to provide minimum age limit for a ride in a object of <see cref="RideDetails"/> class's object.
        /// </summary>
        /// <value>It requires int value.</value>
        public int MinAgeLimit { get; set; }

        /// <summary>
        /// Property MaxWeight used to provide maximum weight limit for a ride in a object of <see cref="RideDetails"/> class's object.
        /// </summary>
        /// <value>It requires double value.</value>
        public double MaxWeight { get; set; }

        /// <summary>
        /// Property MinWeight used to provide minimum weight limit for a ride in a object of <see cref="RideDetails"/> class's object.
        /// </summary>
        /// <value>It requires double value.</value>
        public double MinWeight { get; set; }

        /// <summary>
        /// Property RidePrice used to provide price of a ride in a object of <see cref="RideDetails"/> class's object.
        /// </summary>
        /// <value>It requires double value.</value>
        public double RidePrice { get; set; }


        //Constructor

        //Default Constructor
        public RideDetails() { }

        /// <summary>
        /// Constructor of <see cref="RideDetails"/> class used to initiate value to its properties.
        /// </summary>
        /// <param name="rideName">Parameter rideName used to initiate ride name to its property.</param>
        /// <param name="rideType">Parameter rideType used to initiate type of the ride to its property.</param>
        /// <param name="minAgeLimit">Parameter minAgeLimit used to initiate minimum age limit of a ride to its property.</param>
        /// <param name="maxAgeLimit">Parameter maxAgeLimit used to inititate maximum age limit of a ride to its property.</param>
        /// <param name="minWeight">Parameter minWeight used to initiate minimum weight limit of a ride to its property.</param>
        /// <param name="maxWeight">Parameter maxWeight used to inititate maximum weight limit of a rideto its property.</param>
        /// <param name="ridePrice">Parameter ridePrice used to inititate a ride's price to its property.</param>
        public RideDetails(string rideName, RideTypeEnum rideType, int minAgeLimit, int maxAgeLimit, double minWeight, double maxWeight, double ridePrice)
        {


            Park = "Syncfusion Adventure Park";
            s_id++;
            _rideId = "RID" + s_id;
            RideName = rideName;
            RideType = rideType;
            MinAgeLimit = minAgeLimit;
            MaxAgeLimit = maxAgeLimit;
            MaxWeight = maxWeight;
            MinWeight = minWeight;
            RidePrice = ridePrice;

        }

    }
}
