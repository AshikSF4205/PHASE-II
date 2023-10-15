using System;
using System.Collections.Generic;
namespace OnlineDthRecharge;

class Program
{
    static List<UserRegistration> userRegistrationsList = new List<UserRegistration>();
    static List<PackDetails> packDetailsList = new List<PackDetails>();
    static List<RechargeHistory> rechargeHistories = new List<RechargeHistory>();

    static UserRegistration currentLoggedUser;
    public static void Main(string[] args)
    {
        AddDefaultData();
        System.Console.WriteLine("\n---------------------------WELCOME TO ONLINE DTh RECHARGE PORTAL---------------------------\n");

        int userChoice = 0;
        bool check = true;
        do
        {
            System.Console.WriteLine("Main Menu:");
            System.Console.WriteLine("1. User Registration ");
            System.Console.WriteLine("2. UserLogin ");
            System.Console.WriteLine("3. Exit");
            bool choiceCheck = int.TryParse(Console.ReadLine(), out userChoice);
            while (!choiceCheck)
            {
                System.Console.WriteLine("Invalid Input!!!!");
                System.Console.Write("Enter Correct Option from Main-Menu: ");
                check = int.TryParse(Console.ReadLine(), out userChoice);
            }
            switch (userChoice)
            {
                case 1:
                    {
                        Registration();
                        break;
                    }
                case 2:
                    {
                        Login();
                        break;
                    }
                case 3:
                    {
                        check = false;
                        System.Console.WriteLine("You selected to exit the Main-Menu");
                        System.Console.WriteLine("\n-------------------------------------------------------------------------\n");
                        break;
                    }
                default:
                    {
                        System.Console.WriteLine("Invalid Input!!");
                        break;
                    }
            }
        } while (check);
    }

    public static void AddDefaultData()
    {
        userRegistrationsList.Add(new UserRegistration("John", 9746646466, "john@gmail.com", 500));
        userRegistrationsList.Add(new UserRegistration("Merlin", 9782136543, "merlin@gmail.com", 150));
        packDetailsList.Add(new PackDetails("RC150", "Pack1", 150, 28, 50));
        packDetailsList.Add(new PackDetails("RC300", "Pack2", 300, 56, 75));
        packDetailsList.Add(new PackDetails("RC500", "Pack3", 500, 28, 200));
        packDetailsList.Add(new PackDetails("RC1500", "Pack4", 1500, 365, 200));
        rechargeHistories.Add(new RechargeHistory("UID1001", "RC150", new DateTime(2023, 11, 30), 150, new DateTime(2021, 12, 27), 50));
        rechargeHistories.Add(new RechargeHistory("UID1002", "RC150", new DateTime(2022, 01, 01), 150, new DateTime(2022, 01, 28), 50));
    }

    public static void Registration()
    {
        System.Console.WriteLine("Registration Page is selected");
        System.Console.Write("Enter Your Name: ");
        string name = Console.ReadLine();
        System.Console.Write("Enter your Number: ");
        int mobile;
        bool mobileCheck = int.TryParse(Console.ReadLine(), out mobile);
        while (!mobileCheck)
        {
            System.Console.WriteLine("Invalid Input!");
            System.Console.Write("Enter Correct Mobile Number: ");
            mobileCheck = int.TryParse(Console.ReadLine(), out mobile);
        }
        System.Console.WriteLine("Enter your Mail Id: ");
        string mailId = Console.ReadLine();
        System.Console.Write("Enter your Wallet Balance: ");
        double balance;
        bool balanceCheck = double.TryParse(Console.ReadLine(), out balance);
        while (!balanceCheck)
        {
            System.Console.WriteLine("Invalid Input!");
            System.Console.Write("Enter Correct Balance: ");
            balanceCheck = double.TryParse(Console.ReadLine(), out balance);
        }
        UserRegistration user = new UserRegistration(name, mobile, mailId, balance);
        userRegistrationsList.Add(user);
        System.Console.Write("Your Registration Id is: " + user.UserId);
    }

    public static void Login()
    {
        System.Console.WriteLine("Login Page is selected");
        if (userRegistrationsList.Count == 0)
        {
            System.Console.WriteLine("No Users Data Found!");
            System.Console.WriteLine("Register First!");
        }
        else
        {
            System.Console.WriteLine("Enter Your User Id: ");
            string userId = Console.ReadLine().ToUpper();
            bool check = false;
            foreach (UserRegistration user in userRegistrationsList)
            {
                if (userId == user.UserId)
                {
                    check = true;
                    System.Console.WriteLine("You Logged-In Successfully!)");
                    currentLoggedUser = user;
                    SubMenu();
                }
            }
            if (!check)
            {
                System.Console.WriteLine("Invalid User Id!!");
            }
        }
    }
    public static void SubMenu()
    {
        int suboption;
        bool subcheck = true;
        do
        {
            System.Console.WriteLine("Sub Menu:");
            System.Console.WriteLine("1. Current Pack");
            System.Console.WriteLine("2. Pack Recharge");
            System.Console.WriteLine("3. Wallet Recharge");
            System.Console.WriteLine("4. View Pack Recharge History");
            System.Console.WriteLine("5. Show Wallet Balance");
            System.Console.WriteLine("6. Exit");
            System.Console.Write("Enter Your Choice from Sub-Menu: ");
            bool subtemp = int.TryParse(Console.ReadLine(), out suboption);
            while (!subtemp)
            {
                System.Console.WriteLine("Invalid Inputs \n Enter Correct option from the menu: ");
                subtemp = int.TryParse(Console.ReadLine(), out suboption);
            }
            switch (suboption)
            {
                case 1:
                    {
                        CurrentPack();
                        break;
                    }
                case 2:
                    {
                        PackRecharge();
                        break;
                    }
                case 3:
                    {
                        WalletRecharge();
                        break;
                    }
                case 4:
                    {
                        ViewPackHistory();
                        break;
                    }
                case 5:
                    {
                        ShowBalance();
                        break;
                    }
                case 6:
                    {
                        System.Console.WriteLine("You selected to exit from the Sub-Menu!");
                        subcheck = false;
                        break;
                    }
                default:
                    {
                        System.Console.WriteLine("Invalid Option! \n Enter Correct option from Sub-Menu");
                        break;
                    }
            }
        } while (subcheck);
    }

