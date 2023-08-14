using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroDeLibros.Models
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string titulo { get; set; }
        public int año { get; set; }
        public string genero { get; set; }
        public int numeroDePaginas { get; set; }
        [ForeignKey("NombreAutor")]
        public string nombreAutor { get; set; }
        

    }
}
