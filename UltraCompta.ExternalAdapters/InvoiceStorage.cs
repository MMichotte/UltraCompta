using UltraCompta.Business;

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