    public static void CurrentPack()
    {
        bool packCheck = false;
        foreach (RechargeHistory history in rechargeHistories)
        {
            if (history.UserId == currentLoggedUser.UserId)
            {
                packCheck = true;
                System.Console.WriteLine("---------------------------------------Your Current Package Details---------------------------------------");
                foreach (PackDetails pack in packDetailsList)
                {
                    if (pack.PackId == history.PackId)
                    {
                        System.Console.Write("Pack Id: " + pack.PackId + "|");
                        System.Console.Write("Pack Name: " + pack.PackName + "|");
                        System.Console.Write("Pack Price: " + pack.Price + "|");
                        System.Console.Write("Validity: " + pack.Validity + "|");
                        System.Console.Write("No of Channels: " + pack.NoOfChannels + "|");
                        System.Console.WriteLine();
                    }
                }
                if (!packCheck)
                {
                    System.Console.WriteLine("No Package Details Found!");
                }
            }
        }
    }

    public static void PackRecharge()
    {
        System.Console.WriteLine("---------------------------------------Available Packages---------------------------------------");
        foreach (PackDetails pack in packDetailsList)
        {
            System.Console.Write("Pack Id: " + pack.PackId + "|");
            System.Console.Write("Pack Name: " + pack.PackName + "|");
            System.Console.Write("Pack Price: " + pack.Price + "|");
            System.Console.Write("Validity: " + pack.Validity + "|");
            System.Console.Write("No of Channels: " + pack.NoOfChannels + "|");
            System.Console.WriteLine();
        }
        bool check = false;
        System.Console.WriteLine("Enter a Pack Id: ");
        string packId = Console.ReadLine().ToUpper();
        foreach (PackDetails pack in packDetailsList)
        {
            if (pack.PackId == packId)
            {
                check = true;
                if (currentLoggedUser.WalletBalance < pack.Price)
                {
                    System.Console.WriteLine("You have insufficient balance in wallet!");
                    System.Console.WriteLine("Please do recharge your Wallet!!");
                }
                else
                {
                    currentLoggedUser.WalletBalance -= pack.Price;
                    DateTime rechargeDate = DateTime.Now;
                    DateTime validTill = rechargeDate.AddDays(pack.Validity);
                    RechargeHistory recharge = new RechargeHistory(currentLoggedUser.UserId, pack.PackId, rechargeDate, pack.Price, validTill, pack.NoOfChannels);
                    rechargeHistories.Add(recharge);
                    System.Console.WriteLine("Your Recharge Id is: " + recharge.RechargeId);
                }
            }
        }
        if (!check)
        {
            System.Console.WriteLine("Invalid Pack Id!!");
        }
    }

    public static void WalletRecharge()
    {
        System.Console.WriteLine("Enter the amount to add in your Wallet: ");
        double amount;
        bool amountCheck = double.TryParse(Console.ReadLine(), out amount);
        while (!amountCheck)
        {
            System.Console.WriteLine("Invalid Input!");
            System.Console.Write("Enter Correct amount: ");
            amountCheck = double.TryParse(Console.ReadLine(), out amount);
        }
        currentLoggedUser.WalletBalance += amount;
        System.Console.WriteLine("Your Update balance is " + currentLoggedUser.WalletBalance);
    }

    public static void ViewPackHistory()
    {
        bool check = false;
        foreach (RechargeHistory rechargeHistory in rechargeHistories)
        {
            if (currentLoggedUser.UserId == rechargeHistory.UserId)
            {
                check = true;
                System.Console.Write("Pack Id: " + rechargeHistory.PackId + "|");
                System.Console.Write("User Id: " + rechargeHistory.UserId + "|");
                System.Console.Write("Recharge Amount: " + rechargeHistory.RechargeAmount + "|");
                System.Console.Write("Valid Till: " + rechargeHistory.ValidTill.ToString("dd/MM/yyyy"));
                System.Console.WriteLine();
            }
        }
        if (!check)
        {
            System.Console.WriteLine("No Recharge History found for you!");
        }
    }

    public static void ShowBalance()
    {
        System.Console.WriteLine("Your Current Balance is: " + currentLoggedUser.WalletBalance);
    }


}
