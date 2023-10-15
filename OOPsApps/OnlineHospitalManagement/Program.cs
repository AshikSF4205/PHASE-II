using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineHospitalManagement;

public enum Menu{Select, Registration, Login, Exit}
public enum SubMenu{Select, BookAppointment, AppointmentHistory, CancelAppointment, WalletRecharge, WalletBalance, Exit}

class Program 
{

    public static List<DoctorDetails> DoctorList = new List<DoctorDetails>();
    public static List<PatientDetails> PatientList = new List<PatientDetails>();
    public static List<AvailableSlotDetails> AvailableSlotsList = new List<AvailableSlotDetails>();
    public static List<AppointmentDetails> AppointmentList = new List<AppointmentDetails>();

    static PatientDetails LoggedInPatient;

    public static void Main(string [] args)
    {
        AddDefaultData();

                System.Console.WriteLine("\n----------------------------WELCOME TO DOCTOR APPOINTMENT PORTAL---------------------------");
                System.Console.WriteLine("|                                                                                         |");


        bool run = true;

        // main loop
        while (run)
        {

            // main menu
            Console.Write("\nPlease choose any one from the below options.\n1. Registration\n2. Login\n3. Exit\nEither enter the number or enter the name as shown above: ");

            bool menuCheck;
            Menu chosenMenu;
            
            menuCheck = Enum.TryParse<Menu>(Console.ReadLine(), true, out chosenMenu);

            if (menuCheck)
            {
                switch (chosenMenu)
                {
                    case Menu.Registration:
                        Registration();
                        break;

                    case Menu.Login:
                        Login();
                        break;

                    case Menu.Exit:
                        run = false;
                        System.Console.WriteLine("|                                                                                         |");
                        System.Console.WriteLine("----------------------------------THANK YOU VISIT AGAIN!-----------------------------------");
                        break;

                    default:
                        menuCheck = false;
                        Console.WriteLine("Invalid input! Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please try again.");
            }
        }
    }

    public static void AddDefaultData()
    {
        AvailableSlotDetails slot1 = new AvailableSlotDetails("6.00-6.30");
        AvailableSlotDetails slot2 = new AvailableSlotDetails("6.30-7.00");
        AvailableSlotDetails slot3 = new AvailableSlotDetails("7.00-7.30");
        AvailableSlotDetails slot4 = new AvailableSlotDetails("7.30-8.00");
        AvailableSlotDetails slot5 = new AvailableSlotDetails("8.00-8.30");
        AvailableSlotDetails slot6 = new AvailableSlotDetails("8.30-9.00");

        AvailableSlotsList.Add(slot1);
        AvailableSlotsList.Add(slot2);
        AvailableSlotsList.Add(slot3);
        AvailableSlotsList.Add(slot4);
        AvailableSlotsList.Add(slot5);
        AvailableSlotsList.Add(slot6);

        DoctorDetails doctor1 = new DoctorDetails("John", 20, "General", 200, new List<string>{slot1.SlotDetails, slot2.SlotDetails, slot3.SlotDetails, slot4.SlotDetails, slot5.SlotDetails, slot6.SlotDetails});
        DoctorDetails doctor2 = new DoctorDetails("Saravanan", 30, "Heart", 500, new List<string>{slot1.SlotDetails, slot2.SlotDetails, slot3.SlotDetails, slot4.SlotDetails});
        DoctorDetails doctor3 = new DoctorDetails("Kavi", 40, "Ortho", 100, new List<string>{slot4.SlotDetails, slot5.SlotDetails, slot6.SlotDetails});

        DoctorList.Add(doctor1);
        DoctorList.Add(doctor2);
        DoctorList.Add(doctor3);
        
        PatientDetails patient1 = new PatientDetails("Arun", 45, Gender.Male, 1000);
        PatientDetails patient2 = new PatientDetails("Kumar", 50, Gender.Male, 500);
        PatientDetails patient3 = new PatientDetails("Malar", 30, Gender.Female, 100);
        PatientDetails patient4 = new PatientDetails("Selvi", 20, Gender.Female, 50);

        PatientList.Add(patient1);
        PatientList.Add(patient2);
        PatientList.Add(patient3);
        PatientList.Add(patient4);

        AppointmentDetails appointment1 = new AppointmentDetails("PID1001", "DID301", new DateTime(2022,04,27), "6.00-6.30", AppointmentStatus.Booked, 200);
        AppointmentDetails appointment2 = new AppointmentDetails("PID1002", "DID302", new DateTime(2022,04,27), "6.00-6.30", AppointmentStatus.Booked, 500);
        AppointmentDetails appointment3 = new AppointmentDetails("PID1003", "DID303", new DateTime(2022,04,27), "6.00-6.30", AppointmentStatus.Booked, 100);
        AppointmentDetails appointment4 = new AppointmentDetails("PID1001", "DID303", new DateTime(2022,04,27), "6.00-6.30", AppointmentStatus.Cancelled, 100);

        AppointmentList.Add(appointment1);
        AppointmentList.Add(appointment2);
        AppointmentList.Add(appointment3);
        AppointmentList.Add(appointment4);


    }

    public static void Registration()
    {
        Console.WriteLine("\nFill out the form!");

        // username
        bool userNameCheck = false;
        string userName;

        do
        {
            Console.Write("\nUser Name: ");
            userName = Console.ReadLine();

            if (userName.Any(char.IsDigit)) Console.WriteLine("Name should not contain any numbers: ");
            else userNameCheck = true;
        } while (!userNameCheck);

        bool ageCheck = false;
        int age;

        do
        {
            Console.Write("\nAge: ");
            ageCheck = int.TryParse(Console.ReadLine(), out age);

            if (!ageCheck) Console.WriteLine("Invalid age! Please try again.");
            else if (age < 1)
            {
                ageCheck = false;
                Console.Write("The age can't be in negative value! Enter a valid age: ");
            }
        } while (!ageCheck);

        bool genderCheck = false;
        Gender gender;

        do
        {
            Console.WriteLine("\nSelect the gender\n1. Male\n2. Female\nEither enter the number or enter the name as shown above.");
            Console.Write("Gender: ");
            genderCheck = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);

            if ((!Enum.IsDefined(typeof(Gender), gender)) || (gender == Gender.Select)) genderCheck = false;

            if (!genderCheck) Console.WriteLine("Invalid gender! Please try again.");

        } while (!genderCheck);

        bool balanceCheck = false;
        double walletBalance;

        do
        {
            Console.Write("\nWallet Balance: (Rs.) ");
            balanceCheck = double.TryParse(Console.ReadLine(), out walletBalance);

            if (!balanceCheck) Console.WriteLine("Invalid amount! Please try again.");
            else if (walletBalance < 0)
            {
                balanceCheck = false;
                Console.WriteLine("The amount can't be in negative value! Enter a valid amount.");
            }
        } while (!balanceCheck);

        PatientDetails patient = new PatientDetails(userName, age, gender, walletBalance);

        PatientList.Add(patient);
        System.Console.WriteLine("\n---------------------------------");
        Console.WriteLine($"\nKindly check your details: \nName: {patient.PatientID}\nName: {patient.PatientName}\nAge: {patient.Age}\nGender: {patient.Gender}\nWallet Balance: {patient.WalletBalance}\n\nPlease make note of your Patient ID\nPatient ID: {patient.PatientID}");
        System.Console.WriteLine("---------------------------------\n");
    }

