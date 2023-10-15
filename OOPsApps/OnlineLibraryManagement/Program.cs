using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace OnlineLibraryManagement;

class Program
{

    // creating lists for saving default data
    public static List<UserDetails> userList = new List<UserDetails>();
    public static List<BookDetails> bookList = new List<BookDetails>();
    public static List<BorrowDetails> borrowList = new List<BorrowDetails>();

    // saving current user after login
    public static UserDetails currentLoggedInUser;

    public static void Main(string[] args)
    {
        System.Console.WriteLine("\n---------------------------WELCOME TO ONLINE LIBRARY MANAGEMENT PORTAL---------------------------\n");


        // Calling method to load default data
        DefaultData();

        int mainMenuOption;
        bool mainMenuCondition;
        do
        {
            System.Console.WriteLine("Choose an option: \n1. Registration \n2. Login \n3. Exit");
            mainMenuCondition = int.TryParse(Console.ReadLine(), out mainMenuOption);

            // switch statement to check which option is selected
            switch (mainMenuOption)
            {
                case 1:
                    {
                        System.Console.WriteLine("Registration is selected");
                        Registration();
                        break;
                    }
                case 2:
                    {
                        System.Console.WriteLine("Login is selected");
                        Login();
                        break;
                    }
                case 3:
                    {
                        System.Console.WriteLine("You selected to exit the Main-Menu");
                        System.Console.WriteLine("\n-------------------------------------------------------------------------\n");
                        break;
                    }
                default:
                    {
                        System.Console.WriteLine("Invalid Option");
                        break;
                    }
            }
        }
        while (mainMenuOption != 3);
    }

    // Method for saving data to the list
    public static void DefaultData()
    {

        // Adding user data in userList
        userList.Add(new UserDetails("Ravichandran", GenderEnum.Male, DepartmentEnum.EEE, 9938388333, "ravi@gmail.com", 100));
        userList.Add(new UserDetails("Priyadharshini", GenderEnum.Female, DepartmentEnum.CSE, 9944444455, "priya@gmail.com", 150));

        // Adding book data in bookList
        bookList.Add(new BookDetails("C#", "Author1", 3));
        bookList.Add(new BookDetails("HTML", "Author2", 5));
        bookList.Add(new BookDetails("CSS", "Author1", 3));
        bookList.Add(new BookDetails("JS", "Author1", 3));
        bookList.Add(new BookDetails("TS", "Author2", 2));

        // Adding borrow data in borrowList
        borrowList.Add(new BorrowDetails("BID101", "SF3001", new DateTime(2023, 09, 10), StatusEnum.Borrowed, 2, 0));
        borrowList.Add(new BorrowDetails("BID103", "SF3001", new DateTime(2023, 09, 12), StatusEnum.Borrowed, 1, 0));
        borrowList.Add(new BorrowDetails("BID104", "SF3001", new DateTime(2023, 09, 14), StatusEnum.Returned, 1, 16));
        borrowList.Add(new BorrowDetails("BID102", "SF3002", new DateTime(2023, 09, 11), StatusEnum.Borrowed, 2, 0));
        borrowList.Add(new BorrowDetails("BID105", "SF3002", new DateTime(2023, 09, 09), StatusEnum.Returned, 1, 20));
    }

    // Method for collecting user registration details
    public static void Registration()
    {

        System.Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        System.Console.Write("Enter your gender: ");
        GenderEnum gender = Enum.Parse<GenderEnum>(Console.ReadLine(), true);

        System.Console.Write("Enter your department: ");
        DepartmentEnum department = Enum.Parse<DepartmentEnum>(Console.ReadLine(), true);

        System.Console.Write("Enter your mobile number: ");
        long mobileNumber = long.Parse(Console.ReadLine());

        System.Console.Write("Enter your mail id: ");
        string mailId = Console.ReadLine();

        System.Console.Write("Enter yor wallet balance: ");
        double walletBalance = double.Parse(Console.ReadLine());

        UserDetails user = new UserDetails(name, gender, department, mobileNumber, mailId, walletBalance);
        userList.Add(user);

        System.Console.WriteLine($"Your User Id is {user.UserId}");

    }

