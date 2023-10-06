namespace PruebaIngresoBibliotecario.Models.DTO
{
    public class PrestamoRequest
    {
        public string isbn { get; set; }
        public string identificacionUsuario { get; set; }
        public int tipoUsuario { get; set; }
    }
}
