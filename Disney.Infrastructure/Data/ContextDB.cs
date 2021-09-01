using Disney.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Disney.Infrastructure.Data
{
    public partial class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options)
            : base(options)
        {
        }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
