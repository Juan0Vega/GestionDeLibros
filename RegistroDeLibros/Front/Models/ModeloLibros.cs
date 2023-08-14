using RegistroDeLibros.Models;

namespace Front.Models
{
    public class ModeloLibros
    {
        public IEnumerable<Libro> ListaLibros { get; set; }
        public Libro NuevoLibro { get; set; }
    }
}
