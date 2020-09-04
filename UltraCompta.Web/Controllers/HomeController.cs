using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UltraCompta.Web.Models;

namespace UltraCompta.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<string> files = Directory.EnumerateFiles("C:/Dev/UltraCompta/InputFiles/");
            return View(files.Select(f => f.Replace("C:/Dev/UltraCompta/InputFiles/", "").Replace(".txt", "")));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GenerateInvoice(string orderReference)
        {
            string input = System.IO.File.ReadAllText("C:/Dev/UltraCompta/InputFiles/" + orderReference + ".txt");
            string name = input.Split("\r\n", StringSplitOptions.None)[1].Substring(8);
            string id = input.Split("\r\n", StringSplitOptions.None)[2].Substring(11);
            var invoice = "<html><style>table {border: 1px solid black;} tr:first-of-type {font-weight:bold;} td { padding: 5px;}</style><h1>Invoice " + orderReference + "</h1><p>Client name: " + name + "</p><p>Client id: " + id + 
                          "</p><table><tr><td>Description</td><td>Size</td><td>Quantity</td><td>Unit price</td><td>VAT</td><td>Total price</td></tr>";

            string iname = input.Split("\r\n", StringSplitOptions.None)[3].Substring(11);
            string size = input.Split("\r\n", StringSplitOptions.None)[4].Substring(6);
            string quant = input.Split("\r\n", StringSplitOptions.None)[5].Substring(10);
            string uprice = input.Split("\r\n", StringSplitOptions.None)[6].Substring(12);
            string cur = input.Split("\r\n", StringSplitOptions.None)[7].Substring(10);
            string tax = input.Split("\r\n", StringSplitOptions.None)[8].Substring(5);

            if (cur == "euro")
            {
                cur = "&euro;";
            }

            uprice = uprice.Replace('.', ',');

            invoice += "<tr><td>" + iname + "</td><td>" + size + "</td><td>" + quant + "</td><td>" + uprice + " " + cur + "</td><td>" + tax.Replace("%", "&percnt;") + "</td><td>";
            var taxD = Convert.ToDouble(tax.Replace("%", ""));
            invoice += ((Convert.ToDouble(uprice) + Convert.ToDouble(uprice) * (DatabaseAccess.GetCustomerCountry(id) == "BE" ? taxD : 0) / 100) * Convert.ToInt32(quant)).ToString("F");
            invoice += " " + cur + "</td></tr>";
            
            if (input.Contains("Item name2"))
            {
                string iname2 = input.Split("\r\n", StringSplitOptions.None)[9].Substring(12);
                string size2 = input.Split("\r\n", StringSplitOptions.None)[10].Substring(7);
                string quant2 = input.Split("\r\n", StringSplitOptions.None)[11].Substring(11);
                string uprice2 = input.Split("\r\n", StringSplitOptions.None)[12].Substring(13);
                string cur2 = input.Split("\r\n", StringSplitOptions.None)[13].Substring(11);
                string tax2 = input.Split("\r\n", StringSplitOptions.None)[14].Substring(6);
                
                if (cur2 == "euro")
                {
                    cur2 = "&euro;";
                }
                uprice2 = uprice2.Replace('.', ',');

                invoice += "<tr><td>" + iname2 + "</td><td>" + size2 + "</td><td>" + quant2 + "</td><td>" + uprice2 + " " + cur2 + "</td><td>" + tax2.Replace("%", "&percnt;") + "</td><td>";
                var taxD2 = Convert.ToDouble(tax2.Replace("%", ""));
                invoice += ((Convert.ToDouble(uprice2) + Convert.ToDouble(uprice2) * (DatabaseAccess.GetCustomerCountry(id) == "BE" ? taxD2 : 0) / 100) * Convert.ToInt32(quant2)).ToString("F");
                invoice += " " + cur2 + "</td></tr>";
            }

            DatabaseAccess.StoreInvoice(invoice);

            return Content(invoice + "</table></html>", "text/html");
        }
    }
}
