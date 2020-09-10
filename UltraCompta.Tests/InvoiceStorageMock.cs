using UltraCompta.Business;
using UltraCompta.Business.ExternalPorts;
using UltraCompta.Web.Controllers;

namespace UltraCompta.Tests
{
    public class InvoiceStorageMock : IInvoiceStorage
    {
        public void StoreInvoice(string invoice)
        {
            
        }
    }
}