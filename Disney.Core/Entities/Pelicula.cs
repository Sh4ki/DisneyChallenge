using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Disney.Core.Entities
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }
        public string Imagen { get; set; }
        [Required]
        [MaxLength(150), MinLength(1)]
        public string Titulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Calificacion { get; set; }
        public List<Personaje> Personajes { get; set; }
        public List<Genero> Generos { get; set; }
    }
}