    public static void Login()
    {
        Console.Write("\nEnter your Patient ID: ");
        
        string patientID = Console.ReadLine();
        bool patientCheck = false;

        foreach (PatientDetails patient in PatientList)
        {
            if (patient.PatientID == patientID.ToUpper())
            {
                LoggedInPatient = patient;
                SubMenu subMenu;

                patientCheck = true;
                bool subMenuCheck = false;

                do
                {
                    // sub menu
                    Console.Write("\nPlease choose any one from the below options.\n1. Book Appointment\n2. Appointment History\n3. Cancel Appointment\n4. Wallet Recharge\n5. Wallet Balance\n6. Exit\nEither enter the number or enter the name as shown above without any space: ");

                    subMenuCheck = Enum.TryParse<SubMenu>(Console.ReadLine(), true, out subMenu);

                    if (!subMenuCheck)
                    {
                        subMenuCheck = true;
                        
                        Console.WriteLine("Invalid option! Please try again");
                    }

                    else
                    {
                        switch(subMenu)
                        {
                            case SubMenu.BookAppointment:
                                BookAppointment();
                                break;

                            case SubMenu.AppointmentHistory:
                                AppointmentHistory();
                                break;

                            case SubMenu.CancelAppointment:
                                CancelAppointment();
                                break;

                            case SubMenu.WalletRecharge:
                                WalletRecharge();
                                break;

                            case SubMenu.WalletBalance:
                                Console.WriteLine($"\nYour wallet Balance is Rs.{LoggedInPatient.WalletBalance}");
                                break;

                            case SubMenu.Exit:
                                subMenuCheck = false;
                                break;

                            default:
                                Console.WriteLine("Invalid input! Please try again.");
                                break;
                        }
                    }
                } while (subMenuCheck);
            }
        }
        if (!patientCheck) Console.WriteLine("Invalid Patient ID! Please enter a valid one.");
    }

