using System;
using System.Collections.Generic;
using System.Numerics;
namespace CollegeAdmission;


class Program
{

    public static void Main(string[] args)
    {
        CustomList<StudentDetails> studentDetails = new CustomList<StudentDetails>();

        string choice;
        do
        {
            
            System.Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            System.Console.WriteLine("Enter Father's Name: ");
            string fatherName = Console.ReadLine();
            System.Console.WriteLine("Enter DOB: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            System.Console.WriteLine("Enter Physics Mark (out of 100): ");
            int physicsMark = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Enter Chemistry Mark (out of 100): ");
            int chemistyMark = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Enter Maths Mark (out of 100): ");
            int mathsMark = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Enter Gender: \n1.Male \n2.Female \n3.Other \nEnter the respective digit:");
            int gender = Convert.ToInt32(Console.ReadLine());
            GenderEnum genderChoice = (GenderEnum)gender;
            StudentDetails studentC = new StudentDetails(name, fatherName, dob, physicsMark, chemistyMark, mathsMark, genderChoice);

            studentDetails.Add(studentC);

            System.Console.WriteLine("Do you want to enter another student detail?");
            choice = Console.ReadLine().ToLower();

            while (choice != "yes" && choice != "no")
            {
                System.Console.WriteLine("Invalid choice, Enter Yes or No: ");
                choice = Console.ReadLine().ToLower();
            }
        } while (choice == "yes");

        foreach (StudentDetails student in studentDetails)
        {
            System.Console.WriteLine($"\n\n Student Name: {student.StudentName}\n Father's Name: {student.FatherName}\n D.O.B: {student.DOB.ToString("dd/MM/yyyy")}\n Total Marks: {student.TotalMarks()}");
            System.Console.WriteLine(student.IsEligible() ? " Eligible for Admission\n\n" : " Not Eligible for Admission\n\n");
        }
    }
}