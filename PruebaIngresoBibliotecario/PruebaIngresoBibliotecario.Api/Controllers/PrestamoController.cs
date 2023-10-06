using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Business.Interfaces;
using PruebaIngresoBibliotecario.Models.DTO;
using PruebaIngresoBibliotecario.Models.Entity;
using PruebaIngresoBibliotecario.Models.Mapper;
using System;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoBusiness _prestamoBusiness;
        public PrestamoController(IPrestamoBusiness prestamoBusiness)
        {
            _prestamoBusiness = prestamoBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> Prestamo([FromBody] PrestamoRequest request)
        {

            try
            {
                Guid guidLibro;
                if (!Guid.TryParse(request.isbn, out guidLibro))
                {
                    throw new ApplicationException("El Guid del libro no es válido.");
                }

                var result = await _prestamoBusiness.SavePrestamoAsync(new Prestamo
                {
                    GuidLibro = Guid.Parse(request.isbn),
                    IdentificacionUsuario = request.identificacionUsuario,
                    TipoUsuario = request.tipoUsuario,
                });

                return Ok(result.ToDTO());
            }
            catch (ApplicationException ae)
            {
                return BadRequest(new { mensaje = ae.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{idPrestamo}")]
        public async Task<IActionResult> Prestamo(string idPrestamo)
        {

            try
            {
                var result = await _prestamoBusiness.GetPrestamoByGuid(idPrestamo);
                if (result == null)
                {
                    return NotFound($"No se encontro un prestamo asociado al guid: {idPrestamo}");
                }

                return Ok(result.ToDTO());
            }
            catch (ApplicationException ae)
            {
                return BadRequest(ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                var result = await _prestamoBusiness.GetAll(new Prestamo());
                return Ok(result);
            }
            catch (ApplicationException ae)
            {
                return BadRequest(ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
