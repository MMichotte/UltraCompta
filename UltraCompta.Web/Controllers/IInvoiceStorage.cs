namespace UltraCompta.Web.Controllers
{
    public interface IInvoiceStorage
    {
        void StoreInvoice(string invoice);
    }
}