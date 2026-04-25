using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendance
{
    public static class AttendanceService
    {
        public static void MarkAttendance()
        {
            Console.Write("Enter Student Id: ");
            int studentid = int.Parse(Console.ReadLine());
            Console.Write("Enter status(Present/Absent):");
            string status = Console.ReadLine();
            DateTime date = DateTime.Now.Date;

            using (SqlConnection connection = new SqlConnection(DatabaseConnections.connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Attendance (StudentId, Date, Status) Values (@StudentId, @Date, @Status)";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@StudentId", studentid);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Attendance recorded successfully");
        }
        public static void ViewAttendanceByDate()
        {
            Console.WriteLine("Enter date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(DatabaseConnections.connectionString))
            {
                connection.Open();
                string query = @"SELECT s.FirstName, s.LastName, a.Status
                FROM Attendance a JOIN Students s ON a.StudentId = s.Id
                Where a.Date = @Date";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Date", date);

                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("\nAttendance List:");
                Console.WriteLine("----------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]} - {reader["Status"]}");
                }
            }
        }
    }
}
