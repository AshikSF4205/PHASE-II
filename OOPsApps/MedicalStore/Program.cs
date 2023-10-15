using System;
using System.Collections.Generic;
using System.Numerics;
using ConsoleTables;
using MedicalStore;
namespace MedicalStore;

class Program
{

    static List<UserDetails> userDetails = new List<UserDetails>();

    static List<MedicineDetails> medicineDetails = new List<MedicineDetails>();

    static List<OrderDetails> orderDetails = new List<OrderDetails>();

    static UserDetails currentUser = new UserDetails();

    private static void DataLoading()
    {

        //User Data
        userDetails.Add(new UserDetails("Ravi", 33, "Theni", 9877774440, 400));
        userDetails.Add(new UserDetails("Baskaran", 33, "Chennai", 8847757470, 500));

        //Medicine Data
        medicineDetails.Add(new MedicineDetails("Paracitamol", 40, 5, new DateTime(2023, 06, 30)));
        medicineDetails.Add(new MedicineDetails("Calpol", 10, 5, new DateTime(2023, 05, 30)));
        medicineDetails.Add(new MedicineDetails("Gelucil", 3, 40, new DateTime(2023, 04, 30)));
        medicineDetails.Add(new MedicineDetails("Metrogel", 5, 50, new DateTime(2023, 12, 30)));
        medicineDetails.Add(new MedicineDetails("Povidin Iodin", 10, 50, new DateTime(2023, 10, 30)));

        //Order Data
        orderDetails.Add(new OrderDetails("UID1001", "MD101", 3, 15, new DateTime(2022, 11, 13), (OrderStatusEnum)1));
        orderDetails.Add(new OrderDetails("UID1001", "MD102", 2, 10, new DateTime(2022, 11, 13), (OrderStatusEnum)2));
        orderDetails.Add(new OrderDetails("UID1001", "MD104", 2, 100, new DateTime(2022, 11, 13), (OrderStatusEnum)1));
        orderDetails.Add(new OrderDetails("UID1002", "MD103", 3, 120, new DateTime(2022, 11, 15), (OrderStatusEnum)2));
        orderDetails.Add(new OrderDetails("UID1002", "MD105", 5, 250, new DateTime(2022, 11, 15), (OrderStatusEnum)1));
        orderDetails.Add(new OrderDetails("UID1002", "MD102", 3, 15, new DateTime(2022, 11, 15), (OrderStatusEnum)1));

    }

