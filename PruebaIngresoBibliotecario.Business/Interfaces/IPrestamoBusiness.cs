using PruebaIngresoBibliotecario.Models.Entity;

namespace PruebaIngresoBibliotecario.Business.Interfaces
{
    public interface IPrestamoBusiness : IEntityBusiness<Prestamo>
    {
        Task<Prestamo> GetPrestamoByGuid(string identificacion);
        Task<Prestamo> SavePrestamoAsync(Prestamo Prestamo);
    }
}
