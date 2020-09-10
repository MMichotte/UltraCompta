namespace UltraCompta.Business.ExternalPorts
{
    public interface IInvoiceStorage
    {
        void StoreInvoice(string invoice);
    }
}