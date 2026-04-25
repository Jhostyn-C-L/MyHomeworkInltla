using System;
using StudentAttendance;
//using StudentAttendanceSystem;

bool isrunning = true;
Console.WriteLine("Student Attendance System");
while (isrunning)
{
    Console.WriteLine("\n=== Main Menu ===");
    Console.WriteLine("1.Add Student    ");
    Console.WriteLine("2.View Students  ");
    Console.WriteLine("3.Search Student ");
    Console.WriteLine("4.Edit Student ");
    Console.WriteLine("5.Delete Student ");
    Console.WriteLine("6.Attendance Student ");
    Console.WriteLine("7.Exit");

    Console.Write("Choose an option: ");
    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Invalid Input. Please enter a number.");
        continue;
    }
    try
    {
        switch (choice)
        {
            case 1:
                StudentService.AddStudent();
                break;
            case 2:
                StudentService.ViewStudents();
                break;
            case 3:
                StudentService.SearchStudent();
                break;
            case 4:
                StudentService.EditStudent();
                break;
            case 5:
                StudentService.DeletetStudent();
                break;
            case 6:
                ShowAttendancemenu();
                break;
            case 7:                
                isrunning = false;
                Console.WriteLine("Thank you for watching, my Student Attendance System");
                break;
            default:
                Console.WriteLine("Invalid Option");
                break;
        }
    }
    catch (KeyNotFoundException)
    {
        Console.WriteLine("Error, not found.");
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

void ShowAttendancemenu()
{
    bool isattendancerunning = true;
    while (isattendancerunning)
    {
        Console.WriteLine("\n=== Attendance Menu ===");
        Console.WriteLine("1.Mark Attendance    ");
        Console.WriteLine("2.View Attendance by Date  ");
        Console.WriteLine("3.Back to Main Menu ");

        Console.Write("Choose an option: ");
        if (!int.TryParse(Console.ReadLine(), out int option))
        {
            Console.WriteLine("Invalid Input. Please enter a number.");
            continue;
        }
        try
        {
            switch (option)
            {
                case 1:
                    AttendanceService.MarkAttendance();
                    break;
                case 2:
                    AttendanceService.ViewAttendanceByDate();
                    break;
                case 3:
                    isattendancerunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("Error, not found.");
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
}