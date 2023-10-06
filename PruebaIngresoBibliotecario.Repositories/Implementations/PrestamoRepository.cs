using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Database;
using PruebaIngresoBibliotecario.Models.Entity;
using PruebaIngresoBibliotecario.Repositories.Interfaces;

namespace PruebaIngresoBibliotecario.Repositories.Implementations
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly PersistenceContext _context;
        public PrestamoRepository(DbContext context)
        {
            _context = (PersistenceContext)context;
        }

        public async Task<bool> Delete(Prestamo entity)
        {
            var item = await _context.Prestamos
                .FirstOrDefaultAsync(p => p.GuidPrestamo == entity.GuidPrestamo);

            if (item != null)
            {
                _context.Prestamos.Remove(item).State = EntityState.Deleted;
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<Prestamo>> GetAll(Prestamo entityFilter)
        {
            var prestamo = await _context.Prestamos
              //.Where(p => entityFilter.IdentificacionUsuario == identificacion)
              .ToListAsync();

            return prestamo;
        }

        public async Task<Prestamo> GetPrestamoByGuid(Guid guidPrestamo)
        {
            return await _context.Prestamos.FirstOrDefaultAsync(p => p.GuidPrestamo == guidPrestamo);
        }

        public async Task<List<Prestamo>> GetPrestamosByUser(string identificacion)
        {
            var prestamos = await _context.Prestamos
                .Where(p => p.IdentificacionUsuario == identificacion)
                .ToListAsync();

            return prestamos;
        }

        public async Task<Prestamo> Save(Prestamo entity)
        {
            entity.GuidPrestamo = Guid.NewGuid();

            _context.Prestamos.Add(entity).State = EntityState.Added;

            var result = await _context.SaveChangesAsync() > 0;
            if (result)
            {
                return entity;
            }
            else
            {
                throw new ApplicationException("Error Guardando");
            }
        }


        public async Task<bool> Update(Prestamo entity)
        {
            var prestamo = await _context.Prestamos
                .FirstOrDefaultAsync(p => p.GuidPrestamo == entity.GuidPrestamo);
            if (prestamo != null)
            {
                /*TODO: */
                return true;
            }
            return false;
        }
    }
}
