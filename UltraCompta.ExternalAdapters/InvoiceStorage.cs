using UltraCompta.Business;
using UltraCompta.Business.ExternalPorts;

namespace UltraCompta.ExternalAdapters
{
    public class InvoiceStorage : IInvoiceStorage
    {
        public void StoreInvoice(string invoice)
        {
            DatabaseAccess.StoreInvoice(invoice);
        }
    }
}