    public static void Main(string[] args)
    {
        //Initial Data Loading
        DataLoading();

        System.Console.WriteLine("\n\n---------------------WELCOME TO ONLINE MEDICAL SHOP PORTAL---------------------\n\n");
        System.Console.WriteLine("\n1. User Registration \n2. User Login \n3. Exit");
        System.Console.Write("\nEnter the  Appropriate digit: ");
        bool temp1 = int.TryParse(Console.ReadLine(), out int option);

        while (!temp1)
        {
            System.Console.WriteLine("INVALID ENTRY!");
            System.Console.WriteLine("\n1. User Registration \n2. User Login \n3. Exit");
            System.Console.Write("\nEnter the  Appropriate digit: ");
            temp1 = int.TryParse(Console.ReadLine(), out option);
        }

        switch (option)
        {

            case 1:
                {
                    System.Console.Write("Enter UserName: ");
                    string userName = Console.ReadLine();

                    System.Console.Write("Enter Age: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    while (age < 0 && age > 120)
                    {
                        System.Console.WriteLine("INVALID AGE!");
                        System.Console.Write("Enter Correct Age: ");
                        age = Convert.ToInt32(Console.ReadLine());

                    }

                    System.Console.Write("Enter your City: ");
                    string city = Console.ReadLine();

                    System.Console.Write("Enter Phone Number(10-digits): (+91) ");
                    string phNo = Console.ReadLine();
                    bool temp2 = long.TryParse(phNo, out long phoneNumber);
                    while (!(temp2 && phNo.Length == 10))
                    {
                        System.Console.WriteLine("INVALID PHONE NUMBER!");
                        System.Console.Write("Enter Correct Phone Number(10-digits): (+91) ");
                        temp2 = long.TryParse(Console.ReadLine(), out phoneNumber);
                    }

                    System.Console.Write("Enter Initial Wallet Top-up in Rupees: Rs.");
                    bool temp3 = int.TryParse(Console.ReadLine(), out int balance);
                    while (!temp3)
                    {
                        System.Console.WriteLine("INVALID AMOUNT!");
                        System.Console.Write("Enter Correct Amount in Rupees: Rs.");
                        temp3 = int.TryParse(Console.ReadLine(), out balance);
                    }

                    UserDetails user = new UserDetails(userName, age, city, phoneNumber, balance);
                    userDetails.Add(user);


                    System.Console.WriteLine("\n--------------------------------\n");
                    System.Console.WriteLine("YOUR ID IS " + user.UserID);
                    System.Console.WriteLine("Please note down your user ID.");
                    System.Console.WriteLine("\n---------------------------------\n");

                    System.Console.WriteLine("\nACCOUNT CREATION WAS SUCCESSFUL!\n");
                    goto case 2;
                }

            case 2:
                {
                    if (userDetails.Count == 0)
                    {
                        System.Console.WriteLine("\n NO USER FOUND!");
                        goto case 3;
                    }

                    string choice;

                    bool flag = false;
                    System.Console.WriteLine("Portal will ask for USER ID till it is correct.\nSo,");
                    do
                    {

                        System.Console.Write("\nEnter Valid User Id: ");
                        string uId = Console.ReadLine();
                        foreach (UserDetails record in userDetails)
                        {
                            if (uId.Equals(record.UserID))
                            {
                                currentUser = record;
                                flag = false;
                                break;
                            }
                            else
                            {
                                System.Console.WriteLine("INVALID USER ID!");
                                flag = true;
                            }
                        }
                    } while (flag);
                    System.Console.WriteLine("\n----------VALID USER ID----------\n");
                    System.Console.WriteLine("\nLogin Successful!\n");
                    do
                    {
                        System.Console.WriteLine("\n1. Show medicine list  \n2. Purchase medicine \n3. Cancel purchase \n4. Show purchase history \n5. Recharge \n6. Show WalletBalance \n7. Exit");
                        System.Console.Write("\nEnter the  Appropriate digit: ");
                        bool temp4 = int.TryParse(Console.ReadLine(), out int subOption);

                        while (!temp4)
                        {
                            System.Console.WriteLine("INVALID ENTRY!");
                            System.Console.WriteLine("\n1. Show medicine list  \n2. Purchase medicine \n3. Cancel purchase \n4. Show purchase history \n5. Recharge \n6. Show WalletBalance \n7. Exit");
                            System.Console.Write("\nEnter the  Appropriate digit: ");
                            temp4 = int.TryParse(Console.ReadLine(), out subOption);
                        }


                        switch (subOption)
                        {
                            case 1:
                                {
                                    System.Console.WriteLine("SHOW MEDICINE LIST IS SELECTED");
                                    var table = new ConsoleTable("MedicineID", "MedicineName");
                                    foreach (MedicineDetails med in medicineDetails)
                                    {
                                        table.AddRow(med.MedicineID, med.MedicineName);
                                    }
                                    System.Console.Write(table);
                                    System.Console.WriteLine();

                                    break;
                                }
                            case 2:
                                {
                                    System.Console.WriteLine("PURCHASE MEDICINE IS SELECTED");
                                    MedicineDetails medicine = new MedicineDetails();
                                    double totalAmount = 0;
                                    do
                                    {
                                        var table = new ConsoleTable("Medicine ID", "Medicine Name");
                                        foreach (MedicineDetails med in medicineDetails)
                                        {
                                            table.AddRow(med.MedicineID, med.MedicineName);
                                        }
                                        System.Console.Write(table);
                                        System.Console.WriteLine();

                                        do
                                        {
                                            System.Console.Write("\nSelect the medicine to purchase by it's Medicine ID:");
                                            string medicineId = Console.ReadLine();
                                            while (!medicineId.Contains("MD"))
                                            {
                                                System.Console.WriteLine("INVALID MEDICINE ID!");
                                                System.Console.Write("Enter Correct Medicine ID: ");
                                                medicineId = Console.ReadLine();
                                            }
                                            foreach (MedicineDetails med in medicineDetails)
                                            {
                                                if (medicineId.Equals(med.MedicineID))
                                                {
                                                    medicine = med;
                                                    flag = false;
                                                    break;
                                                }
                                                else
                                                {
                                                    System.Console.WriteLine("MEDICINE NOT AVAILABLE!");
                                                    flag = true;
                                                }
                                            }
                                        } while (flag);
                                        System.Console.Write("\nEnter the medicine quantity: ");
                                        bool temp5 = int.TryParse(Console.ReadLine(), out int quantity);
                                        while (!temp5)
                                        {
                                            System.Console.WriteLine("INVALID NUMBER!");
                                            System.Console.Write("Enter Correct quantity: ");
                                            temp5 = int.TryParse(Console.ReadLine(), out quantity);
                                        }

                                        int expiry = medicine.DateOfExpiry.CompareTo(DateTime.Now);

                                        if (!(quantity < medicine.AvailableCount && expiry > 0))
                                        {
                                            System.Console.WriteLine("MEDICINE NOT AVAILABLE!");

                                        }
                                        else
                                        {
                                            medicine.AvailableCount -= quantity;
                                            totalAmount += medicine.Price;

                                        }

                                        System.Console.Write("\nYou want to add anything else to the cart? Enter Yes or No:");
                                        choice = Console.ReadLine().ToLower();

                                        while (choice != "yes" && choice != "no")
                                        {
                                            System.Console.Write("Invalid choice, Enter Yes or No: ");
                                            choice = Console.ReadLine().ToLower();
                                        }
                                    } while (choice == "yes");

                                    currentUser.Balance -= totalAmount;
                                    break;
                                }
                            case 3:
                                {
                                    System.Console.WriteLine("CNCEL PURCHASE IS SELECTED");
                                    var table = new ConsoleTable("ORDER ID", "CUSTOMER ID", "MEDICINE ID", "QUANTITY", "TOTAL", "ORDER DATE", "ORDER STATUS");
                                    foreach (OrderDetails order in orderDetails)
                                    {
                                        if (order.UserID.Equals(currentUser.UserID) && order.OrderStatus == OrderStatusEnum.Purchased)
                                        {
                                            table.AddRow(order.OrderID, order.UserID, order.MedicineID, order.MedicineID, order.TotalPrice, order.OrderDate.ToString("dd/MM/yyyy"), order.OrderStatus);
                                        }
                                        System.Console.Write(table);
                                        System.Console.WriteLine();
                                    }

                                    System.Console.Write("Enter the Order ID of the order to be cancelled: ");
                                    string matchId = Console.ReadLine().ToUpper();
                                    while (!matchId.Contains("OID"))
                                    {
                                        System.Console.WriteLine("INVALID ORDER ID!");
                                        System.Console.Write("Enter Correct Order ID from the table: ");
                                        matchId = Console.ReadLine();
                                    }


                                    bool matchOrderID = false;
                                    foreach (OrderDetails order in orderDetails)
                                    {
                                        if (order.OrderID.Equals(matchId) && order.OrderStatus == OrderStatusEnum.Purchased && order.UserID.Equals(currentUser.UserID))
                                        {
                                            matchOrderID = true;


                                            foreach (MedicineDetails med in medicineDetails)
                                            {
                                                if (med.MedicineID == order.MedicineID)
                                                {

                                                    med.AvailableCount += order.MedicineCount;
                                                    currentUser.Balance += order.TotalPrice;


                                                }

                                            }
                                            order.OrderStatus = OrderStatusEnum.Cancelled;
                                            System.Console.WriteLine(order.OrderID + " Order cancelled Sucessfully");
                                        }
                                    }
                                    if (!matchOrderID)
                                    {
                                        System.Console.WriteLine("ORDER ID NOT MATCHED!");

                                    }

                                    System.Console.WriteLine("\nRedirecting back to Sub Menu.....");

                                    break;
                                }
                            case 4:
                                {
                                    System.Console.WriteLine("SHOW PURCHASE HISTORY IS SELECTED");

                                    var table = new ConsoleTable("ORDER ID", "CUSTOMER ID", "MEDICINE ID", "QUANTITY", "TOTAL", "ORDER DATE", "ORDER STATUS");
                                    foreach (OrderDetails order in orderDetails)
                                    {

                                        if (order.UserID.Equals(currentUser.UserID))
                                        {
                                            table.AddRow(order.OrderID, order.UserID, order.MedicineID, order.MedicineCount, order.TotalPrice, order.OrderDate.ToString("dd/MM/yyyy"), order.OrderStatus);
                                        }
                                        System.Console.Write(table);
                                        System.Console.WriteLine();
                                    }
                                    System.Console.WriteLine("\nRedirecting back to Sub Menu.....");

                                    break;
                                }
                            case 5:
                                {

                                    System.Console.WriteLine("WALLET RECHARGE IS SELECTED");
                                    //reconsideration of recharge decision
                                    System.Console.Write("\nDo you like to proceed with the Re-charge?\nEnter Yes or No: ");
                                    string reChoice = Console.ReadLine().ToLower();

                                    while (reChoice != "yes" && reChoice != "no")
                                    {
                                        System.Console.Write("Invalid choice, Enter Yes or No: ");
                                        reChoice = Console.ReadLine().ToLower();
                                    }

                                    if (reChoice == "yes")
                                    {
                                        System.Console.WriteLine("Enter the amount to be recharged: ");
                                        bool tempAmt = double.TryParse(Console.ReadLine(), out double amount);

                                        while (tempAmt && amount >= 1)
                                        {
                                            System.Console.WriteLine("INVALID AMOUNT!");
                                            System.Console.Write("Enter valid amount (Amount should not be negative and less than Rs. 1): ");
                                            tempAmt = double.TryParse(Console.ReadLine(), out amount);
                                        }

                                        currentUser.Balance += amount;
                                        System.Console.WriteLine("RECHARGE SUCCESSFUL!");
                                        System.Console.WriteLine("Your Current Balance: " + currentUser.Balance);
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("\nRedirecting back to Sub Menu.....");
                                    }

                                    break;
                                }
                            case 6:
                                {
                                    System.Console.WriteLine("WALLET BALANCE IS SELECTED");
                                    System.Console.WriteLine("Available wallet balance: " + currentUser.Balance);

                                    break;
                                }
                            case 7:
                                {
                                    //Exit
                                    System.Console.WriteLine("\nRedirecting back to MAIN MENU.....");
                                    break;
                                }
                        }


                        System.Console.Write("\nNeed More Help? Enter Yes or No:");
                        choice = Console.ReadLine().ToLower();

                        while (choice != "yes" && choice != "no")
                        {
                            System.Console.Write("Invalid choice, Enter Yes or No: ");
                            choice = Console.ReadLine().ToLower();
                        }
                    } while (choice == "yes");

                    break;
                }

            case 3:
                {
                    System.Console.WriteLine("\n\nTHANK YOU FOR USING MEDICAL ONLINE PORTAL, COME AGAIN!\n\n");
                    break;
                }

        }

        System.Console.WriteLine("\n\n-------------------------------------------------------------------------\n\n");

    }
}