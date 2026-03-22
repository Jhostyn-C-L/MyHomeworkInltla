using Complementary_Homework;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Patient Registration System");
        Console.WriteLine("Welcome to your patient list");

        bool running = true;
        List<Patient> patients = new List<Patient>();

        while (running)
        {
            Console.Write("1. Add Patient      ");
            Console.Write("2. View Patients     ");
            Console.Write("3. Search Patient      ");
            Console.Write("4. Modify Patient        ");
            Console.Write("5. Delete Patient     ");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddPatient(patients);
                        break;
                    case 2:
                        ViewPatients(patients);
                        break;
                    case 3:
                        SearchPatient(patients);
                        break;
                    case 4:
                        EditPatient(patients);
                        break;
                    case 5:
                        DeletePatient(patients);
                        break;
                    case 6:
                        running = false;
                        Console.WriteLine("Thank you for whatching, my Patient Registration System");
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("An unexpected error has occurred, enter a valid number");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Error: Contact not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oh, apparently, an unexpected error has occurred." + ex.Message);
            }
        }

        static void AddPatient(List<Patient> patients)
        {
            string name;
            while (true)
            {
                Console.Write("Enter patient's name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name)) break;
                Console.WriteLine("Name cannot be empty.");
            }

            string age;
            while (true)
            {
                Console.Write("Enter patient's age: ");
                age = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(age) && age.All(char.IsDigit)) break;
                Console.WriteLine("Age must be numeric.");
            }

            string diagnosis;
            while (true)
            {
                Console.Write("Enter diagnosis: ");
                diagnosis = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(diagnosis)) break;
                Console.WriteLine("Diagnosis cannot be empty.");
            }

            string address;
            while (true)
            {
                Console.Write("Enter address: ");
                address = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(address)) break;
                Console.WriteLine("Address cannot be empty.");
            }

            int id = patients.Count > 0 ? patients.Max(p => p.Id) + 1 : 1;

            patients.Add(new Patient
            {
                Id = id,
                Name = name,
                Age = age,
                Diagnosis = diagnosis,
                Address = address
            });

            Console.WriteLine("Patient added successfully.");
        }

        static void ViewPatients(List<Patient> patients)
        {
            if (patients.Count == 0)
            {
                Console.WriteLine("No patients available.");
                return;
            }

            Console.WriteLine("Id    Name    Age    Diagnosis    Address");
            Console.WriteLine("________________________________________________");

            foreach (var p in patients)
            {
                Console.WriteLine($"{p.Id}   {p.Name}   {p.Age}   {p.Diagnosis}   {p.Address}");
            }
        }

        static void EditPatient(List<Patient> patients)
        {
            Console.WriteLine("Enter Patient ID to edit");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var patient = patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            Console.WriteLine("New name:");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                patient.Name = name;

            string age;
            while (true)
            {
                Console.WriteLine("New age:");
                age = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(age) && age.All(char.IsDigit)) break;
                Console.WriteLine("Age must be numeric.");
            }
            patient.Age = age;

            string diagnosis;
            while (true)
            {
                Console.WriteLine("New diagnosis:");
                diagnosis = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(diagnosis)) break;
                Console.WriteLine("Diagnosis cannot be empty.");
            }
            patient.Diagnosis = diagnosis;

            string address;
            while (true)
            {
                Console.WriteLine("New address:");
                address = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(address)) break;
                Console.WriteLine("Address cannot be empty.");
            }
            patient.Address = address;

            Console.WriteLine("Patient updated.");
        }

        static void DeletePatient(List<Patient> patients)
        {
            Console.WriteLine("Enter Patient ID to delete");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var patient = patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            Console.WriteLine("1. Yes  2. No");

            if (!int.TryParse(Console.ReadLine(), out int confirm))
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            if (confirm == 1)
            {
                patients.Remove(patient);
                Console.WriteLine("Patient deleted.");
            }
            else
            {
                Console.WriteLine("Operation canceled.");
            }
        }

        static void SearchPatient(List<Patient> patients)
        {
            Console.WriteLine("Enter Patient ID to search");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var patient = patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
            }
            else
            {
                Console.WriteLine($"{patient.Id} - {patient.Name} | {patient.Age} | {patient.Diagnosis} | {patient.Address}");
            }
        }
    }
}