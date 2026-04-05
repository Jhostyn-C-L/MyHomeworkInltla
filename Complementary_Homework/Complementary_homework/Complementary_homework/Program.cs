using Complementary_homework;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

Console.WriteLine("Patient registration System");
Console.WriteLine("Hi, Welcome to your patient list");
bool running = true;
List<Patient> patients = new List<Patient>();
while (running)
{
    Console.Write("1.Add Patient    ");
    Console.Write("2.View Patients  ");
    Console.Write("3.Search Patient ");
    Console.Write("4.Modify Patient ");
    Console.Write("5.Delete Patient ");
    Console.WriteLine("6.Exit");
    Console.Write("Choose an option: ");
    try
    {
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                PatientService.AddPatient(patients);
                break;
            case 2:
                PatientService.ViewPatients(patients);
                break;
            case 3:
                PatientService.SearchPatient(patients);
                break;
            case 4:
                PatientService.EditPatient(patients);
                break;
            case 5:
                PatientService.DeletePatient(patients);
                break;
            case 6:
                running = false;
                Console.WriteLine("Thank you for watching, my Patient registration System");
                break;
            default:
                Console.WriteLine("Invalid Option");
                break;
        }
    }
    catch (KeyNotFoundException)
    {
        Console.WriteLine("Error, contact nof found.");
    }
    catch (FormatException)
    {
        Console.WriteLine("An unexpected error has occurred, please enter a valid number");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Oh, apparently, an unexpected error has occurred." + ex.Message);
    }
}

