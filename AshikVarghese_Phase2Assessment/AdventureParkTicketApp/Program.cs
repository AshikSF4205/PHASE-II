using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;
using ConsoleTables;
namespace AdventureParkTicketApp;
class Program
{
    static List<UserDetails> userDetails = new List<UserDetails>();

    static List<RideDetails> rideDetails = new List<RideDetails>();

    static List<RideHistoryDetails> rideHistoryDetails = new List<RideHistoryDetails>();

    static UserDetails currentLoggedInUser;

    static int minsAddedToBookingTime = 30;

    public static void Main(string[] args)
    {

        DefaultDataLoading();

        System.Console.WriteLine("\n-----------------------------WELCOME TO SYNCFUSION THEME PARK-----------------------------");
        System.Console.WriteLine("|                                                                                        |");

        bool tryParseChecker, exitChecker = false;
        do
        {
            //Main Menu
            System.Console.WriteLine("1. User Registration \n2. User Login \n3. Exit");
            System.Console.Write("\nEnter the Appropriate digit: ");
            tryParseChecker = int.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    {
                        //Register
                        Registration();
                        break;
                    }
                case 2:
                    {
                        //Login
                        Login();
                        break;
                    }
                case 3:
                    {
                        //Exit
                        exitChecker = true;
                        System.Console.WriteLine("|                                                                                        |");
                        System.Console.WriteLine("----------------------------------THANK YOU VISIT AGAIN!----------------------------------");

                        break;
                    }
                default:
                    {
                        System.Console.WriteLine("INVALID ENTRY! [ENTER - 1/2/3]");
                        break;
                    }
            }
        } while (!(tryParseChecker && exitChecker));

    }

    static void DefaultDataLoading()
    {

        //User Data Loading
        userDetails.Add(new UserDetails("User 1", 5, 12, 9999999999, 500));
        userDetails.Add(new UserDetails("User 2", 13, 39, 8833884488, 300));
        userDetails.Add(new UserDetails("User 3", 45, 80, 7656635533, 600));
        userDetails.Add(new UserDetails("User 4", 30, 100, 8765774985, 100));
        userDetails.Add(new UserDetails("User 5", 20, 30, 9857646543, 1000));


        //Ride Data Loading
        rideDetails.Add(new RideDetails("Dry Game", RideTypeEnum.Dry, 5, 10, 12, 20, 50));
        rideDetails.Add(new RideDetails("Dry Game", RideTypeEnum.Dry, 10, 17, 20, 35, 100));
        rideDetails.Add(new RideDetails("Dry Game", RideTypeEnum.Dry, 18, 65, 35, 90, 200));
        rideDetails.Add(new RideDetails("Water Game", RideTypeEnum.Water, 5, 10, 12, 20, 50));
        rideDetails.Add(new RideDetails("Water Game", RideTypeEnum.Water, 10, 17, 20, 35, 100));
        rideDetails.Add(new RideDetails("Water Game", RideTypeEnum.Water, 18, 65, 35, 90, 200));

        //Ride History Data Loading
        rideHistoryDetails.Add(new RideHistoryDetails("CID1001", "RID201", RideTypeEnum.Dry, new DateTime(2023, 08, 08, 12, 15, 00), RideStatusEnum.Booked));
        rideHistoryDetails.Add(new RideHistoryDetails("CID1002", "RID205", RideTypeEnum.Water, new DateTime(2023, 08, 15, 14, 20, 00), RideStatusEnum.Booked));
        rideHistoryDetails.Add(new RideHistoryDetails("CID1003", "RID206", RideTypeEnum.Water, new DateTime(2023, 08, 27, 10, 45, 00), RideStatusEnum.Cancelled));
        rideHistoryDetails.Add(new RideHistoryDetails("CID1004", "RID203", RideTypeEnum.Dry, new DateTime(2023, 09, 07, 16, 30, 00), RideStatusEnum.Booked));
        rideHistoryDetails.Add(new RideHistoryDetails("CID1005", "RID206", RideTypeEnum.Water, new DateTime(2023, 09, 20, 15, 40, 00), RideStatusEnum.Cancelled));
    }

    public static void Registration()
    {
        System.Console.WriteLine("REGISTRATION IS SELECTED\n");

        //Getting Customer Details
        System.Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        while (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
        {
            System.Console.WriteLine("NUMBERS NOT ALLOWED!");
            System.Console.Write("Enter Valid Name: ");
            name = Console.ReadLine();

        }

        System.Console.Write("Enter Age: ");
        bool tempAge = int.TryParse(Console.ReadLine(), out int age);
        while (!(age > 0 & age < 120 & tempAge))
        {
            System.Console.WriteLine("INVALID AGE!");
            System.Console.Write("Enter Correct Age: ");
            tempAge = int.TryParse(Console.ReadLine(), out age);
        }

        System.Console.Write("Enter Weight: ");
        bool tempWeight = double.TryParse(Console.ReadLine(), out double weight);
        while (!(weight > 0 & weight < 250 & tempWeight))
        {
            System.Console.WriteLine("INVALID WEIGHT!");
            System.Console.Write("Enter Correct Weight: ");
            tempWeight = double.TryParse(Console.ReadLine(), out weight);
        }

        System.Console.Write("Enter Phone Number(10-digits): (+91) ");
        string phNo = Console.ReadLine();
        bool tempPhno = long.TryParse(phNo, out long phoneNumber);
        while (!(tempPhno && phNo.Length == 10))
        {
            System.Console.WriteLine("INVALID PHONE NUMBER!");
            System.Console.Write("Enter Correct Phone Number(10-digits): (+91) ");
            phNo = Console.ReadLine();
            tempPhno = long.TryParse(phNo, out phoneNumber);
        }

        System.Console.Write("Enter Initial Wallet Top-up in Rupees: Rs.");
        bool tempBal = double.TryParse(Console.ReadLine(), out double balance);
        while (!(tempBal && balance >= 50))
        {
            System.Console.WriteLine("INVALID AMOUNT!");
            System.Console.Write("Enter Correct Amount in Rupees (Amount should not be negative and minimum recharge is Rs. 50): Rs.");
            tempBal = double.TryParse(Console.ReadLine(), out balance);
        }

        //Saving User details in userDetails List
        UserDetails user = new UserDetails(name, age, weight, phoneNumber, balance);
        userDetails.Add(user);

        //Displaying Customer ID after completion of Registration
        System.Console.WriteLine("REGISTRATION SUCCESSFUL!");
        System.Console.WriteLine("\n--------------------------------\n");
        System.Console.WriteLine("YOUR CARD ID  IS " + user.CardID);
        System.Console.WriteLine("Please note down your CARD ID.");
        System.Console.WriteLine("\n---------------------------------\n");

    }

    public static void Login()
    {

        System.Console.WriteLine("LOGIN IS SELECTED\n");

        //Intial check for users in List
        if (userDetails.Count == 0)
        {
            System.Console.WriteLine("\n NO USER FOUND!");
            return;
        }


        bool flag = false;
        System.Console.WriteLine("Portal will ask for CARD ID till it is correct.\nSo,");
        string uId;
        do
        {

            System.Console.Write("Enter Valid Card Id: ");
            uId = Console.ReadLine();
            uId = uId.ToUpper();
            foreach (UserDetails record in userDetails)
            {

                if (uId.Equals(record.CardID))
                {
                    currentLoggedInUser = record;
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            if (flag) System.Console.WriteLine("INVALID CARD ID!");
        } while (flag);

        System.Console.WriteLine("\n---------------------------------------VALID CARD ID--------------------------------------");
        System.Console.WriteLine("\nLOGIN SUCESSFUL!\n");
        SubMenu();
    }

    public static void SubMenu()
    {
        bool tryParseChecker, exitChecker = false;
        do
        {
            //Sub Menu
            System.Console.WriteLine("\n1. Book Ride  \n2. Cancel Ride \n3. Wallet Recharge \n4. Ride History \n5. Wallet Balance \n6. Exit");
            System.Console.Write("\nEnter the Appropriate digit: ");
            tryParseChecker = int.TryParse(Console.ReadLine(), out int subOption);

            switch (subOption)
            {
                case 1:
                    {
                        BookRide();
                        break;
                    }
                case 2:
                    {
                        CancelRide();
                        break;
                    }
                case 3:
                    {
                        WalletRecharge();
                        break;
                    }
                case 4:
                    {
                        RideHistory();
                        break;
                    }
                case 5:
                    {
                        WalletBalance();
                        break;
                    }
                case 6:
                    {
                        //Exit
                        exitChecker = true;
                        System.Console.WriteLine("\nRedirecting back to MAIN MENU.....");
                        break;
                    }
                default:
                    {
                        System.Console.WriteLine("INVALID ENTRY! [ENTER - 1/2/3/4/5/6]");
                        break;
                    }
            }
        } while (!(tryParseChecker && exitChecker));



    }

    public static void BookRide()
    {

        System.Console.WriteLine("BOOK RIDE IS SELECTED\n");

        //Ride Table display
        var table = new ConsoleTable("RIDE ID", "RIDE NAME", "RIDE PRICE");
        foreach (RideDetails r in rideDetails)
        {
            table.AddRow(r.RideID, r.RideName, r.RidePrice);
        }
        System.Console.Write(table);
        System.Console.WriteLine();

        RideDetails ride = new RideDetails();
        bool flag = false;
        //Validating Ride ID
        do
        {
            System.Console.Write("\nSelect the ride by it's RIDE ID:");
            string rideId = Console.ReadLine();
            rideId = rideId.ToUpper();
            while (!rideId.Contains("RID"))
            {
                System.Console.WriteLine("INVALID RIDE ID!");
                System.Console.Write("Enter Correct RIDE ID from the table: ");
                rideId = Console.ReadLine().ToUpper();
            }

            foreach (RideDetails r in rideDetails)
            {
                if (rideId.Equals(r.RideID))
                {
                    ride = r;
                    flag = false;
                    break;
                }
                else
                {

                    flag = true;
                }
            }
            if (flag) System.Console.WriteLine("INVALID RIDE ID!");
        } while (flag);

        //Dry ride and Water ride switch
        switch (ride.RideType)
        {
            case RideTypeEnum.Dry:
                {
                    //Age Limit condition for dry rides
                    if (currentLoggedInUser.Age >= ride.MinAgeLimit && currentLoggedInUser.Age <= ride.MaxAgeLimit)
                    {
                        //Balance Check
                        if (currentLoggedInUser.WalletBalance >= ride.RidePrice)
                        {
                            currentLoggedInUser.DeductBalance(ride.RidePrice);
                            RideHistoryDetails rideHistory = new RideHistoryDetails(currentLoggedInUser.CardID, ride.RideID, ride.RideType, DateTime.Now.AddMinutes(minsAddedToBookingTime), RideStatusEnum.Booked);
                            rideHistoryDetails.Add(rideHistory);
                            System.Console.WriteLine("You are Successfully opted current ride and your Ride time is " + rideHistory.RideTime);

                        }
                        else
                        {
                            System.Console.WriteLine("Insufficient wallet balance. Recharge your wallet.");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("You cannot take selected ride due to right age limit.");
                    }

                    break;
                }

            case RideTypeEnum.Water:
                {
                    //Weight Limit condition for dry rides
                    if (currentLoggedInUser.Weight >= ride.MinWeight && currentLoggedInUser.Weight <= ride.MaxWeight)
                    {
                        //Balance Check
                        if (currentLoggedInUser.WalletBalance >= ride.RidePrice)
                        {
                            currentLoggedInUser.DeductBalance(ride.RidePrice);
                            RideHistoryDetails rideHistory = new RideHistoryDetails(currentLoggedInUser.CardID, ride.RideID, ride.RideType, DateTime.Now.AddMinutes(minsAddedToBookingTime), RideStatusEnum.Booked);
                            rideHistoryDetails.Add(rideHistory);
                            System.Console.WriteLine("You are Successfully opted current ride and your Ride time is " + rideHistory.RideTime);

                        }
                        else
                        {
                            System.Console.WriteLine("Insufficient wallet balance. Recharge your wallet.");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("You cannot take selected ride due to right weight limit.");
                    }

                    break;
                }

        }

        System.Console.WriteLine("\nRedirecting back to SUB MENU.....");

    }

    public static void CancelRide()
    {
        System.Console.WriteLine("CANCEL RIDE IS SELECTED\n");
        //Show  the Ride History list based on User id and Ride Booking status
        var table = new ConsoleTable("RIDE HISTORY ID", "CARD ID", "RIDE ID", "RIDE TYPE", "RIDE TIME", "RIDE STATUS");
        bool flag = true;
        foreach (RideHistoryDetails rideHistory in rideHistoryDetails)
        {
            if (rideHistory.CardID.Equals(currentLoggedInUser.CardID) && rideHistory.RideStatus == RideStatusEnum.Booked)
            {
                table.AddRow(rideHistory.RideHistoryID, rideHistory.CardID, rideHistory.RideID, rideHistory.RideType, rideHistory.RideTime, rideHistory.RideStatus);
                flag = false;
            }
        }
        System.Console.Write(table);
        System.Console.WriteLine();
        if (flag)
        {

            System.Console.WriteLine("No rides available to cancel!");
            return;

        }
        System.Console.Write("Enter the RIDE HISTORY ID of the Ride to be cancelled: ");
        string matchId = Console.ReadLine();
        matchId = matchId.ToUpper();
        while (!matchId.Contains("RHID"))
        {
            System.Console.WriteLine("INVALID RIDE HISTORY ID!");
            System.Console.Write("Enter Correct RIDE HISTORY ID from the table: ");
            matchId = Console.ReadLine().ToUpper();
        }


        //Need to check the Ride History ID and its status 
        bool matchrideHistoryID = false;
        foreach (RideHistoryDetails rideHistory in rideHistoryDetails)
        {
            if (rideHistory.RideHistoryID.Equals(matchId) && rideHistory.RideStatus == RideStatusEnum.Booked && rideHistory.CardID.Equals(currentLoggedInUser.CardID))
            {
                matchrideHistoryID = true;
                if (rideHistory.RideTime.CompareTo(DateTime.Now) == -1)
                {

                    System.Console.WriteLine("Ride Validity is over. So, can't cancel the ride.");
                    return;

                }

                //If Ride History ID available, refund else invalid ID
                //Change the Ride Booking status as Cancelled and display the cancelled message
                foreach (RideDetails ride in rideDetails)
                {
                    if (rideHistory.RideID == ride.RideID)
                    {

                        currentLoggedInUser.WalletRecharge(ride.RidePrice);
                        rideHistory.RideStatus = RideStatusEnum.Cancelled;
                    }


                }
                System.Console.WriteLine("Ride History ID :" + rideHistory.RideHistoryID + " cancelled Sucessfully");

            }
        }
        if (!matchrideHistoryID)
        {
            System.Console.WriteLine("INVALID RIDE HISTORY ID!");

        }

        System.Console.WriteLine("\nRedirecting back to SUB MENU.....");

    }

    public static void WalletRecharge()
    {
        System.Console.WriteLine("WALLET RECHARGE IS SELECTED");
        //Getting amount to be recharged
        System.Console.Write("Enter the amount to be recharged: Rs.");
        bool tempAmt = double.TryParse(Console.ReadLine(), out double amount);
        //Minimum recharge limit is Rs. 50
        while (!(tempAmt && amount >= 50))
        {
            System.Console.WriteLine("INVALID AMOUNT!");
            System.Console.Write("Enter valid amount (Amount should not be negative and minimum recharge is Rs. 50): Rs.");
            tempAmt = double.TryParse(Console.ReadLine(), out amount);
        }

        currentLoggedInUser.WalletRecharge(amount);
        System.Console.WriteLine("CARD RECHARGE SUCCESSFUL!");
        //Displaying current balance of the user
        System.Console.WriteLine("Your Current Balance: " + currentLoggedInUser.WalletBalance);

        System.Console.WriteLine("\nRedirecting back to SUB MENU.....");


    }

    public static void RideHistory()
    {
        System.Console.WriteLine("RIDE HISTORY IS SELECTED\n");
        //show  the Ride History list based on User id s
        var table = new ConsoleTable("RIDE HISTORY ID", "CARD ID", "RIDE ID", "RIDE TYPE", "RIDE TIME", "RIDE STATUS");
        foreach (RideHistoryDetails rideHistory in rideHistoryDetails)
        {
            if (rideHistory.CardID.Equals(currentLoggedInUser.CardID))
            {
                table.AddRow(rideHistory.RideHistoryID, rideHistory.CardID, rideHistory.RideID, rideHistory.RideType, rideHistory.RideTime, rideHistory.RideStatus);
            }

        }
        System.Console.Write(table);
        System.Console.WriteLine();
    }

    public static void WalletBalance()
    {
        System.Console.WriteLine("WALLET BALANCE IS SELECTED");
        //Displaying current balance of the user
        System.Console.WriteLine("Available wallet balance: " + currentLoggedInUser.WalletBalance);
    }


}