namespace UltraCompta.Web.Controllers
{
    public class CustomerSource
    {
        public static string GetCustomerCountry(string id)
        {
            return DatabaseAccess.GetCustomerCountry(id);
        }
    }
}