    // Method for Login 
    public static void Login()
    {
        // asking user Id input
        System.Console.Write("Enter your User Id: ");
        string userId = Console.ReadLine().ToUpper();

        // checking userId valid or invalid
        bool condition = true;
        foreach (UserDetails user in userList)
        {
            if (user.UserId.Equals(userId))
            {
                condition = false;
                currentLoggedInUser = user;
                SubMenu();

            }
        }
        if (condition)
        {
            System.Console.WriteLine("Invalid User ID!");
        }

    }

    public static void SubMenu()
    {

        int subMenuOption;
        bool subMenuCondition;
        do
        {
            System.Console.WriteLine("Choose an option: \n1. Borrow book \n2. Show Borrowed history \n3. Return Books \n4. Wallet Recharge \n5. Exit");
            subMenuCondition = int.TryParse(Console.ReadLine(), out subMenuOption);

            // switch statement to check which option is selected
            switch (subMenuOption)
            {
                case 1:
                    {
                        System.Console.WriteLine("Borrow book  is selected");
                        BorrowBook();
                        break;
                    }
                case 2:
                    {
                        System.Console.WriteLine("Show Borrowed history  is selected");
                        ShowBorrowedHistory();
                        break;
                    }
                case 3:
                    {
                        System.Console.WriteLine("Return Books  is selected");
                        ReturnBooks();
                        break;
                    }
                case 4:
                    {
                        System.Console.WriteLine("Wallet recharge is selected");
                        WalletRecharge();
                        break;
                    }
                case 5:
                    {
                        System.Console.WriteLine("Exit  is selected");
                        break;
                    }
                default:
                    {
                        System.Console.WriteLine("Invalid Option is selected");
                        break;
                    }
            }
        }
        while (subMenuOption != 5);
    }

    public static void BorrowBook()
    {

        // Show the list of Books available by printing BookID, BookName, AuthorName, BookCount
        foreach (BookDetails book in bookList)
        {
            System.Console.WriteLine($"BookId:{book.BookId} \nBook Name:{book.BookName} \nAuthor Name:{book.AuthorName} \nBook Count:{book.BookCount} ");
        }

        // Ask the user to pick one book by Asking “Enter Book ID to borrow”
        System.Console.Write("Enter Book ID to borrow: ");
        string bookId = Console.ReadLine().ToUpper();

        // Check whether “BookID” is available or not
        bool condition = true;
        foreach (BookDetails book in bookList)
        {
            if (book.BookId.Equals(bookId))
            {
                condition = false;

                // get and check count of the book
                System.Console.Write("Enter the count of book: ");
                int count = int.Parse(Console.ReadLine());
                if (book.BookCount >= count)
                {

                    //check whether the user already borrowed any book, because user can borrow 3 books maximum at a time 
                    int borrowCount = 0;
                    foreach (BorrowDetails borrow in borrowList)
                    {
                        if (currentLoggedInUser.UserId.Equals(borrow.UserID) && borrow.Status.Equals(StatusEnum.Borrowed))
                        {
                            borrowCount += borrow.BorrowBookCount;
                        }
                    }

                    //If user borrowed 3 books already
                    if (borrowCount >= 3)
                    {
                        System.Console.WriteLine("You have borrowed 3 books already.");
                    }
                    else
                    {

                        // allocate the book to the user
                        // set status of the Booking Details as "Borrowed”
                        // set the “BorrowedDate” as today’s date
                        // “PaidFineAmount” as 0

                        //Create the Book Details object then store it 
                        BorrowDetails borrowBook = new BorrowDetails(book.BookId, currentLoggedInUser.UserId, DateTime.Now, StatusEnum.Borrowed, count, 0);
                        borrowList.Add(borrowBook);

                        // decreasing the book count
                        book.BookCount -= count;
                        System.Console.WriteLine("Book Borrowed successfully!");

                    }

                }
                else
                {
                    System.Console.WriteLine("Books are not available for the selected count.");

                    // print the next available date of book 
                    foreach (BorrowDetails borrow in borrowList)
                    {
                        if (book.BookId.Equals(borrow.BookId))
                        {
                            System.Console.WriteLine($"The book will be available on {borrow.BorrowedDate.AddDays(15)}");
                        }
                    }
                }

            }
        }
        if (condition)
        {
            System.Console.WriteLine("Invalid Book ID, please enter your valid Id!");
        }
    }

