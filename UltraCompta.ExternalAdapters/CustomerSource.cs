using UltraCompta.Business;

namespace UltraCompta.ExternalAdapters
{
    public class CustomerSource : ICustomerSource
    {
        public string GetCustomerCountry(string id)
        {
            return DatabaseAccess.GetCustomerCountry(id);
        }
    }
}