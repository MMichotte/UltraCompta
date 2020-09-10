namespace UltraCompta.Business.PrimaryPorts
{
    public interface ICreateOrder
    {
        string Generate(string orderReference);
    }
}