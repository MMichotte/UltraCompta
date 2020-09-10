namespace UltraCompta.Web.Controllers
{
    public class InvoiceStorage
    {
        public static void StoreInvoice(string invoice)
        {
            DatabaseAccess.StoreInvoice(invoice);
        }
    }
}