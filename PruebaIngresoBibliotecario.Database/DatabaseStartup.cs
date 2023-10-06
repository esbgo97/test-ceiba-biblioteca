using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PruebaIngresoBibliotecario.Database
{
    public static class DatabaseStartup
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<PersistenceContext>(opt =>
            {
                opt.UseInMemoryDatabase("PruebaIngreso");
            });

            services.AddScoped<DbContext, PersistenceContext>();
        }
    }
}