using System;
using System.Collections.Generic;
using System.Numerics;
using EbBillCalculator;
namespace ebUsersCalculator;
class Program
{

    static List<UserDetails> ebUsers = new List<UserDetails>();

    static UserDetails currentUser = new UserDetails();

    public static void Main(string[] args)
    {
        System.Console.WriteLine("\n---------------------WELCOME TO EB BILL CALCULATION PORTAL---------------------\n");
    MainMenu:
        System.Console.WriteLine("\n1. Registration \n2. Login \n3. Exit");
        System.Console.Write("\nEnter the  Appropriate digit: ");
        bool temp = int.TryParse(Console.ReadLine(), out int option);

        while (!temp)
        {
            System.Console.WriteLine("INVALID ENTRY!");
            System.Console.WriteLine("\n1. Registration \n2. Login \n3. Exit");
            System.Console.Write("\nEnter the  Appropriate digit: ");
            temp = int.TryParse(Console.ReadLine(), out option);
        }

        switch (option)
        {

            case 1:
                {
                    System.Console.Write("Enter User Name: ");
                    string userName = Console.ReadLine();

                    System.Console.Write("Enter Phone Number(10-digits): (+91) ");
                    string phNo = Console.ReadLine();
                    bool tempPh = long.TryParse(phNo, out long phoneNumber);
                    while (!(tempPh && phNo.Length == 10))
                    {
                        System.Console.WriteLine("INVALID PHONE NUMBER!");
                        System.Console.Write("Enter Correct Phone Number(10-digits): (+91) ");
                        phNo = Console.ReadLine();
                        tempPh = long.TryParse(phNo, out phoneNumber);
                    }

                    System.Console.Write("Enter Mail Id: ");
                    string mailId = Console.ReadLine();
                    while (!(mailId.Contains(".") && mailId.Contains("@")))
                    {
                        System.Console.WriteLine("INVALID MAIL ID!");
                        System.Console.Write("Enter Correct Mail Id: ");
                        mailId = Console.ReadLine();

                    }

                    UserDetails user = new UserDetails(userName, phoneNumber, mailId);
                    ebUsers.Add(user);

                    System.Console.WriteLine("REGISTRATION SUCCESSFUL!");
                    System.Console.WriteLine("\n--------------------------------\n");
                    System.Console.WriteLine("YOUR METER ID IS " + user.MeterID);
                    System.Console.WriteLine("Please note down your user ID.");
                    System.Console.WriteLine("\n---------------------------------\n");
                    goto case 2;
                }

            case 2:
                {
                    if (ebUsers.Count == 0)
                    {
                        System.Console.WriteLine("\n NO USER FOUND! REGISTER FIRST!");
                        goto MainMenu;
                    }

                    string choice;

                    System.Console.Write("Enter Customer Id(You have only 5 Attemps): ");
                    string custId = Console.ReadLine();

                    foreach (UserDetails user in ebUsers)
                    {
                        int incorrectCounter = 0;
                        while (!custId.Equals(user.MeterID))
                        {
                            incorrectCounter++;
                            System.Console.WriteLine("INCORRECT METER ID! " + (5 - incorrectCounter) + " LEFT");
                            if (incorrectCounter == 5) goto case 3;
                            System.Console.Write("Enter Valid Meter Id: ");
                            custId = Console.ReadLine();
                        }
                        currentUser = user;
                        break;
                    }
                    System.Console.WriteLine("\n---------------------VALID CUSTOMER ID---------------------");
                    System.Console.WriteLine("\nLogin Successful!\n");

                SubMenu:
                    System.Console.WriteLine("\n1. Calculate Amount \n2. Display user Details \n3. Exit");
                    System.Console.Write("\nEnter the  Appropriate digit: ");
                    bool tempSub = int.TryParse(Console.ReadLine(), out int subOption);

                    while (!tempSub)
                    {
                        System.Console.WriteLine("INVALID ENTRY!");
                        System.Console.WriteLine("\n1. Calculate Amount \n2. Display user Details \n3. Exit");
                        System.Console.Write("\nEnter the  Appropriate digit: ");
                        tempSub = int.TryParse(Console.ReadLine(), out subOption);
                    }

                    switch (subOption)
                    {
                        case 1:
                            {

                                System.Console.Write("Enter the total units consumed: ");
                                bool tempUnit = double.TryParse(Console.ReadLine(), out double consumedUnit);
                                while (!tempUnit && consumedUnit > 0)
                                {
                                    System.Console.WriteLine("INVALID ENYTRY!");
                                    System.Console.Write("Enter correct value in units: ");
                                    tempUnit = double.TryParse(Console.ReadLine(), out consumedUnit);
                                }

                                currentUser.Units = Convert.ToDouble(consumedUnit);

                                currentUser.Amount = currentUser.CalculateAmount(currentUser.Units);

                                System.Console.WriteLine("\n---------------------EB BILL---------------------\n");
                                System.Console.WriteLine($"\n  Meter Id : {currentUser.MeterID} \n  User Name : {currentUser.UserName} \n  No. of units comsumed: {currentUser.Units} \n  Bill Amount: {currentUser.Amount}");
                                System.Console.WriteLine("\n-------------------------------------------------\n");

                                break;
                            }

                        case 2:
                            {

                                System.Console.WriteLine("\n---------------------EB BILL---------------------\n");
                                System.Console.WriteLine($"\n  Meter Id : {currentUser.MeterID} \n  User Name : {currentUser.UserName} \n  Phone Number: +91-{currentUser.PhoneNumber} \n  Mail Id: {currentUser.MailId}");
                                System.Console.WriteLine("\n-------------------------------------------------\n");

                                break;
                            }

                        case 3:
                            {
                                goto MainMenu;
                            }
                    }
                    System.Console.WriteLine("Do you want calculate another bill?");
                    choice = Console.ReadLine().ToLower();

                    while (choice != "yes" && choice != "no")
                    {
                        System.Console.WriteLine("Invalid choice, Enter Yes or No: ");
                        choice = Console.ReadLine().ToLower();
                    }
                    if (choice == "yes") goto SubMenu;
                    else goto case 3;
                }

            case 3:
                {
                    System.Console.WriteLine("\n\nTHANK YOU FOR USING EB BILL CALCULATION PORTAL, COME AGAIN!\n\n");
                    break;
                }

        }

        System.Console.WriteLine("\n-------------------------------------------------------------------------\n");

    }
}