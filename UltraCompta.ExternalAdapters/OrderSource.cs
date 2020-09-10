using UltraCompta.Business;

namespace UltraCompta.ExternalAdapters
{
    public class OrderSource : IOrderSource
    {
        public string GetOrder(string orderReference)
        {
            return System.IO.File.ReadAllText("C:/Dev/UltraCompta/InputFiles/" + orderReference + ".txt");
        }
    }
}