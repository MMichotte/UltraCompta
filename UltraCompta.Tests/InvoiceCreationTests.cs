using FluentAssertions;
using UltraCompta.Web.Controllers;
using Xunit;

namespace UltraCompta.Tests
{
    public class InvoiceCreationTests
    {
        [Fact]
        public void Generate_invoice()
        {
            var controller = new HomeController();

            var invoice = controller.GenerateInvoice("GDE948").Response();

            invoice.Should().Be("<html><style>table {border: 1px solid black;} tr:first-of-type {font-weight:bold;} td { padding: 5px;}</style><h1>Invoice GDE948</h1><p>Client name: Ferrero</p><p>Client id: C-9843</p><table><tr><td>Description</td><td>Size</td><td>Quantity</td><td>Unit price</td><td>VAT</td><td>Total price</td></tr><tr><td>Nutella</td><td>975 g</td><td>10</td><td>4,85 &euro;</td><td>6&percnt;</td><td>48,50 &euro;</td></tr></table></html>");
        }
    }
}
