using Microsoft.Extensions.DependencyInjection;
using PruebaIngresoBibliotecario.Business.Implementations;
using PruebaIngresoBibliotecario.Business.Interfaces;

namespace PruebaIngresoBibliotecario.Business
{
    public static class BusinessStartup
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<IPrestamoBusiness, PrestamoBusiness>();
        }
    }
}