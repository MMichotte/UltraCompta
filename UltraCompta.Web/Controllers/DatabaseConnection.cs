using Microsoft.Data.Sqlite;

namespace UltraCompta.Web.Controllers
{
    public static class DatabaseConnection
    {
        public static void StoreInvoice(string invoice)
        {
            using (var connection = new SqliteConnection("Data Source=C:\\Dev\\UltraCompta\\Database\\UltraComptaInvoices.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Invoice (Content) VALUES ('" + invoice + "');";

                command.ExecuteNonQuery();
            }            
        }
    }
}