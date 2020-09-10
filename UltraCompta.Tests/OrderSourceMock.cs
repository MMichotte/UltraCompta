using UltraCompta.Business;
using UltraCompta.Business.ExternalPorts;
using UltraCompta.Web.Controllers;

namespace UltraCompta.Tests
{
    public class OrderSourceMock : IOrderSource
    {
        public string GetOrder(string orderReference)
        {
            return orderReference switch
            {
                "GDE948" => "Order number: GDE948\r\nClient: Ferrero\r\nClient id: C-9843\r\nItem name: Nutella\r\nSize: 975 g\r\nQuantity: 10\r\nUnit price: 4.85\r\nCurrency: euro\r\nVat: 6%",
                "GDE949" => "Order number: GDE949\r\nClient: Ferrero\r\nClient id: C-9843\r\nItem name: Nutella\r\nSize: 975 g\r\nQuantity: 10\r\nUnit price: 4.85\r\nCurrency: euro\r\nVat: 6%\r\nItem name2: Nutella\r\nSize2: 750 g\r\nQuantity2: 2\r\nUnit price2: 3.50\r\nCurrency2: euro\r\nVat2: 6%",
                "GDE950" => "Order number: GDE950\r\nClient: Kwatta\r\nClient id: C-9844\r\nItem name: Pate a tartiner\r\nSize: 500 g\r\nQuantity: 3\r\nUnit price: 3.25\r\nCurrency: euro\r\nVat: 6%"
            };
        }
    }
}