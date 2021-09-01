using System;
using System.ComponentModel.DataAnnotations;

namespace Disney.Core.DTOs
{
    public class PelisDTO
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        [Required]
        [MaxLength(150), MinLength(1)]
        public string Titulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        [Range(1, 5, ErrorMessage = "Ingresar valores entre 1 y 5")]
        public int Calificacion { get; set; }
    }
}
