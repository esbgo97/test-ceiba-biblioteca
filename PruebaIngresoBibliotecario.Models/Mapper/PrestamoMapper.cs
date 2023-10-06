using PruebaIngresoBibliotecario.Models.DTO;
using PruebaIngresoBibliotecario.Models.Entity;

namespace PruebaIngresoBibliotecario.Models.Mapper
{
    public static class PrestamoMapper
    {
        public  static Prestamo ToEntity(this PrestamoRequest request)
        {
            return new Prestamo { 
                IdentificacionUsuario = request.identificacionUsuario,
                GuidLibro = Guid.Parse(request.isbn),
                TipoUsuario = request.tipoUsuario,
            };
        }

        public static PrestamoResponse ToDTO(this Prestamo entity)
        {
            return new PrestamoResponse
            {
                Id = entity.GuidPrestamo.ToString(),
                Isbn = entity.GuidLibro.ToString(),
                IdentificacionUsuario = entity.IdentificacionUsuario,
                FechaMaximaDevolucion = entity.FechaMaximaDevolucion,
            };
        }
    }
}
