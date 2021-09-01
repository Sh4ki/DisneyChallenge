using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Disney.Core.Entities
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50),MinLength(5)]
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public List<Pelicula> Peliculas { get; set; }

    }
}
