namespace UltraCompta.Web.Controllers
{
    public class CustomerSource
    {
        public string GetCustomerCountry(string id)
        {
            return DatabaseAccess.GetCustomerCountry(id);
        }
    }
}