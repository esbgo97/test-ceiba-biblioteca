using PruebaIngresoBibliotecario.Models.Entity;

namespace PruebaIngresoBibliotecario.Repositories.Interfaces
{
    public interface IPrestamoRepository : IEntityRepository<Prestamo>
    {
        Task<List<Prestamo>> GetPrestamosByUser(string identificacion);
        Task<Prestamo> GetPrestamoByGuid(Guid guidPrestamo);
    }
}
