namespace UltraCompta.Business
{
    public interface IOrderSource
    {
        string GetOrder(string orderReference);
    }
}