using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace UltraCompta.Web.Controllers
{
    public class CompositionRoot : IControllerActivator
    {
        public object Create(ControllerContext context)
        {
            if (context.ActionDescriptor.ControllerTypeInfo == typeof(HomeController))
            {
                return new HomeController();
            }
 
            return null;
        }

        public void Release(ControllerContext context, object controller)
        {
            
        }
    }}