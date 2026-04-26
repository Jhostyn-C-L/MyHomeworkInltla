using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StudentAttendance
{
    public static class DatabaseConnections
    {
        public static string connectionString =
            "Server=MSI\\SQLEXPRESS01;Database=StudentAttendancedb;Trusted_Connection=True";
    }
}
