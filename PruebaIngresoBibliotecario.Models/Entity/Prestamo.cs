using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Models.Entity
{
    public class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }

        public Guid GuidPrestamo { get; set; }

        [Required]
        public Guid GuidLibro { get; set; }

        [Required, MaxLength(10)]
        public string IdentificacionUsuario { get; set; }

        [Required]
        public int TipoUsuario { get; set; }

        public DateTime FechaMaximaDevolucion { get; set; }

    }
}
