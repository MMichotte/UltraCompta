using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UltraCompta.Web.Models;

namespace UltraCompta.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GenerateInvoice(string orderReference)
        {
            string input = System.IO.File.ReadAllText("C:/Dev/UltraCompta/InputFiles/" + orderReference + ".txt");
            var name = input.Split("\r\n", StringSplitOptions.None)[1].Substring(8);
            var id = input.Split("\r\n", StringSplitOptions.None)[2].Substring(11);
            var iname = input.Split("\r\n", StringSplitOptions.None)[3].Substring(11);
            var size = input.Split("\r\n", StringSplitOptions.None)[4].Substring(6);
            var quant = input.Split("\r\n", StringSplitOptions.None)[5].Substring(10);
            var uprice = input.Split("\r\n", StringSplitOptions.None)[6].Substring(12);
            var cur = input.Split("\r\n", StringSplitOptions.None)[7].Substring(10);
            var tax = input.Split("\r\n", StringSplitOptions.None)[8].Substring(5);

            if (cur == "euro")
            {
                cur = "&euro;";
            }

            uprice = uprice.Replace('.', ',');

            return Content("<html><h1>Invoice " + orderReference + "</h1><p>Client name: " + name + "</p><p>Client id: " + id + 
                           "</p><table><tr><td>Description</td><td>Size</td><td>Quantity</td><td>Unit price</td><td>VAT</td><td>Total price</td></tr>" +
                           "<tr><td>" + iname + "</td><td>" + size + "</td><td>" + quant + "</td><td>" + uprice + " " + cur + "</td><td>" + tax.Replace("%", "") + "</td><td>" + 
                           (Convert.ToDouble(uprice) + Convert.ToDouble(uprice) * Convert.ToDouble(tax.Replace("%", ""))/100) * Convert.ToInt32(quant) + " " + cur + "</td></tr></table></html>", "text/html");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
