using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Threading;

namespace OnlineEmailServer;

class Program
{

    // creating list
    public static List<UserDetails> userList = new List<UserDetails>();
    public static List<MailBox> mailList = new List<MailBox>();
    public static List<SentItems> sentList = new List<SentItems>();
    public static List<Bin> binList = new List<Bin>();

    // current user
    public static UserDetails currentLoggedInUser;
    public static void Main(string[] args)
    {
        DefaultData();
        System.Console.WriteLine("\n---------------------------WELCOME TO ONLINE EMAIL SERVER PORTAL---------------------------");


        // Homepage
        int option;
        bool homePageCondition = true;
        do
        {
            System.Console.WriteLine("Select an option: \n1. Email SignUp \n2. Login \n3. Exit");
            homePageCondition = int.TryParse(Console.ReadLine(), out option);

            // Switch cases for user choice 1.Email SignUp 2.Login 3.Exit
            switch (option)
            {
                case 1:
                    {
                        SignUp();
                        break;
                    }
                case 2:
                    {
                        Login();
                        break;
                    }
                case 3:
                    {
                        System.Console.WriteLine("\nTHANK YOU FOR USING ONLINE EMAIL SERVER, COME AGAIN!\n");
                        System.Console.WriteLine("\n-------------------------------------------------------------------------\n");
                        break;
                    }
                default:
                    {
                        System.Console.WriteLine("Invalid option!");
                        break;
                    }

            }
        } while (option != 3);

    }

    public static void DefaultData()
    {

        // user details
        userList.Add(new UserDetails("Ravichandran", "Ettapparajan", new DateTime(1999, 11, 11), 8599488003, GenderEnum.Male, "ravi@gmail.com", "Sync@1"));
        userList.Add(new UserDetails("Baskaran", "Sethurajan", new DateTime(1950, 11, 11), 9857747327, GenderEnum.Male, "baskaran@gmail.com", "Fusion@1"));

        // mail details
        mailList.Add(new MailBox("ravi@gmail.com", "baskaran@gmail.com", "Test Mail", "Hi Baskaran, This is a test mail to test inbox folder for read mails. Regards, Ravichandran.", new DateTime(2022, 11, 11), StatusEnum.Read));
        mailList.Add(new MailBox("ravi@gmail.com", "baskaran@gmail.com", "Test Mail", "Hi Baskaran, This is another test mail to test inbox folder for unread mails. Regards, Ravichandran.", new DateTime(2022, 10, 11), StatusEnum.Read));
        mailList.Add(new MailBox("baskaran@gmail.com", "ravi@gmail.com", "Leave info", "Hi Ravichandran, On 13/11/2022 it will be a holiday. Please inform to trainees. Regards, Baskaran.", new DateTime(2022, 11, 11), StatusEnum.Read));

        //sent details
        sentList.Add(new SentItems("baskaran@gmail.com", "ravi@gmail.com", new DateTime(2022, 12, 12), "Test Mail", "This is a test mail to test sent items folder for read mails.Regards, Baskaran."));
        sentList.Add(new SentItems("baskaran@gmail.com", "ravi@gmail.com", new DateTime(2022, 12, 13), "Online Typing Test", "Hi Ravichandran, This is a test mail to test sent items folder for read mails. Regards, Baskaran."));
        sentList.Add(new SentItems("ravi@gmail.com", "baskaran@gmail.com", new DateTime(2022, 12, 14), "Time Sheet Update", "Time Sheet Update	Hi Baskaran, I forgot to check in today. Kindly mark my check-in time as 9 a.m. on December 14, 2022. Regards, Ravichandran."));

        //bin details
        binList.Add(new Bin("ravi@gmail.com", "baskaran@gmail.com", "Test Mail Read", "Hi Baskaran, This is a test mail to test inbox folder for read mails. Regards, Ravichandran.", new DateTime(2022, 11, 11), StatusEnum.Delete));
        binList.Add(new Bin("ravi@gmail.com", "baskaran@gmail.com", "Test Mail Unread", "Hi Baskaran, This is another test mail to test inbox folder for read mails. Regards, Ravichandran.", new DateTime(2022, 10, 11), StatusEnum.Delete));
        binList.Add(new Bin("baskaran@gmail.com", "ravi@gmail.com", "Leave info", "On 13/11/2022 it will be a holiday. Please inform to trainees. Regards, Baskaran.", new DateTime(2022, 11, 11), StatusEnum.Delete));
    }

