using PruebaIngresoBibliotecario.Models.Entity;
using PruebaIngresoBibliotecario.Business.Interfaces;
using PruebaIngresoBibliotecario.Business.Utils;
using PruebaIngresoBibliotecario.Repositories.Implementations;
using PruebaIngresoBibliotecario.Repositories.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PruebaIngresoBibliotecario.Business.Implementations
{
    public class PrestamoBusiness : IPrestamoBusiness
    {
        private readonly IPrestamoRepository _prestamoRepository;
        public PrestamoBusiness(IPrestamoRepository prestamoRepository)
        {
            _prestamoRepository = prestamoRepository;
        }

        public async Task<Prestamo> GetPrestamoByGuid(string identificacion)
        {
            Guid guid;
            if (Guid.TryParse(identificacion, out guid))
            {
                var result =  await _prestamoRepository.GetPrestamoByGuid(guid);
                return result;
            }
            else
            {
                throw new ApplicationException("El Guid no es válido.");
            }
            
        }

        public async Task<Prestamo> SavePrestamoAsync(Prestamo prestamo)
        {
            switch (prestamo.TipoUsuario)
            {
                case (int)UserTypeEnum.AFILIADO:
                    return await PrestarAfiliado(prestamo);

                case (int)UserTypeEnum.EMPLEADO:
                    return await PrestarEmpleado(prestamo);

                case (int)UserTypeEnum.INVITADO:
                    return await PrestarInvitado(prestamo);

                default:
                    throw new ApplicationException("Tipo de Usuario no válido.");
            }
        }

        private async Task<Prestamo> PrestarAfiliado(Prestamo prestamo)
        {
            prestamo.FechaMaximaDevolucion = LaboralDaysCounter.CalculateDevolutionDate(DateTime.Now, 10);
            return await Save(prestamo);
        }

        private async Task<Prestamo> PrestarInvitado(Prestamo prestamo)
        {
            var prestados = await _prestamoRepository.GetPrestamosByUser(prestamo.IdentificacionUsuario);

            if (prestados.Count > 0)
                throw new ApplicationException($"El usuario con identificacion {prestamo.IdentificacionUsuario} ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo");

            prestamo.FechaMaximaDevolucion = LaboralDaysCounter.CalculateDevolutionDate(DateTime.Now, 7);

            return await Save(prestamo);
        }

        private async Task<Prestamo> PrestarEmpleado(Prestamo prestamo)
        {
            prestamo.FechaMaximaDevolucion = LaboralDaysCounter.CalculateDevolutionDate(DateTime.Now, 8);
            return await Save(prestamo);
        }



        private async Task<Prestamo> Save(Prestamo entity)
        {
            return await _prestamoRepository.Save(entity);
        }

        Task<Prestamo> IEntityBusiness<Prestamo>.Save(Prestamo entity)
            => _prestamoRepository.Save(entity);

        Task<List<Prestamo>> IEntityBusiness<Prestamo>.GetAll(Prestamo entityFilter)
            => _prestamoRepository.GetAll(entityFilter);

        Task<bool> IEntityBusiness<Prestamo>.Update(Prestamo entity)
            => _prestamoRepository.Update(entity);

        Task<bool> IEntityBusiness<Prestamo>.Delete(Prestamo entity)
           => _prestamoRepository.Delete(entity);

    }
}
