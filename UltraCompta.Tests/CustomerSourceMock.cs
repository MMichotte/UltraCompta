using UltraCompta.Business;
using UltraCompta.Business.ExternalPorts;
using UltraCompta.Web.Controllers;

namespace UltraCompta.Tests
{
    public class CustomerSourceMock : ICustomerSource
    {
        public string GetCustomerCountry(string id)
        {
            if (id == "C-9844")
            {
                return "BE";
            }
            return "IT";
        }
    }
}