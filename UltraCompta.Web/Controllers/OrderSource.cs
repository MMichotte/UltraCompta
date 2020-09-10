namespace UltraCompta.Web.Controllers
{
    public class OrderSource
    {
        public static string GetOrder(string orderReference)
        {
            return System.IO.File.ReadAllText("C:/Dev/UltraCompta/InputFiles/" + orderReference + ".txt");
        }
    }
}