    public static void SignUp()
    {

        // getting user details
        System.Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        System.Console.Write("Enter your father name: ");
        string fatherName = Console.ReadLine();

        DateTime dob;
        bool dobCond = true;
        System.Console.Write("Enter your Date of Birth (dd/MM/yyyy): ");
        do
        {

            dobCond = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
            if (!dobCond)
            {
                System.Console.Write("Enter in correct format (date/month/year): ");
            }
        } while (!dobCond);

        System.Console.Write("Enter your Phone Number: ");
        long phone;
        bool phoneCond = true;
        string check;
        do
        {
            phoneCond = long.TryParse(Console.ReadLine(), out phone);
            check = phone.ToString();
            if (!phoneCond || check.Length != 10)
            {
                System.Console.Write("Enter 10 digit phone number");
            }
        } while (!phoneCond || check.Length != 10);

        System.Console.Write("Enter your Gender: ");
        GenderEnum gender;
        bool condition1 = true;
        do
        {
            condition1 = Enum.TryParse<GenderEnum>(Console.ReadLine(), true, out gender);
            if (!condition1)
            {
                System.Console.Write("Choose correct gender: ");
            }
        } while (!condition1);

        System.Console.Write("Enter your preferred mail id: ");
        string mailId = Console.ReadLine();

        System.Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        UserDetails detail = new UserDetails(name, fatherName, dob, phone, gender, mailId, password);
        userList.Add(detail);
        System.Console.WriteLine();
        System.Console.WriteLine($"Your mail id is {mailId}");
    }

    public static void Login()
    {
        // On selection of the “Login” option from the main menu

        System.Console.Write("Enter your EmailId: ");
        string emailId = Console.ReadLine();
        System.Console.Write("Enter your password:");
        string password = Console.ReadLine();

        bool userCondition = true;
        foreach (UserDetails element in userList)
        {
            if (element.PreferredMailID.Equals(emailId) && element.Password.Equals(password))
            {
                System.Console.WriteLine("Successfully logged in!");
                userCondition = false;
                currentLoggedInUser = element;
                SubMenu();
            }
        }
        if (userCondition)
        {
            System.Console.WriteLine("Invalid User ID or password");
        }
    }

