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
            if (!int.TryParse(Console.ReadLine(), out int studentid))
            {
                Console.WriteLine("Invalid Id.");
                return;
            }
            string status;
            while (true)
            {
                Console.Write("Enter status(Present/Absent):");
                status = Console.ReadLine();
                if (status.Equals("Present", StringComparison.OrdinalIgnoreCase) ||
                    status.Equals("Absent", StringComparison.OrdinalIgnoreCase))
                {
                    status = char.ToUpper(status[0]) + status.Substring(1).ToLower();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid status. Please just enter 'Present' or 'Absent'.");
                }
            }
            
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
