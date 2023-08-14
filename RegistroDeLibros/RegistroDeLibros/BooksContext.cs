using Microsoft.EntityFrameworkCore;
using RegistroDeLibros.Models;

namespace RegistroDeLibros
{
    public class BooksContext : DbContext 
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {
            
        }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>().ToTable("Libro");
            modelBuilder.Entity<Autor>().ToTable("Autor");
        }
    }
}
