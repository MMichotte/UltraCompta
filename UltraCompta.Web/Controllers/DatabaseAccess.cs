using Microsoft.Data.Sqlite;

namespace UltraCompta.Web.Controllers
{
    // THIS CLASS MAY NOT BE CHANGED!
    public static class DatabaseAccess
    {
        public static void StoreInvoice(string invoice)
        {
            using (var connection = new SqliteConnection("Data Source=C:\\Temp\\UltraComptaInvoices.db;Mode=" + SqliteOpenMode.ReadWrite))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Invoice (Content) VALUES ('" + invoice + "');";

                command.ExecuteNonQuery();
            }
        }
        public static string GetCustomerCountry(string customerId)
        {
            using (var connection = new SqliteConnection("Data Source=C:\\Temp\\UltraComptaInvoices.db;Mode=" + SqliteOpenMode.ReadWrite))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"select Country FROM Client WHERE Id = '" + customerId + "'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                }
            }

            return null;
        }
    }
}