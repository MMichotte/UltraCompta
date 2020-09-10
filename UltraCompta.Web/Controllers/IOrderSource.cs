namespace UltraCompta.Web.Controllers
{
    public interface IOrderSource
    {
        string GetOrder(string orderReference);
    }
}