using System.Collections;
using System.Data.SqlClient;
using MySqlConnector;
namespace Blazor_Project.Models
{
    public class mySQLSqlHelper
    {
        //this field gets initialized at Startup.cs
        public static string? conStr;
        public static MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(conStr);
                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
