namespace UltraCompta.Business.PrimaryPorts
{
    public interface ICreateInvoice
    {
        string Generate(string orderReference);
    }
}