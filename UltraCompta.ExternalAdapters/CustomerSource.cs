using UltraCompta.Business;
using UltraCompta.Business.ExternalPorts;

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