using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Disney.Core.Entities
{
    public class Personaje
    {
        [Key]
        public int Id { get; set; }
        public string Imagen { get; set; }
        [Required]
        [MaxLength(250), MinLength(1)]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        [MaxLength(50), MinLength(1)]
        public string Peso { get; set; }
        public string Historia { get; set; }
        public List<Pelicula> Peliculas { get; set; }
    }
}
