using Microsoft.AspNetCore.Mvc;
using RegistroDeLibros.Models;
using System.Text;
using System.Text.Json;
using Front.Models;

namespace Front.Controllers
{
    public class LibrosController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LibrosController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            using (var client = _httpClientFactory.CreateClient("Api"))
            {
                var response = await client.GetAsync("api/Libro/obtener-libros");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var libros = new ModeloLibros
                        {
                            ListaLibros = JsonSerializer.Deserialize<List<Libro>>(content),
                            NuevoLibro = new Libro()
                        };

                        
                        return View(libros);
                    }
                    catch (Exception ex)
                    {
                        return View("Error");
                    }
                }
                else
                {
                  
                    return View("Error");
                }
            }


        }
        [HttpPost]
        public async Task<IActionResult> RegistrarLibro(ModeloLibros libros)
        {
            using (var client = _httpClientFactory.CreateClient("Api"))
            {
                var jsonContent = new StringContent(
                    JsonSerializer.Serialize(libros.NuevoLibro),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync("api/Libro", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    // El libro se registró exitosamente en la API
                    return RedirectToAction("Index");
                }
                else
                {
                    // Manejo de error si el registro falla
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError("", errorMessage);
                    await Index();
                    return View("Index");
                }
            }
        }
    }
}
