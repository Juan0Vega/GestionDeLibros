using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroDeLibros.Models;

namespace RegistroDeLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly BooksContext _booksContext;
        public AutorController(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        [HttpPost]
        public async Task<Autor> CrearAutor(Autor autor)
        {
            
            _booksContext.Autors.Add(autor);
            await _booksContext.SaveChangesAsync();


            return autor;
        }
        [HttpGet("obtener-autor")]
        public IActionResult ObtenerAutor()
        {
            var autors = _booksContext.Autors.ToList();
            return Ok(autors);
        }

    }
}
