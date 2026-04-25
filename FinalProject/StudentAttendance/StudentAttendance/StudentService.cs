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
            Console.WriteLine("Enter First Name ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name ");
            string lastName = Console.ReadLine();
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
                Console.WriteLine($"Current FIrst Name: {currentFirstname}");
                Console.WriteLine("Do you want to modify it? (Yes/No): ");
                string option = Console.ReadLine();
                string newFirstName = currentFirstname;
                if (option.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                {
                    while (true)
                    {
                        Console.Write("Enter new first name: ");
                        newFirstName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newFirstName))
                        {
                            Console.WriteLine("First name cannot be empty.");
                        }
                        else break;
                    }
                }
                Console.WriteLine($"Current Last Name: {currentLastname}");
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
