using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using UltraCompta.Web.Controllers;

namespace UltraCompta.Web
{
    public class CompositionRoot : IControllerActivator
    {
        public object Create(ControllerContext context)
        {
            if (context.ActionDescriptor.ControllerTypeInfo == typeof(HomeController))
            {
                return new HomeController(new OrderSource(), new CustomerSource(), new InvoiceStorage());
            }
 
            return null;
        }

        public void Release(ControllerContext context, object controller)
        {
            
        }
    }}