    public static void BookAppointment()
    {
        Console.WriteLine($"\nHere are the list of Doctors available for booking");

        Console.WriteLine("\nDoctor ID".PadRight(20) + "Doctor Name".PadRight(20) + "Experience".PadRight(20) + "Specialization".PadRight(20) + "Fee".PadRight(20) + "Available Slots".PadRight(20));
        
        foreach (DoctorDetails doctor in DoctorList)
        {
            Console.WriteLine($"{doctor.DoctorID.PadRight(20)}{doctor.DoctorName.PadRight(20)}{doctor.Experience.ToString().PadRight(20)}{doctor.Specialization.PadRight(20)}{doctor.Fees.ToString().PadRight(20)}{string.Join(", ", doctor.AvailableSlotsList)}");
        }

        Console.WriteLine("\nChoose a book by entering Book ID");

        bool doctorCheck = false;

        Console.Write("Doctor ID: ");
        string doctorID = Console.ReadLine();

        Console.Write("Appointment Date: ");
        bool appointmentDateCheck = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime appointmentDate);

        Console.Write("Slot: ");
        string slot = Console.ReadLine();



        foreach (DoctorDetails doctor in DoctorList)
        {
            if (doctor.DoctorID == doctorID.ToUpper())
            {
                doctorCheck = true;

                if (!appointmentDateCheck) Console.WriteLine("Invalid Date! Please try again.");
                
                else
                {
                    bool AvailableSlotCheck = false;
                    foreach (AvailableSlotDetails availableSlot in AvailableSlotsList)
                    {
                        if (slot == availableSlot.SlotDetails)
                        {
                            AvailableSlotCheck = true;

                            bool slotBookedCheck = false;

                            if ((appointmentDate >= DateTime.Today) && (doctor.AvailableSlotsList.Contains(slot)))
                            {
                                foreach (AppointmentDetails appointment in AppointmentList)
                                {
                                    if ((appointment.AppointmentDate == appointmentDate) && (appointment.AppointmentSlot == slot) && (appointment.DoctorID == doctorID.ToUpper()))
                                    {
                                        slotBookedCheck = true;
                                        
                                        break;
                                    }
                                }

                                if (slotBookedCheck) Console.WriteLine("The required slot is not available!");

                                else 
                                {
                                    if (LoggedInPatient.WalletBalance >= doctor.Fees)
                                    {
                                        LoggedInPatient.WalletBalance -= doctor.Fees;

                                        AppointmentDetails bookedAppointment = new AppointmentDetails(LoggedInPatient.PatientID, doctor.DoctorID, appointmentDate, slot, AppointmentStatus.Booked, doctor.Fees);

                                        AppointmentList.Add(bookedAppointment);

                                        Console.WriteLine("Your appointment has been succesfully booked.");

                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You have insufficient balance! Please try again.");

                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (!AvailableSlotCheck) Console.WriteLine("Invalid slot! Please try again.");
                }        
            }
        } if (!doctorCheck) Console.WriteLine("Invalid doctor ID!");
    }

    public static void AppointmentHistory()
    {
        Console.WriteLine("\nHere are your appointment history:");

        Console.WriteLine("\nAppointment ID".PadRight(20) + "Patient ID".PadRight(20) + "Doctor ID".PadRight(20) + "Appointment Date".PadRight(20) + "Slot".PadRight(20) + "Status".PadRight(20) + "Fees".PadRight(20));

        bool appointmentCheck = false;

        foreach (AppointmentDetails appointment in AppointmentList)
        {
            if (appointment.PatientID == LoggedInPatient.PatientID)
            {
                appointmentCheck = true;
                Console.WriteLine($"{appointment.AppointmentID.PadRight(20)}{appointment.PatientID.PadRight(20)}{appointment.DoctorID.PadRight(20)}{appointment.AppointmentDate.ToString("dd/MM/yyyy").PadRight(20)}{appointment.AppointmentSlot.PadRight(20)}{appointment.AppointmentStatus.ToString().PadRight(20)}{appointment.Fee.ToString().PadRight(20)}");
            }
        }
        if (!appointmentCheck) Console.WriteLine("You have not booked any appointments till now.");
    }

    public static void CancelAppointment()
    {
        Console.WriteLine("Here are your appointment history:");

        Console.WriteLine("Appointment ID".PadRight(20) + "Patient ID".PadRight(20) + "Doctor ID".PadRight(20) + "Appointment Date".PadRight(20) + "Slot".PadRight(20) + "Status".PadRight(20) + "Fees".PadRight(20));

        bool appointmentCheck = false;

        foreach (AppointmentDetails appointment in AppointmentList)
        {
            if ((appointment.PatientID == LoggedInPatient.PatientID) && (appointment.AppointmentStatus == AppointmentStatus.Booked) && (appointment.AppointmentDate >= DateTime.Today))
            {
                appointmentCheck = true;
                Console.WriteLine($"{appointment.AppointmentID.PadRight(20)}{appointment.PatientID.PadRight(20)}{appointment.DoctorID.PadRight(20)}{appointment.AppointmentDate.ToString("dd/MM/yyyy").PadRight(20)}{appointment.AppointmentSlot.PadRight(20)}{appointment.Fee.ToString().PadRight(20)}");
            }
        }
        if (!appointmentCheck) Console.WriteLine("You have not booked any appointments till now!");

        Console.WriteLine("\nEnter the appointment ID which to be cancelled");
        Console.Write("\nAppointment ID: ");

        string cancelAppointment = Console.ReadLine();

        bool cancelAppointmentCheck = false;

        foreach (AppointmentDetails appointment in AppointmentList)
        {
            if ((appointment.PatientID == LoggedInPatient.PatientID) && (appointment.AppointmentStatus == AppointmentStatus.Booked) && (appointment.AppointmentID == cancelAppointment.ToUpper()) && (appointment.AppointmentDate >= DateTime.Today))
            {
                cancelAppointmentCheck = true;

                appointment.AppointmentStatus = AppointmentStatus.Cancelled;

                LoggedInPatient.WalletBalance += appointment.Fee;

                Console.WriteLine("The appointment has been successfully cancelled!");
            }
        }
        if (!cancelAppointmentCheck) Console.WriteLine("Invalid Appointment ID! Please try again.");
    }

    public static void WalletRecharge()
    {
        Console.Write("\nDo you wish to recharge your wallet Balance?\nEnter Yes/No: ");

        string response = Console.ReadLine();

        if (response.ToLower() == "yes")
        {
            bool amountCheck = false;

            double amount;

            do
            {
                Console.Write("\nAmount (Enter '0' to cancel): ");

                amountCheck = double.TryParse(Console.ReadLine(), out amount);

                if (!amountCheck) Console.WriteLine("Invalid amount! Please try again.");
                
                else if (amount<0)
                {
                    amountCheck = false;

                    Console.WriteLine("Invalid amount! Please try again.");
                }

                else if (amount>0)
                {
                    LoggedInPatient.WalletBalance += amount;

                    Console.WriteLine($"Your balance is {Math.Round(LoggedInPatient.WalletBalance,2)}");
                }
            } while (!amountCheck);
        }

        else
        {
            Console.WriteLine("\nRedirecting back to Sub Menu.....");
        }
    }
}