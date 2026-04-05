using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complementary_homework
{
    public static class PatientService
    {
        public static void AddPatient(List<Patient> patients)
        {
            string name;
            while (true)
            {
                Console.Write("Enter patient's Name: ");
                name = Console.ReadLine();
                if (ValidatorPatient.IsNameValid(name)) break;
                Console.WriteLine("Name cannot be empty.");
            }
            string age;
            while (true)
            {
                Console.Write("Enter patient's Age: ");
                age = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(age))
                {
                    Console.WriteLine("Age cannot be empty.");
                }
                else if (!ValidatorPatient.IsAgeValid(age, out int ageValue))
                {
                    Console.WriteLine("Usually the age must be between 1 and 119.");
                }
                else
                {
                    break;
                }
            }
            string diagnosis;
            while (true)
            {
                Console.Write("Enter patient's diagnosis: ");
                diagnosis = Console.ReadLine();
                if (ValidatorPatient.IsDiagnosisValid(diagnosis)) break;
                Console.WriteLine("Diagnosis cannot be empty.");
            }
            string address;
            while (true)
            {
                Console.Write("Enter patient's address: ");
                address = Console.ReadLine();
                if (ValidatorPatient.IsAddressValid(address)) break;
                Console.WriteLine("Address cannot be empty.");
            }
            string bloodType;
            Console.WriteLine("A warning, blood type cannot be modified later...");
            Console.WriteLine("enter the correct value(or correct blood type):");
            Console.WriteLine("O+, O-, A+, A-, B+, B-, AB+ or AB-");
            while (true)
            {
                Console.Write("Enter patient's blood type: ");
                bloodType = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(bloodType))
                {
                    Console.WriteLine("Blood type cannot be empty.");
                }
                else if (!ValidatorPatient.IsBloodTypeValid(bloodType))
                {
                    Console.WriteLine("An invalid blood type has been entered... remember, the valid types are:");
                    Console.WriteLine("O+, O-, A+, A-, B+, B-, AB+ or AB-");
                }
                else
                {
                    bloodType = bloodType.ToUpper();
                    break;
                }
            }
            int id = patients.Count > 0 ? patients.Max(p => p.Id) + 1 : 1;

            patients.Add(new Patient
            {
                Id = id,
                Name = name,
                Age = age,
                Diagnosis = diagnosis,
                Address = address,
                BloodType = bloodType
            });

            Console.WriteLine("Patient added successfully.");
        }
        public static void ViewPatients(List<Patient> patients)
        {
            if (patients.Count == 0)
            {
                Console.WriteLine("No patients available.");
                return;
            }

            Console.WriteLine("Id    Name    Age    Diagnosis    Address   BloodType");
            Console.WriteLine("_____________________________________________________________");

            foreach (var p in patients)
            {
                Console.WriteLine($"{p.Id}   {p.Name}   {p.Age}   {p.Diagnosis}   {p.Address}   {p.BloodType}");
            }
        }
        public static void DeletePatient(List<Patient> patients)
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
        public static void SearchPatient(List<Patient> patients)
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
                Console.WriteLine($"{patient.Id} - {patient.Name} | {patient.Age} | {patient.Diagnosis} | {patient.Address} | {patient.BloodType}");
            }
        }
        public static void EditPatient(List<Patient> patients)
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

            bool Nname = true;
            while (Nname)
            {
                Console.WriteLine("Do you want modify name? Press Yes or No");
                string nameVerify = Console.ReadLine();
                if (nameVerify?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Console.WriteLine("New name:");
                    string newname = Console.ReadLine();
                    if (!ValidatorPatient.IsNameValid(newname))
                    {
                        Console.WriteLine("Name cannot be empty...");
                    }
                    else
                    {
                        patient.Name = newname;
                        Console.WriteLine("Name updated succesfully");
                        Nname = false;
                    }
                }
                else if (nameVerify?.Equals("No", StringComparison.OrdinalIgnoreCase) == true)
                {
       
                        Console.WriteLine($"Understood, the name {patient.Name} will be kept");
                             Nname = false;
                }
                else
                {
                    Console.WriteLine("This is invalid");
                }
            }

            bool Nage = true;
            while (Nage)
            {
                Console.WriteLine("Do you want modify age? Press Yes or No");
                string ageVerify = Console.ReadLine();
                if (ageVerify?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Console.WriteLine("New age:");
                    string age = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(age))
                    {
                        Console.WriteLine("Age cannot be empty.");
                    }
                    else if(!ValidatorPatient.IsAgeValid(age, out int ageValue))
                    {
                        Console.WriteLine("Usually the age must be between 1 and 119...");
                    }
                    else
                    {
                        patient.Age = age;
                        Console.WriteLine("Age updated succesfully");
                        Nage = false;
                    }
                }
                else if (ageVerify?.Equals("No", StringComparison.OrdinalIgnoreCase) == true)
                {
                        Console.WriteLine($"Understood, the age {patient.Age} will be kept");
                              Nage = false;
                }
                else
                {
                    Console.WriteLine("This is invalid");
                }
            }
            bool Ndiagnosis = true;
            while (Ndiagnosis)
            {
                Console.WriteLine("Do you want modify diagnosis? Press Yes or No");
                string diagnosisVerify = Console.ReadLine();

                if (diagnosisVerify?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Console.WriteLine("New diagnosis:");
                    string diagnosis = Console.ReadLine();

                    if (!ValidatorPatient.IsDiagnosisValid(diagnosis))
                    {
                        Console.WriteLine("Diagnosis cannot be empty.");
                    }
                    else
                    {
                        patient.Diagnosis = diagnosis;
                        Console.WriteLine("Diagnosis updated succesfully");
                        Ndiagnosis = false;
                    }
                }
                else if (diagnosisVerify?.Equals("No", StringComparison.OrdinalIgnoreCase) == true)
                {
                        Console.WriteLine($"Understood, the Diagnosis {patient.Diagnosis} will be kept");
                          Ndiagnosis = false;
                }
                else
                {
                    Console.WriteLine("This is invalid");
                }
            }

            bool Naddress = true;
            while (Naddress)
            {
                Console.WriteLine("Do you want modify address? Press Yes or No");
                string addressVerify = Console.ReadLine();

                if (addressVerify?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true)
                {

                    Console.WriteLine("New address:");
                    string address = Console.ReadLine();
                    if (!ValidatorPatient.IsAddressValid(address))
                    {
                        Console.WriteLine("Address cannot be empty.");
                    }
                    else
                    {
                        patient.Address = address;
                        Console.WriteLine("Address updated succesfully.");
                        Naddress = false;
                    }
                }
                else if (addressVerify?.Equals("No", StringComparison.OrdinalIgnoreCase) == true)
                {
                        Console.WriteLine($"Understood, the address {patient.Address} will be kept");
                           Naddress = false;
                }
                else
                {
                    Console.WriteLine("This is invalid");
                }
            }
            Console.WriteLine("Patient updated");
            Console.WriteLine($"just in case, remember, blood type cannot be modified, current value: {patient.BloodType}");
        }
    }
}
