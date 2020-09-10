namespace UltraCompta.Web.Controllers
{
    public class CustomerSource : ICustomerSource
    {
        public string GetCustomerCountry(string id)
        {
            return DatabaseAccess.GetCustomerCountry(id);
        }
    }
}