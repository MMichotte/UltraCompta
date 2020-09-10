using System;
using UltraCompta.Business.ExternalPorts;
using UltraCompta.Business.PrimaryPorts;

namespace UltraCompta.Business.Commands
{
    public class CreateOrderCommand : ICreateOrder
    {
        private IOrderSource _orderSource;
        private ICustomerSource _customerSource;
        private IInvoiceStorage _invoiceStorage;

        public CreateOrderCommand(IOrderSource orderSource, ICustomerSource customerSource, IInvoiceStorage invoiceStorage)
        {
            _orderSource = orderSource;
            _customerSource = customerSource;
            _invoiceStorage = invoiceStorage;
        }

        public string Generate(string orderReference)
        {
            string input = _orderSource.GetOrder(orderReference);
            string name = input.Split("\r\n")[1].Substring(8);
            string id = input.Split("\r\n")[2].Substring(11);
            var invoice = "<html><style>table {border: 1px solid black;} tr:first-of-type {font-weight:bold;} td { padding: 5px;}</style><h1>Invoice " + orderReference + "</h1><p>Client name: " + name + "</p><p>Client id: " + id +
                          "</p><table><tr><td>Description</td><td>Size</td><td>Quantity</td><td>Unit price</td><td>VAT</td><td>Total price</td></tr>";

            string iname = input.Split("\r\n")[3].Substring(11);
            string size = input.Split("\r\n")[4].Substring(6);
            string quant = input.Split("\r\n")[5].Substring(10);
            string uprice = input.Split("\r\n")[6].Substring(12);
            string cur = input.Split("\r\n")[7].Substring(10);
            string tax = input.Split("\r\n")[8].Substring(5);

            if (cur == "euro")
            {
                cur = "&euro;";
            }

            uprice = uprice.Replace('.', ',');

            invoice += "<tr><td>" + iname + "</td><td>" + size + "</td><td>" + quant + "</td><td>" + uprice + " " + cur + "</td><td>" + tax.Replace("%", "&percnt;") + "</td><td>";
            var taxD = Convert.ToDouble(tax.Replace("%", ""));
            invoice += ((Convert.ToDouble(uprice) + Convert.ToDouble(uprice) * (_customerSource.GetCustomerCountry(id) == "BE" ? taxD : 0) / 100) * Convert.ToInt32(quant)).ToString("F");
            invoice += " " + cur + "</td></tr>";

            if (input.Contains("Item name2"))
            {
                string iname2 = input.Split("\r\n")[9].Substring(12);
                string size2 = input.Split("\r\n")[10].Substring(7);
                string quant2 = input.Split("\r\n")[11].Substring(11);
                string uprice2 = input.Split("\r\n")[12].Substring(13);
                string cur2 = input.Split("\r\n")[13].Substring(11);
                string tax2 = input.Split("\r\n")[14].Substring(6);

                if (cur2 == "euro")
                {
                    cur2 = "&euro;";
                }

                uprice2 = uprice2.Replace('.', ',');

                invoice += "<tr><td>" + iname2 + "</td><td>" + size2 + "</td><td>" + quant2 + "</td><td>" + uprice2 + " " + cur2 + "</td><td>" + tax2.Replace("%", "&percnt;") + "</td><td>";
                var taxD2 = Convert.ToDouble(tax2.Replace("%", ""));
                invoice += ((Convert.ToDouble(uprice2) + Convert.ToDouble(uprice2) * (_customerSource.GetCustomerCountry(id) == "BE" ? taxD2 : 0) / 100) * Convert.ToInt32(quant2)).ToString("F");
                invoice += " " + cur2 + "</td></tr>";
            }

            invoice += "</table></html>";

            _invoiceStorage.StoreInvoice(invoice);
            return invoice;
        }
    }
}