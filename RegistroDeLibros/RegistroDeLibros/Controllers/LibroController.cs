using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Api.Controllers.ResponseModel;
using RegistroDeLibros.Models;
using RegistroDeLibros.Negocio;

namespace RegistroDeLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly BooksContext _booksContext;
        private readonly ReglasDeNegocio _reglasDeNegocio;

        public LibroController(BooksContext booksContext, ReglasDeNegocio reglasDeNegocio)
        {
            _booksContext = booksContext;
            _reglasDeNegocio = reglasDeNegocio; 
        }

        [HttpPost]
        public async Task<ActionResult<Libro>> RegistrarLibro(Libro libro)
        {

            try
            {
                await _reglasDeNegocio.ValidacionAutor(libro);

                await _booksContext.Libros.AddAsync(libro);

                await _booksContext.SaveChangesAsync();
            }catch (Exception ex)
            {
                var mensajeError = new MensajeError
                {
                    mensaje = ex.Message
                };
                return BadRequest(mensajeError);
            }

            return libro;
        }

        [HttpDelete]
        public async Task<ActionResult> EliminarLibro(int id)
        {
            var libro = await _booksContext.Libros.FindAsync(id);
            _booksContext.Libros.Remove(libro);
            _booksContext.SaveChanges();

            return NoContent();
        }

        [HttpGet("obtener-libros")]
        public IActionResult ObtenerLibros()
        {
            var libros = _booksContext.Libros.ToList();
            return Ok(libros);
        }
    }
}
