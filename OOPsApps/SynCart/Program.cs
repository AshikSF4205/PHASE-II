using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;
using ConsoleTables;
namespace SynCart;
class Program
{
    static List<CustomerDetails> customerDetails = new List<CustomerDetails>();

    static List<ProductDetails> productDetails = new List<ProductDetails>();

    static List<OrderDetails> orderDetails = new List<OrderDetails>();

    static CustomerDetails currentLoggedInCustomer;

    static double deliveryCharge = 50;

    public static void Main(string[] args)
    {
        DataLoading();

        System.Console.WriteLine("\n---------------------------WELCOME TO SYNCART E-COMMERCE PORTAL---------------------------");
        System.Console.WriteLine("|                                                                                         |");

        bool tryParseChecker, exitChecker = false;
        do
        {
            //Main Menu
            System.Console.WriteLine("1. Customer Registration \n2. User Login \n3. Exit");
            System.Console.Write("\nEnter the  Appropriate digit: ");
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
                        System.Console.WriteLine("|                                                                                         |");
                        System.Console.WriteLine("-----------------------------------THANK YOU VISIT AGAIN!----------------------------------");

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

    private static void DataLoading()
    {

        //User Data
        customerDetails.Add(new CustomerDetails("Ravi", "Chennai", 9885858588, "ravi@mail.com", 50000));
        customerDetails.Add(new CustomerDetails("Baskaran", "Chennai", 9888475757, "baskaran@mail.com", 60000));

        //Product Data
        productDetails.Add(new ProductDetails("Mobile (Samsung)", 10, 10000, 3));
        productDetails.Add(new ProductDetails("Tablet (Lenovo)", 5, 15000, 2));
        productDetails.Add(new ProductDetails("Camara (Sony)", 3, 20000, 4));
        productDetails.Add(new ProductDetails("iPhone", 5, 50000, 6));
        productDetails.Add(new ProductDetails("Laptop (Lenovo I3)", 3, 40000, 3));
        productDetails.Add(new ProductDetails("HeadPhone (Boat)", 10, 1000, 2));
        productDetails.Add(new ProductDetails("Speakers (Boat)", 4, 500, 2));

        //Order Data
        orderDetails.Add(new OrderDetails("CID1001", "PID101", 2, 20000, DateTime.Now, OrderStatusEnum.Ordered));
        orderDetails.Add(new OrderDetails("CID1002", "PID103", 2, 40000, DateTime.Now, OrderStatusEnum.Ordered));
    }

    public static void Registration()
    {
        System.Console.WriteLine("REGISTRATION IS SELECTED");

        //Getting Customer Details
        System.Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        while (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
        {
            System.Console.WriteLine("NUMBERS NOT ALLOWED!");
            System.Console.Write("Enter Valid Name: ");
            name = Console.ReadLine();

        }


        System.Console.Write("Enter your City: ");
        string city = Console.ReadLine();
        while (!Regex.IsMatch(city, @"^[a-zA-Z]+$"))
        {
            System.Console.WriteLine("ONLY ALPHABETS ALLOWED!");
            System.Console.Write("Enter Valid City: ");
            city = Console.ReadLine();

        }

        System.Console.Write("Enter Mobile Number(10-digits): (+91) ");
        string phNo = Console.ReadLine();
        bool tempPhno = long.TryParse(phNo, out long mobileNumber);
        while (!(tempPhno && phNo.Length == 10))
        {
            System.Console.WriteLine("INVALID PHONE NUMBER!");
            System.Console.Write("Enter Correct Phone Number(10-digits): (+91) ");
            phNo = Console.ReadLine();
            tempPhno = long.TryParse(phNo, out mobileNumber);
        }

        System.Console.Write("Enter Mail Id: ");
        string mailId = Console.ReadLine().ToLower();
        while (!(mailId.Contains(".") && mailId.Contains("@")))
        {
            System.Console.WriteLine("INVALID MAIL ID!");
            System.Console.Write("Enter Correct Mail Id: ");
            mailId = Console.ReadLine();

        }

        System.Console.Write("Enter Initial Wallet Top-up in Rupees: Rs.");
        bool tempBal = int.TryParse(Console.ReadLine(), out int balance);
        while (!tempBal && balance > 0)
        {
            System.Console.WriteLine("INVALID AMOUNT!");
            System.Console.Write("Enter Correct Amount in Rupees: Rs.");
            tempBal = int.TryParse(Console.ReadLine(), out balance);
        }

        //Saving Customer details in customerDetails List
        CustomerDetails customer = new CustomerDetails(name, city, mobileNumber, mailId, balance);
        customerDetails.Add(customer);

        //Displaying Customer ID after completion of Registration
        System.Console.WriteLine("REGISTRATION SUCCESSFUL!");
        System.Console.WriteLine("\n--------------------------------\n");
        System.Console.WriteLine("YOUR ID IS " + customer.CustomerID);
        System.Console.WriteLine("Please note down your user ID.");
        System.Console.WriteLine("\n---------------------------------\n");

    }

    public static void Login()
    {
        System.Console.WriteLine("LOGIN IS SELECTED");

        //Intial check for customerS in List
        if (customerDetails.Count == 0)
        {
            System.Console.WriteLine("\n NO USER FOUND!");
            return;
        }


        bool flag = false;
        System.Console.WriteLine("Portal will ask for Customer ID till it is correct.\nSo,");
        do
        {

            System.Console.Write("Enter Valid User Id: ");
            string uId = Console.ReadLine().ToUpper();
            foreach (CustomerDetails record in customerDetails)
            {
                if (uId.Equals(record.CustomerID))
                {
                    currentLoggedInCustomer = record;
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            if (flag) System.Console.WriteLine("INVALID USER ID!");
            
        } while (flag);

        System.Console.WriteLine("\n---------------------------------------VALID USER ID--------------------------------------");
        System.Console.WriteLine("\nLOGIN SUCESSFUL!\n");
        SubMenu();

    }

    public static void SubMenu()
    {
        bool tryParseChecker, exitChecker = false;
        do
        {
            System.Console.WriteLine("\n1. Purchase  \n2. Order History \n3. Cancel Order \n4. Wallet Balance \n5. Wallet Recharge \n6. Exit");
            System.Console.Write("\nEnter the  Appropriate digit: ");
            tryParseChecker = int.TryParse(Console.ReadLine(), out int subOption);

            switch (subOption)
            {
                case 1:
                    {
                        Purchase();
                        break;
                    }
                case 2:
                    {
                        OrderHistory();
                        break;
                    }
                case 3:
                    {
                        CancelOrder();
                        break;
                    }
                case 4:
                    {
                        WalletBalance();
                        break;
                    }
                case 5:
                    {
                        WalletRecharge();
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

    public static void Purchase()
    {

        System.Console.WriteLine("PURCHASE IS SELECTED");

        var table = new ConsoleTable("PRODUCT ID", "PRODUCT NAME", "IN STOCK", "PRICE");
        foreach (ProductDetails prod in productDetails)
        {
            table.AddRow(prod.ProductID, prod.ProductName, prod.Stock, prod.Price);
        }
        System.Console.Write(table);
        System.Console.WriteLine();

        ProductDetails product = new ProductDetails();
        bool flag = false;
        do
        {
            System.Console.Write("\nSelect the product to purchase by it's Product ID:");
            string productId = Console.ReadLine().ToUpper();
            while (!productId.Contains("PID"))
            {
                System.Console.WriteLine("INVALID PRODUCT ID!");
                System.Console.Write("Enter Correct Product ID from the table: ");
                productId = Console.ReadLine();
            }

            foreach (ProductDetails prod in productDetails)
            {
                if (productId.Equals(prod.ProductID))
                {
                    product = prod;
                    flag = false;
                    break;
                }
                else
                {

                    flag = true;
                }
            }
            if (flag) System.Console.WriteLine("PRODUCT NOT AVAILABLE!");
        } while (flag);

        System.Console.Write("\nEnter the Product quantity: ");
        bool tempQuant = int.TryParse(Console.ReadLine(), out int quantity);
        while (!tempQuant)
        {
            System.Console.WriteLine("INVALID NUMBER!");
            System.Console.Write("Enter Correct quantity(Only whole number greater than 1 is accepted): ");
            tempQuant = int.TryParse(Console.ReadLine(), out quantity);
        }

        if (quantity > product.Stock)
        {
            System.Console.WriteLine($"Required count not available. Current availability is {product.Stock}");
            System.Console.WriteLine("\nRedirecting back to SUB MENU.....");
        }
        else
        {
            double totalAmount;
            totalAmount = quantity * product.Price + deliveryCharge;
            if (totalAmount > currentLoggedInCustomer.WalletBalance)
            {
                System.Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again");
                System.Console.WriteLine("\nRedirecting back to Sub Menu.....");
            }
            else
            {
                //Deduce the amount from wallet and deduce the stock
                currentLoggedInCustomer.DeductBalance(totalAmount);
                product.Stock -= quantity;

                //create new order in orderDetails List
                OrderDetails order = new OrderDetails(currentLoggedInCustomer.CustomerID, product.ProductID, quantity, totalAmount, DateTime.Now, OrderStatusEnum.Ordered);
                orderDetails.Add(order);

                //display the order confirmation and order id
                System.Console.WriteLine("Order Placed Successfully " + order.OrderID);

                //display expected delivery date
                System.Console.WriteLine("You Product will be delivered on " + order.PurchaseDate.AddDays(product.ShippingDuration).ToString("dd/MM/yyyy"));

            }

        }

    }

    public static void OrderHistory()
    {

        System.Console.WriteLine("ORDER HISTORY IS SELECTED");
        //need to display all the orders made by customer
        var table = new ConsoleTable("ORDER ID", "CUSTOMER ID", "PRODUCT ID", "QUANTITY", "TOTAL", "PURCHASE DATE", "ORDER STATUS");
        foreach (OrderDetails order in orderDetails)
        {

            if (order.CustomerID.Equals(currentLoggedInCustomer.CustomerID))
            {
                table.AddRow(order.OrderID, order.CustomerID, order.ProductID, order.Quantity, order.TotalPrice, order.PurchaseDate.ToString("dd/MM/yyyy"), order.OrderStatus);
            }
            System.Console.Write(table);
            System.Console.WriteLine();
        }
        System.Console.WriteLine("\nRedirecting back to Sub Menu.....");

    }

    public static void CancelOrder()
    {
        System.Console.WriteLine("CANCEL ORDER IS SELECTED");
        //show  the order list based on customer id and order status
        var table = new ConsoleTable("ORDER ID", "CUSTOMER ID", "PRODUCT ID", "QUANTITY", "TOTAL", "PURCHASE DATE", "ORDER STATUS");
        foreach (OrderDetails order in orderDetails)
        {
            if (order.CustomerID.Equals(currentLoggedInCustomer.CustomerID) && order.OrderStatus == OrderStatusEnum.Ordered)
            {
                table.AddRow(order.OrderID, order.CustomerID, order.ProductID, order.Quantity, order.TotalPrice, order.PurchaseDate.ToString("dd/MM/yyyy"), order.OrderStatus);
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


        //need to check the order id and its status as ordered from orderlist
        bool matchOrderID = false;
        foreach (OrderDetails order in orderDetails)
        {
            if (order.OrderID.Equals(matchId) && order.OrderStatus == OrderStatusEnum.Ordered && order.CustomerID.Equals(currentLoggedInCustomer.CustomerID))
            {
                matchOrderID = true;

                //if ID available, restock and refund else invalid ID
                //change the order status as cancelled and display the cancelled message
                foreach (ProductDetails product in productDetails)
                {
                    if (order.ProductID == product.ProductID)
                    {

                        product.Stock += order.Quantity;
                        currentLoggedInCustomer.WalletRecharge(order.TotalPrice - deliveryCharge);


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

    }

    public static void WalletBalance()
    {
        System.Console.WriteLine("WALLET BALANCE IS SELECTED");
        //displayy current customers wallet balance
        System.Console.WriteLine("Available wallet balance: " + currentLoggedInCustomer.WalletBalance);
    }

    public static void WalletRecharge()
    {
        System.Console.WriteLine("WALLET RECHARGE IS SELECTED");
        //reconsideration of recharge decision
        System.Console.Write("\nDo you like to proceed with the Re-charge?\nEnter Yes or No: ");
        string choice = Console.ReadLine().ToLower();

        while (choice != "yes" && choice != "no")
        {
            System.Console.Write("Invalid choice, Enter Yes or No: ");
            choice = Console.ReadLine().ToLower();
        }

        if (choice == "yes")
        {
            System.Console.WriteLine("Enter the amount to be recharged: ");
            bool tempAmt = double.TryParse(Console.ReadLine(), out double amount);

            while (tempAmt && amount >= 1)
            {
                System.Console.WriteLine("INVALID AMOUNT!");
                System.Console.Write("Enter valid amount (Amount should not be negative and less than Rs. 1): ");
                tempAmt = double.TryParse(Console.ReadLine(), out amount);
            }

            currentLoggedInCustomer.WalletRecharge(amount);
            System.Console.WriteLine("RECHARGE SUCCESSFUL!");
            System.Console.WriteLine("Your Current Balance: " + currentLoggedInCustomer.WalletBalance);
        }
        else
        {
            System.Console.WriteLine("\nRedirecting back to Sub Menu.....");
        }

    }
}