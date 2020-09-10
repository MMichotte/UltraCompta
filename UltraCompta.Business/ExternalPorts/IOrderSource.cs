namespace UltraCompta.Business.ExternalPorts
{
    public interface IOrderSource
    {
        string GetOrder(string orderReference);
    }
}