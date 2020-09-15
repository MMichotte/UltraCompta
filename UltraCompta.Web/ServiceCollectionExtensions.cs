using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace UltraCompta.Web
{
    public static class ServiceCollectionExtensions
    {
        public static void UseCompositionRootInsteadOfIocContainer(this IServiceCollection services)
        {
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, CompositionRoot>());
        }
    }
}