    public static void SubMenu()
    {

        int subOption;
        bool loginCondition;

        do
        {
            System.Console.WriteLine("Choose an option: \n1. Show Inbox Email \n2. Compose and Send Email \n3. Delete Inbox Mails \n4. Show sent Items \n5. Show Bin Folder \n6.SignOut");
            loginCondition = int.TryParse(Console.ReadLine(), out subOption);

            switch (subOption)
            {
                case 1:
                    {
                        System.Console.WriteLine("Show InboxEmail is selected");
                        int count = 0;
                        foreach (MailBox mail in mailList)
                        {
                            if (mail.ToMailID == currentLoggedInUser.PreferredMailID)
                            {
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            System.Console.WriteLine("Inbox is empty!");
                        }
                        else
                        {
                            ShowInbox();
                        }
                        break;
                    }
                case 2:
                    {
                        System.Console.WriteLine("Compose and Send Email is selected");
                        ComposeEmail();
                        break;
                    }
                case 3:
                    {
                        System.Console.WriteLine("Delete InboxMails is selected");
                        int count = 0;
                        foreach (MailBox mail in mailList)
                        {
                            if (mail.ToMailID == currentLoggedInUser.PreferredMailID)
                            {
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            System.Console.WriteLine("Inbox is already empty, no mails to delete");
                        }
                        else
                        {
                            DeleteMail();
                        }
                        break;
                    }
                case 4:
                    {
                        System.Console.WriteLine("Show sent Items is selected");
                        int count = 0;
                        foreach (SentItems sent in sentList)
                        {
                            if (sent.FromID == currentLoggedInUser.PreferredMailID)
                            {
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            System.Console.WriteLine("You have send zero mails");
                        }
                        else
                        {
                            SentItem();
                        }
                        break;
                    }
                case 5:
                    {
                        System.Console.WriteLine("Show Bin Folder is selected");
                        int count = 0;
                        foreach (Bin bin in binList)
                        {
                            if (bin.ToMailID == currentLoggedInUser.PreferredMailID)
                            {
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            System.Console.WriteLine("You have no mails in Bin folder");
                        }
                        else
                        {
                            ShowBin();
                        }

                        break;
                    }
                case 6:
                    {
                        System.Console.WriteLine("You selected to exit from the Sub-Menu!");
                        break;
                    }
                default:
                    {
                        System.Console.WriteLine("Invalid Option! \n Enter Correct option from Sub-Menu");
                        break;
                    }
            }

        } while (subOption != 6);
    }

    public static void ShowInbox()
    {

        // Show all mail received (That is To MailID is current userID) by showing Subject, MailNumber, Date Mailed in that show Mails based on date received and show the status of mail 
        for (int i = mailList.Count - 1; i >= 0; i--)
        {
            if (currentLoggedInUser.PreferredMailID.Equals(mailList[i].ToMailID))
            {
                System.Console.WriteLine();
                System.Console.WriteLine($"Date:{mailList[i].DateMailed} \nMail number:{mailList[i].MailNumber} \nSubject:{mailList[i].Subject} \nStatus:{mailList[i].Status}");
            }
        }

        // Ask the user to pick a MailNumber. If user enters a mail number check if it is valid. If it is invalid show Invalid Mail number. If it is valid then show The MailNumber, Date Mailed, Subject, Description. And change the status to Read
        System.Console.WriteLine();
        System.Console.Write("Enter a mail number: ");
        string mailNumber = Console.ReadLine().ToUpper();

        bool mailCond = true;
        foreach (MailBox mail in mailList)
        {
            if (mailNumber.Equals(mail.MailNumber) && currentLoggedInUser.PreferredMailID == mail.ToMailID)
            {
                mailCond = false;
                System.Console.WriteLine();
                System.Console.WriteLine($"Mail Number:{mail.MailNumber} \nDateMailed:{mail.DateMailed} \nSubject:{mail.Subject} \nDescription:{mail.Description}");
                mail.Status = StatusEnum.Read;
            }
        }
        if (mailCond)
        {
            System.Console.WriteLine("Invalid mail number");
        }
        System.Console.WriteLine();
    }

    public static void ComposeEmail()
    {

        // Ask the user to enter To MailID and validate the mail ID is present in UserDetails list. If it is invalid, then show MailID is not found
        System.Console.WriteLine();
        System.Console.WriteLine("Enter To Mail Id:");
        string toMail = Console.ReadLine();
        bool toMailCond = true;
        foreach (UserDetails user in userList)
        {
            if (toMail.Equals(user.PreferredMailID))
            {
                toMailCond = false;

                //If it is valid then ask the user to enter subject. After getting subject info, get mail description
                System.Console.WriteLine();
                System.Console.Write("Enter subject for the mail: ");
                string subject = Console.ReadLine();
                System.Console.WriteLine();
                System.Console.Write("Enter description for the mail: ");
                string description = Console.ReadLine();

                // Once he entered subject and description create SentItems Object who’s from ID is current user’s MailID and To ID is user entered ID, DateMailed as Now
                SentItems sent = new SentItems(currentLoggedInUser.PreferredMailID, toMail, DateTime.Now, subject, description);
                sentList.Add(sent);

                // Then add the MailBox object to list and show mail sent successfully
                MailBox mail = new MailBox(currentLoggedInUser.PreferredMailID, toMail, subject, description, DateTime.Now, StatusEnum.Unread);
                mailList.Add(mail);
            }
        }
        if (toMailCond)
        {
            System.Console.WriteLine("Mail ID not found!");
        }
    }

    public static void DeleteMail()
    {
        // Show all mailbox mails by showing Subject, MailNumber, Date Mailed in that show Mails based on date received and ask the mail number to delete
        for (int i = mailList.Count - 1; i >= 0; i--)
        {
            if (mailList[i].ToMailID == currentLoggedInUser.PreferredMailID)
            {
                System.Console.WriteLine();
                System.Console.WriteLine($"Date:{mailList[i].DateMailed} \nMail number:{mailList[i].MailNumber} \nSubject:{mailList[i].Subject} \nStatus:{mailList[i].Status}");
            }
        }

        string request = "no";
        bool mailNumberCond = true;
        do
        {
            System.Console.WriteLine();
            System.Console.Write("Enter the Mail Number to delete: ");
            string mailNumber = Console.ReadLine().ToUpper();
            mailNumberCond = true;
            foreach (MailBox mail in mailList)
            {
                if (mailNumber.Equals(mail.MailNumber) && mail.ToMailID == currentLoggedInUser.PreferredMailID)
                {
                    mailNumberCond = false;

                    // If user selected a MailNumber is valid then create an object to bin class and store the values in bin list changed the status read to delete. Finally delete from inbox list
                    Bin delete = new Bin(mail.FromMailID, mail.ToMailID, mail.Subject, mail.Description, mail.DateMailed, StatusEnum.Delete);
                    binList.Add(delete);
                    mailList.Remove(mail);
                    System.Console.WriteLine("Mail Successfully deleted!");

                    //Ask the user whether he want to delete another mail. If yes, then go to step 1 and repeat deletion
                    System.Console.WriteLine();
                    System.Console.WriteLine("Do you want to detete another mail? (yes/no): ");
                    do
                    {
                        request = Console.ReadLine().ToLower();

                        if (request != "yes" && request != "no")
                        {
                            System.Console.WriteLine("Enter properly (yes/no): ");
                        }
                    }
                    while (request != "yes" && request != "no");
                    break;

                }
            }
            if (mailNumberCond)
            {
                request = "no";
            }

        }
        while (request == "yes");

        if (mailNumberCond)
        {
            System.Console.WriteLine("Invalid Mail Number Input. Deletion unsuccessful!");
        }

    }

    public static void SentItem()
    {

        // Show all sent mail by showing Subject, sentMailNumber, Date Mailed in that show Mails based on date sent
        for (int i = sentList.Count - 1; i >= 0; i--)
        {
            if (currentLoggedInUser.PreferredMailID.Equals(sentList[i].FromID))
            {
                System.Console.WriteLine();
                System.Console.WriteLine($"Date:{sentList[i].Date} \nMail number:{sentList[i].SentMailNumber} \nSubject:{sentList[i].Subject}");
            }
        }

        // Ask the user to pick a sentMailNumber
        System.Console.WriteLine();
        System.Console.Write("Enter a sent mail number: ");
        string sentMail = Console.ReadLine().ToUpper();
        bool sentMailCond = true;

        // If user enters a mail number check if it is valid
        foreach (SentItems sent in sentList)
        {
            if (sentMail == sent.SentMailNumber && currentLoggedInUser.PreferredMailID == sent.FromID)
            {
                sentMailCond = false;

                // If it is valid then show The SentMailNumber, From MailID, To MailID, Subject, Description, Date
                System.Console.WriteLine();
                System.Console.WriteLine($"MailNumber:{sent.SentMailNumber} \nDate:{sent.Date} \nFromId:{sent.FromID} \nToId:{sent.ToID} \nSubject:{sent.Subject} \nDescription:{sent.Description}");

            }
        }
        if (sentMailCond)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Invalid Mail number!");
        }
    }

    public static void ShowBin()
    {
        // Display the current user’s deleted mail list by showing Subject, bin ID, date. Display the most recently deleted mail at the top of the list
        for (int i = binList.Count - 1; i >= 0; i--)
        {
            if (currentLoggedInUser.PreferredMailID.Equals(binList[i].ToMailID))
            {
                System.Console.WriteLine();
                System.Console.WriteLine($"Date:{binList[i].DateMailed} \nBinId:{binList[i].BinID} \nSubject:{binList[i].Subject}");
            }
        }

        // Ask the user whether he wanted to delete permanently or again move to inbox
        System.Console.WriteLine();
        System.Console.Write("Select a bin Id to delete or restore: ");
        string binId = Console.ReadLine().ToUpper();
        bool binIdCond = true;

        foreach (Bin bin in binList)
        {
            if (binId == bin.BinID && currentLoggedInUser.PreferredMailID == bin.ToMailID)
            {
                binIdCond = false;

                // asking user to delete permanenty or restore 
                bool cond;
                int number;
                do
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Choose an option: \n1. Delete \n2. Restore \n3. Exit");
                    cond = int.TryParse(Console.ReadLine(), out number);
                    if (number != 1 && number != 2 && number != 3)
                    {
                        System.Console.WriteLine("Invalid option!");
                        break;
                    }
                }
                while (number != 1 && number != 2 && number != 3);
                switch (number)
                {
                    case 1:
                        {
                            binList.Remove(bin);
                            System.Console.WriteLine("Successfully removed from Bin!");
                            break;
                        }
                    case 2:
                        {
                            // create an object for inbox then create a value and changed the status from delete to read finally add to the inbox list
                            MailBox mail = new MailBox(bin.FromMailID, bin.ToMailID, bin.Subject, bin.Description, bin.DateMailed, StatusEnum.Read);
                            mailList.Add(mail);
                            System.Console.WriteLine("Successfully restored!");
                            // remove from bin folder
                            binList.Remove(bin);
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("Exiting....!");
                            break;
                        }
                }
                break;

            }
        }
        if (binIdCond)
        {
            System.Console.WriteLine("Invalid Bin ID!");
        }

    }



}


