namespace UltraCompta.Business.ExternalPorts
{
    public interface ICustomerSource
    {
        string GetCustomerCountry(string id);
    }
}