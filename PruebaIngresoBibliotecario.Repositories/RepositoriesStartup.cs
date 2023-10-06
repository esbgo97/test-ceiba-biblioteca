using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PruebaIngresoBibliotecario.Database;
using PruebaIngresoBibliotecario.Repositories.Implementations;
using PruebaIngresoBibliotecario.Repositories.Interfaces;

namespace PruebaIngresoBibliotecario.Repositories
{
    public static class RepositoriesStartup
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPrestamoRepository, PrestamoRepository>();
        }
    }
}