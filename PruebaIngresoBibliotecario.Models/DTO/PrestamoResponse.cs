namespace PruebaIngresoBibliotecario.Models.DTO
{
    public class PrestamoResponse
    {
        public string Id { get; set; }
        public string Isbn { get; set; }
        public string IdentificacionUsuario { get; set; }        
        public DateTime FechaMaximaDevolucion { get; set; }
    }
}
