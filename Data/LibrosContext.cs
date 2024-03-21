using Microsoft.EntityFrameworkCore;
using SegundaPracticaMVC.Models;
using SegundaPracticaMVC.Models.PruebaExamen.Models;

namespace SegundaPracticaMVC.Data
{
    public class LibrosContext : DbContext
    {
        public LibrosContext(DbContextOptions<LibrosContext> options)
            : base(options)
        {
        }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ViewPedidos> ViewPedidos { get; set; }
    }
}
