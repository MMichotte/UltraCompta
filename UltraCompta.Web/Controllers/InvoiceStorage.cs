namespace UltraCompta.Web.Controllers
{
    public class InvoiceStorage : IInvoiceStorage
    {
        public void StoreInvoice(string invoice)
        {
            DatabaseAccess.StoreInvoice(invoice);
        }
    }
}