    public static void ShowBorrowedHistory()
    {
        // Book borrowed details
        foreach (BorrowDetails borrow in borrowList)
        {

            // check current user
            if (currentLoggedInUser.UserId.Equals(borrow.UserID))
            {
                System.Console.WriteLine($"Borrow Id:{borrow.BorrowId} \nBook Id:{borrow.BookId} \nUser Id:{borrow.UserID} \nBorrowed Date:{borrow.BorrowedDate} \nStatus:{borrow.Status} \nBorrow Book Count:{borrow.BorrowBookCount} \nPaidFineAmount:{borrow.PaidFineAmount}");
            }
        }
    }

    public static void ReturnBooks()
    {

        // Show the borrowed book details of current user whose status is “borrowed” also Print the return date of each book (Return date will be 15 days after borrowing a book)
        bool bookAvailable = true;
        foreach (BorrowDetails borrow in borrowList)
        {

            // check current user
            if (currentLoggedInUser.UserId.Equals(borrow.UserID) && borrow.Status.Equals(StatusEnum.Borrowed))
            {
                System.Console.WriteLine($"Borrow Id:{borrow.BorrowId} \nBook Id:{borrow.BookId} \nUser Id:{borrow.UserID} \nBorrowed Date:{borrow.BorrowedDate} \nStatus:{borrow.Status} \nBorrow Book Count:{borrow.BorrowBookCount} \nPaidFineAmount:{borrow.PaidFineAmount} \nReturn Date:{borrow.BorrowedDate.AddDays(15)}");
                bookAvailable = false;
            }
        }
        if (!bookAvailable)
        {
            // If the return date is elapsed more than 15 days then calculate and show the fine amount (Rs. 1 / Day) for each book(including those 15 days)
            double fine = 0;
            System.Console.WriteLine("Fine amount Rs 1 per day.");
            foreach (BorrowDetails borrow in borrowList)
            {

                // check current user
                if (currentLoggedInUser.UserId.Equals(borrow.UserID) && borrow.Status.Equals(StatusEnum.Borrowed))
                {

                    DateTime returnDate = borrow.BorrowedDate.AddDays(15);
                    if (returnDate < DateTime.Now)
                    {

                        TimeSpan days = DateTime.Now - returnDate;
                        fine += Convert.ToDouble(days.Days) + 15;
                    }
                }
            }

            // Ask him to select the BorrowedID to return book and validate that ID
            System.Console.Write("Enter your Borrow Id: ");
            string borrowId = Console.ReadLine().ToUpper();
            bool borrowCondition = true;
            foreach (BorrowDetails borrow in borrowList)
            {
                if (borrow.BorrowId.Equals(borrowId))
                {
                    borrowCondition = false;

                    // If return date is elapsed
                    if (borrow.BorrowedDate.AddDays(15) < DateTime.Now)
                    {
                        System.Console.WriteLine("Your time has elapsed!");
                        if (currentLoggedInUser.WalletBalance > fine)
                        {
                            currentLoggedInUser.DeductBalance(fine);
                            borrow.Status = StatusEnum.Returned;
                            borrow.PaidFineAmount += fine;
                            System.Console.WriteLine("Book returned successfully!");

                            // update the “BookCount”
                            foreach (BookDetails book in bookList)
                            {
                                if (borrow.BookId.Equals(book.BookId))
                                {
                                    book.BookCount += 1;
                                }
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Insufficient balance! please recharge and proceed.");
                        }
                    }
                    // return not elapsed
                    else
                    {
                        borrow.Status = StatusEnum.Returned;
                        System.Console.WriteLine("Book returned sucessfully!");
                        foreach (BookDetails book in bookList)
                        {
                            if (borrow.BookId.Equals(book.BookId))
                            {
                                book.BookCount += 1;
                            }
                        }
                    }
                }
            }
            if (borrowCondition)
            {
                System.Console.WriteLine("Invalid Borrow ID!");
            }
        }
        else
        {
            System.Console.WriteLine("You have no books to return!");
        }


    }

    public static void WalletRecharge()
    {
        System.Console.WriteLine("Do yo wish to recharge?");
        string answer = Console.ReadLine().ToLower();
        if (answer == "yes")
        {
            System.Console.Write("Enter the amount: ");
            double amount = double.Parse(Console.ReadLine());
            currentLoggedInUser.WalletRecharge(amount);
            System.Console.WriteLine($"Your Balance is {currentLoggedInUser.WalletBalance}");
        }

    }
}
