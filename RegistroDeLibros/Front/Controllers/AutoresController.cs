using Microsoft.AspNetCore.Mvc;
using RegistroDeLibros.Models;
using System.Text;
using System.Text.Json;
using Front.Models;
namespace Front.Controllers
{
    public class AutoresController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AutoresController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            using (var client = _httpClientFactory.CreateClient("Api"))
            {
                var response = await client.GetAsync("api/Autor/obtener-autor");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var autores = new ModeloAutor
                        {
                            ListaAutor = JsonSerializer.Deserialize<List<Autor>>(content),
                            NuevoAutor = new Autor()
                        };


                        return View(autores);
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
        public async Task<IActionResult> RegistrarAutor(ModeloAutor autores)
        {
            using (var client = _httpClientFactory.CreateClient("Api"))
            {
                var jsonContent = new StringContent(
                    JsonSerializer.Serialize(autores.NuevoAutor),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync("api/Autor", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    
                    return RedirectToAction("Index");
                }
                else
                {
                   
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError("", errorMessage);
                    return View("Index");
                }
            }
        }
    }
}
