using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Api.Controllers.ResponseModel;
using RegistroDeLibros.Models;

namespace FrontRegistroDeLibros.Controllers
{
    public class LibrosController : Controller
    {
        private readonly HttpClient _httpClient;

        public LibrosController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:7049");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegistrarLibro(Libro libro)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Libro", libro);

                if (response.IsSuccessStatusCode)
                {
                    var libroRegistrado = await response.Content.ReadFromJsonAsync<Libro>();
                    return RedirectToAction("Index"); // Redirige a la página de lista de libros
                }
                else
                {
                    var mensajeError = await response.Content.ReadFromJsonAsync<MensajeError>();
                    ModelState.AddModelError(string.Empty, mensajeError.mensaje);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(libro);
        }
    }
}

