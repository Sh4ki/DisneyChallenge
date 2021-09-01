using System.ComponentModel.DataAnnotations;

namespace Disney.Core.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
    }
}
