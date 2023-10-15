using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrollManagement;

public enum Menu { Select, Registration, Login, Exit }
public enum subMenu { Select, CalculateSalary, DisplayDetails, Exit }

class Program
{
    public static List<EmployeeDetails> EmployeeList = new List<EmployeeDetails>();

    static EmployeeDetails LoggedInEmployee;
    public static void Main(string[] args)
    {

        bool run = true;

        System.Console.WriteLine("\n---------------------WELCOME TO SYNCFUSION EMPLOYEE PAYROLL PORTAL---------------------\n");


        do
        {

            // main menu
            Console.WriteLine("\nPlease choose: \n1. Registration\n2. Login\n3. Exit\nEither enter the number or enter the name as shown above.");

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
                        System.Console.WriteLine("THANK YOU FOR USING SYNCFUSION EMPLOYEE PAYROLL PORTAL, COME AGAIN!\n");
                        System.Console.WriteLine("\n---------------------------------------------------------------------------------------\n");
                        break;

                    default:
                        menuCheck = false;
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }

        } while (run);
    }

    public static void Registration()
    {
        // username
        bool userNameCheck = false;
        string userName;

        do
        {
            Console.Write("\nName: ");
            userName = Console.ReadLine();

            if (userName.Any(char.IsDigit)) Console.WriteLine("Name should not contain any numbers.");
            else userNameCheck = true;
        } while (!userNameCheck);

        bool roleCheck = false;
        string role;

        do
        {
            Console.Write("\nRole: ");
            role = Console.ReadLine();

            if (role.Any(char.IsDigit)) Console.WriteLine("Role should not contain any numbers.");
            else roleCheck = true;
        } while (!roleCheck);

        bool locationCheck;
        Location location;

        do
        {
            Console.WriteLine("\nEnter your work location: \n1. Chennai\n2. Bangalore\n3. Hyderabad\n4. Mumbai\nEither enter the number or enter the name as shown above.");
            Console.Write("Work Location: ");
            locationCheck = Enum.TryParse<Location>(Console.ReadLine(), true, out location);

            if ((!Enum.IsDefined(typeof(Location), location)) || (location == Location.Select)) locationCheck = false;

            if (!locationCheck) Console.WriteLine("Invalid Location. Please try again.");

        } while (!locationCheck);

        Console.Write("\nTeam Name: ");
        string teamName = Console.ReadLine();

        DateTime doj;
        bool dojCheck;

        do
        {
            Console.Write("\nEnter your DOJ: ");
            dojCheck = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out doj);

            if (!dojCheck) Console.WriteLine("Invalid date. Please try again.");
        } while (!dojCheck);

        int workDays;
        bool workDaysCheck;

        do
        {
            Console.Write("\nNumber of working days in this month: ");
            workDaysCheck = int.TryParse(Console.ReadLine(), out workDays);

            if (!workDaysCheck) Console.WriteLine("Invalid day. Please try again.");
            else if ((workDays < 1) || (workDays > 31))
            {
                workDaysCheck = false;
                Console.WriteLine("Invalid Days. Please try again.");
            }
        } while (!workDaysCheck);

        int leave;
        bool leaveCheck;

        do
        {
            Console.Write("\nLeaves in this month: ");
            leaveCheck = int.TryParse(Console.ReadLine(), out leave);

            if (!leaveCheck) Console.WriteLine("Invalid day. Please try again.");
            else if ((leave < 1) || (leave > workDays))
            {
                leaveCheck = false;
                Console.WriteLine("Invalid Days. Please try again.");
            }
        } while (!leaveCheck);

        // gender
        bool genderCheck = false;
        Gender gender;

        do
        {
            Console.WriteLine("\nSelect the gender: \n1. Male\n2. Female\nEither enter the number or enter the name as shown above.");
            Console.Write("Gender: ");
            genderCheck = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);

            if ((!Enum.IsDefined(typeof(Gender), gender)) || (gender == Gender.Select)) genderCheck = false;

            if (!genderCheck) Console.WriteLine("Invalid gender. Please try again.");

        } while (!genderCheck);

        EmployeeDetails employee = new EmployeeDetails(userName, role, location, teamName, doj, workDays, leave, gender);

        EmployeeList.Add(employee);

        Console.WriteLine($"Kindly Check Your Details\nPlease take note of your Employee ID\n\nEmployee ID: {employee.EmployeeID}\nName: {employee.Name}\nRole: {employee.Role}\nWork Location: {employee.Location}\nTeam Name: {employee.TeamName}\nDate of Joining: {employee.DOJ.ToString("dd/MM/yyyy")}\nWorkings Days: {employee.DaysWorked}\nLeaves Taken: {employee.LeaveTaken}\nGender: {employee.Gender}\n\nKindly make note of your Employee ID\nEmployee ID: {employee.EmployeeID}");
    }

    public static void Login()
    {
        bool IDCheck = false;

        do
        {
            Console.Write("\nEnter your Employee ID: ");
            string empID = Console.ReadLine();

            foreach (EmployeeDetails employee in EmployeeList)
            {
                if (empID.ToUpper() == employee.EmployeeID)
                {
                    IDCheck = true;

                    bool registeredUser = true;

                    LoggedInEmployee = employee;

                    do
                    {
                        bool subMenuCheck;
                        subMenu subTab;

                        do
                        {
                            Console.WriteLine("\nPlease choose any one from the below options.\n1.Calculate Salary\n2.Display Details\n3.Exit\nEither enter the number or enter the name as shown above.");
                            subMenuCheck = Enum.TryParse<subMenu>(Console.ReadLine(), true, out subTab);

                            if (!subMenuCheck) Console.WriteLine("Invalid Option. Please Try Again.");

                        } while (!subMenuCheck);

                        switch (subTab)
                        {
                            case subMenu.CalculateSalary:
                                double salary = LoggedInEmployee.CalculateSalary();
                                Console.WriteLine($"\nYour salary for this month is {salary}");
                                break;

                            case subMenu.DisplayDetails:
                                Console.WriteLine($"\nEmployee ID: {LoggedInEmployee.EmployeeID}\nName: {LoggedInEmployee.Name}\nRole: {LoggedInEmployee.Role}\nWork Location: {LoggedInEmployee.Location}\nTeam Name: {LoggedInEmployee.TeamName}\nDate of Joining: {LoggedInEmployee.DOJ.ToString("dd/MM/yyyy")}\nWorkings Days: {LoggedInEmployee.DaysWorked}\nLeaves Taken: {LoggedInEmployee.LeaveTaken}\nGender: {LoggedInEmployee.Gender}");
                                break;

                            case subMenu.Exit:
                                registeredUser = false;
                                break;
                        }
                    } while (registeredUser);
                }
            }

            if (!IDCheck) Console.WriteLine("Invalid Employee ID. Please Try Again.");

        } while (!IDCheck);
    }
}