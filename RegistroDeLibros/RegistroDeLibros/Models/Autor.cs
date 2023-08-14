using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroDeLibros.Models
{
    public class Autor
    {
        [Key]
        public string nombre{ get; set; }
        public DateTime fechaDeNacimeinto { get; set; }
        public string ciudadDeProcedencia { get; set; }


    }
}
