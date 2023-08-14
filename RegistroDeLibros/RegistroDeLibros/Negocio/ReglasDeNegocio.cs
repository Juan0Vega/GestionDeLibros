using Microsoft.EntityFrameworkCore;
using RegistroDeLibros.Models;

namespace RegistroDeLibros.Negocio
{
    public class ReglasDeNegocio
    {
        private readonly BooksContext _context;

        public ReglasDeNegocio(BooksContext booksContext)
        {
            _context = booksContext;
        }
        public async Task<bool> ValidacionAutor(Libro libro){

            var autorDB = await _context.Autors.Where(x=>x.nombre == libro.nombreAutor).ToListAsync();

            if (autorDB.Count()==0) {
                throw new Exception($"El autor no se encuentra registrado");
            }

            return true;
        }


    }
}
