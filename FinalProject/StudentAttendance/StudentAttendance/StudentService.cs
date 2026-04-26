using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StudentAttendance
{
    public static class StudentService
    {
        public static void AddStudent()
        {
            string firstName;
            while (true)
            {
                Console.WriteLine("Enter First Name ");
                firstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    Console.WriteLine("First Name cannot be empty.");
                }
                else
                {
                    break;
                }
            }
            string lastName;
            while (true)
            {
                Console.WriteLine("Enter Last Name ");
                lastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("Last Name cannot be empty.");
                }
                else
                {
                    break;
                }
            }
            using (SqlConnection connection = new SqlConnection(DatabaseConnections.connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Students (FirstName, LastName) Values (@FirstName, @LastName)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Student added successfully");
        }
        public static void ViewStudents()
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnections.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Students";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("\nID | Name");
                Console.WriteLine("----------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Id"]} - {reader["FirstName"]} {reader["LastName"]}");
                }
            }
        }
        public static void SearchStudent()
        {
            Console.Write("Enter student ID to search: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id.");
                return;
            }
            using (SqlConnection connection = new SqlConnection(DatabaseConnections.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Students Where Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine($"\nStudent found:");
                    Console.WriteLine($"{reader["Id"]} - {reader["FirstName"]} {reader["LastName"]}");
                }
                else
                {
                    Console.WriteLine("Student not found");
                }
            }
        }
        private static bool Askyesorno(string message)
        {
            while (true)
            {
                Console.WriteLine(message + " (Yes/No):");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please, you must enter Yes or No.");
                    continue;
                }
                if (input.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                    return true;
                if (input.Equals("No", StringComparison.OrdinalIgnoreCase))
                    return false;
            }
        }
        public static void EditStudent()
        {
            Console.Write("Enter student ID to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(DatabaseConnections.connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Students Where Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    Console.WriteLine("Student found:");
                    return;
                }
                string currentFirstname = reader["FirstName"].ToString();
                string currentLastname = reader["LastName"].ToString();
                reader.Close();
                string newFirstName = currentFirstname;
                string newLastName = currentLastname;
                Console.WriteLine($"Current FIrst Name: {currentFirstname}");
                //string newFirstName = currentFirstname;

                if (Askyesorno("Do you want to modify it?"))
                {
                    while (true)
                    {
                        Console.Write("Enter new first name: ");
                        string input = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            Console.WriteLine("First name cannot be empty.");
                        }
                        else
                        {
                            newFirstName = input;
                            break;
                        }
                    }
                }
                /*
                Console.WriteLine("Do you want to modify it? (Yes/No): ");
                option = Console.ReadLine();
                string newLastName = currentLastname;
                if (option.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                {
                    while (true)
                    {
                        Console.Write("Enter new last name: ");
                        newLastName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newLastName))
                        {
                            Console.WriteLine("Last name cannot be empty.");
                        }
                        else break;
                    }
                }*/
                Console.WriteLine($"Current Last Name: {currentLastname}");
                if (Askyesorno("Do you want to modify it?"))
                {
                    while (true)
                    {
                        Console.Write("Enter new last name: ");
                        string input = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            Console.WriteLine("Last name cannot be empty.");
                        }
                        else
                        {
                            newLastName = input;
                            break;
                        }
                    }
                }
                string updatequery = @"UPDATE Students SET FirstName = @FirstName, LastName = @LastName
                                        WHERE Id = @Id";
                SqlCommand updatecmd = new SqlCommand(updatequery, connection);
                updatecmd.Parameters.AddWithValue("@FirstName", newFirstName);
                updatecmd.Parameters.AddWithValue("@LastName", newLastName);
                updatecmd.Parameters.AddWithValue("@Id", id);
                updatecmd.ExecuteNonQuery();
                Console.WriteLine("Student updated successfully");
            }
        }
        public static void DeletetStudent()
        {
            Console.Write("Enter student ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(DatabaseConnections.connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Students Where Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    Console.WriteLine("Student not found");
                    return;
                }

                string name = $"{reader["FirstName"]} {reader["LastName"]}";
                reader.Close();

                string attendanceQuery = "SELECT COUNT(*) FROM Attendance WHERE StudentId = @Id";
                SqlCommand attendanceCmd = new SqlCommand(@attendanceQuery, connection);
                attendanceCmd.Parameters.AddWithValue("@Id", id);

                int attendanceCount = (int)attendanceCmd.ExecuteScalar();

                if (attendanceCount > 0)
                {
                    Console.WriteLine("This student cannot be deleted.");
                    Console.WriteLine("Reason: attendance records are associated with this student.");
                    Console.WriteLine("Please delete attendance records first.");
                    return;
                }
                Console.WriteLine($"Are you sure you want to delete {name}?");
                Console.WriteLine("1.Yes 2.No:");

                if (!int.TryParse(Console.ReadLine(), out int confirm))
                {
                    Console.WriteLine("Invalid option.");
                    return;
                }
                if (confirm == 1)
                {
                    string deletequery = @"DELETE FROM Students WHERE Id = @Id";
                    SqlCommand deletecmd = new SqlCommand(deletequery, connection);
                    deletecmd.Parameters.AddWithValue("@Id", id);
                    deletecmd.ExecuteNonQuery();
                    Console.WriteLine("Student deleted successfully");
                }
                else
                {
                    Console.WriteLine("Operation canceled.");
                }
            }
        }
    }
}
