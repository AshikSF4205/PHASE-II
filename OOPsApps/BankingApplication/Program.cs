using System;
using System.Collections.Generic;
using System.Numerics;
namespace BankingApplication;

public enum GenderEnum { Select, Male, Female, Other }
class Program
{

    static List<CustomerDetails> customerDetails = new List<CustomerDetails>();

    public static void Main(string[] args)
    {
        System.Console.WriteLine("\n\n---------------------WELCOME TO HDFC BANKING PORTAL---------------------\n\n");
        System.Console.WriteLine("\n1. Registration \n2. Login \n3. Exit");
        System.Console.Write("\nEnter the  Appropriate digit: ");
        bool temp1 = int.TryParse(Console.ReadLine(), out int option);

        while (!temp1)
        {
            System.Console.WriteLine("INVALID ENTRY!");
            System.Console.WriteLine("\n1. Registration \n2. Login \n3. Exit");
            System.Console.Write("\nEnter the  Appropriate digit: ");
            temp1 = int.TryParse(Console.ReadLine(), out option);
        }

        switch (option)
        
        {

            case 1:
                {
                    System.Console.Write("Enter Full Name: ");
                    string customerName = Console.ReadLine();
                    System.Console.Write("Enter Phone Number(10-digits): (+91) ");
                    string phNo = Console.ReadLine();
                    bool temp2 = long.TryParse(phNo, out long phoneNumber);
                    while (!(temp2 && phNo.Length == 10))
                    {
                        System.Console.WriteLine("INVALID PHONE NUMBER!");
                        System.Console.Write("Enter Correct Phone Number(10-digits): (+91) ");
                        temp2 = long.TryParse(Console.ReadLine(), out phoneNumber);
                    }
                    System.Console.Write("Enter Mail Id: ");
                    string mailId = Console.ReadLine();
                    while (!(mailId.Contains(".") && mailId.Contains("@")))
                    {
                        System.Console.WriteLine("INVALID MAIL ID!");
                        System.Console.Write("Enter Correct Mail Id: ");
                        mailId = Console.ReadLine();

                    }
                    System.Console.Write("Enter DOB(dd/MM/yyyy): ");
                    bool temp3 = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dob);
                    while (!temp3)
                    {
                        System.Console.WriteLine("INVALID DATE!");
                        System.Console.Write("Enter Correct DOB(Format : dd/MM/yyyy): ");
                        temp3 = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
                    }
                    System.Console.Write("Enter Gender: \n1.Male \n2.Female \n3.Other \nEnter the respective digit: ");
                    int gender = Convert.ToInt32(Console.ReadLine());
                    while (!(gender == 1 || gender == 2 || gender == 3))
                    {
                        System.Console.WriteLine("INVALID ENTRY!");
                        System.Console.Write("\n1.Male \n2.Female \n3.Other \nEnter the correct digit: ");
                        gender = Convert.ToInt32(Console.ReadLine());

                    }
                    GenderEnum genderChoice = (GenderEnum)gender;
                    System.Console.Write("Enter Initial Deposit Amount in Rupees: Rs.");
                    bool temp4 = int.TryParse(Console.ReadLine(), out int balance);
                    while (!temp4)
                    {
                        System.Console.WriteLine("INVALID AMOUNT!");
                        System.Console.Write("Enter Correct Amount in Rupees: Rs.");
                        temp4 = int.TryParse(Console.ReadLine(), out balance);
                    }
                    CustomerDetails customer = new CustomerDetails(customerName, phoneNumber, mailId, dob, genderChoice, balance);
                    customerDetails.Add(customer);

                    System.Console.WriteLine("\n\n------------------------------------------------------------------\n\n");
                    System.Console.WriteLine("YOUR DIGITAL PASSBOOK (DETAILS PAGE)");
                    System.Console.WriteLine($"\n\n Bank: {customer.Bank}\n Branch: {customer.Branch}\n IFSC Code: {customer.IFSC}\n Customer ID: {customer.CustomerId}\n Customer Name: {customer.CustomerName}\n Mail Id: {customer.MailId}\n D.O.B: {customer.DOB.ToString("dd/MM/yyyy")}\n Gender: {customer.Gender}\n Current Balance: {customer.Balance}");
                    System.Console.WriteLine("\n\n------------------------------------------------------------------\n\n");
                    System.Console.WriteLine("\n*****PLEASE TAKE A SCREENSHOT OF YOUR DIGITAL PASSBOOK(DETAILS PAGE)*****\n");
                    goto case 2;
                }

            case 2:
                {
                    if (customerDetails.Count == 0)
                    {
                        System.Console.WriteLine("\n NO USER FOUND!");
                        goto case 3;
                    }

                    string choice;

                    CustomerDetails customerRecord = new CustomerDetails();
                    System.Console.Write("Enter Customer Id(You have only 5 Attemps): ");
                    string custId = Console.ReadLine();

                    foreach (CustomerDetails record in customerDetails)
                    {
                        int incorrectCounter = 0;
                        while (!custId.Equals(record.CustomerId))
                        {
                            incorrectCounter++;
                            System.Console.WriteLine("INCORRECT CUSTOMER ID! " + (5 - incorrectCounter) + " LEFT");
                            if (incorrectCounter == 5) goto case 3;
                            System.Console.Write("Enter Valid Customer Id: ");
                            custId = Console.ReadLine();
                        }
                        customerRecord = record;
                        break;
                    }
                    System.Console.WriteLine("\n\n---------------------VALID CUSTOMER ID---------------------\n\n");
                    System.Console.WriteLine("\nLogin Successful!\n");
                    do
                    {
                    MainMenu:
                        System.Console.WriteLine("\n1.Deposit  \n2. Withdraw \n3. Balance Check \n4. Exit");
                        System.Console.Write("\nEnter the  Appropriate digit: ");
                        bool temp5 = int.TryParse(Console.ReadLine(), out int subOption);

                        while (!temp5)
                        {
                            System.Console.WriteLine("INVALID ENTRY!");
                            System.Console.WriteLine("\n1.Deposit  \n2. Withdraw \n3. Balance Check \n4. Exit");
                            System.Console.Write("\nEnter the  Appropriate digit: ");
                            temp5 = int.TryParse(Console.ReadLine(), out subOption);
                        }

                        switch (subOption)
                        {
                            case 1:
                                {

                                    System.Console.Write("Enter Deposit Amount in Rupees: Rs.");
                                    bool temp6 = double.TryParse(Console.ReadLine(), out double depositAmount);
                                    while (!temp6 && depositAmount > 0)
                                    {
                                        System.Console.WriteLine("INVALID AMOUNT!");
                                        System.Console.Write("Enter Correct Amount in Rupees: Rs.");
                                        temp6 = double.TryParse(Console.ReadLine(), out depositAmount);
                                    }

                                    customerRecord.Balance = customerRecord.Deposit(depositAmount);
                                    System.Console.WriteLine("\nCurrent Balance: " + customerRecord.Balance);

                                    break;
                                }

                            case 2:
                                {

                                    System.Console.Write("Enter Withdrawal Amount in Rupees: Rs.");
                                    bool temp6 = double.TryParse(Console.ReadLine(), out double withdrawaltAmount);
                                    while (!temp6 && withdrawaltAmount > 0)
                                    {
                                        System.Console.WriteLine("INVALID AMOUNT!");
                                        System.Console.Write("Enter Correct Amount in Rupees: Rs.");
                                        temp6 = double.TryParse(Console.ReadLine(), out withdrawaltAmount);
                                    }

                                    while (withdrawaltAmount > customerRecord.Balance)
                                    {
                                        System.Console.WriteLine("INSUFFICIENT FUNDS!");
                                        System.Console.WriteLine("\nYour Current Balance: " + customerRecord.Balance);
                                        System.Console.Write("Enter Correct Amount in Rupees within the Available Balance: Rs.");
                                        temp6 = double.TryParse(Console.ReadLine(), out withdrawaltAmount);
                                    }

                                    customerRecord.Balance = customerRecord.Withdraw(withdrawaltAmount);
                                    System.Console.WriteLine("\nCurrent Balance: " + customerRecord.Balance);

                                    break;
                                }

                            case 3:
                                {
                                    System.Console.WriteLine("\nCurrent Balance: " + customerRecord.Balance);
                                    break;
                                }

                            case 4:
                                {
                                    goto MainMenu;
                                }
                        }
                        System.Console.WriteLine("Do you want to do any other transaction?");
                        choice = Console.ReadLine().ToLower();

                        while (choice != "yes" && choice != "no")
                        {
                            System.Console.WriteLine("Invalid choice, Enter Yes or No: ");
                            choice = Console.ReadLine().ToLower();
                        }
                    } while (choice == "yes");

                    break;
                }

            case 3:
                {
                    System.Console.WriteLine("\n\nTHANK YOU FOR USING HDFC BANKING PORTAL, COME AGAIN!\n\n");
                    break;
                }

        }

        System.Console.WriteLine("\n\n-------------------------------------------------------------------------\n\n");

    }
}