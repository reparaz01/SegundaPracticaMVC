using Microsoft.EntityFrameworkCore;
using SegundaPracticaMVC.Data;
using SegundaPracticaMVC.Models;

namespace PruebaExamen.Repositories
{
    public class RepositoryLibros
    {
        private LibrosContext context;

        public RepositoryLibros(LibrosContext context)
        {
            this.context = context;
        }

        public async Task<List<Libro>> GetLibrosAsync()
        {
            return await this.context.Libros.ToListAsync();
        }

        public async Task<Libro> FindLibroAsync(int idLibro)
        {
            return await this.context.Libros.FirstOrDefaultAsync(x => x.IdLibro == idLibro);
        }

        public async Task<List<Libro>> LibrosGeneroAsync(int idgenero)
        {
            return await this.context.Libros.Where(p => p.IdGenero == idgenero).ToListAsync();
        }

        public async Task<List<Genero>> GetAllGenerosAsync()
        {
            return await this.context.Generos.ToListAsync();
        }

        public List<Libro> GetLibrosCarrito(List<int> idLibro)
        {
            return context.Libros.Where(p => idLibro.Contains(p.IdLibro)).ToList();
        }
        public async Task<int> GetUltimoPedido()
        {
            var ultimoIdImagen = await this.context.Pedidos
                                            .MaxAsync(imagen => (int?)imagen.IdPedido);

            return ultimoIdImagen ?? 1;
        }

        public async Task<int> GetUltimaFactura()
        {
            var ultimoIdFactura = await this.context.Pedidos
                                            .MaxAsync(pedido => (int?)pedido.IdFactura);

            return ultimoIdFactura ?? 1;
        }

        public async Task Comprar(Pedido compra)
        {
            context.Pedidos.Add(compra);
            await context.SaveChangesAsync();
        }

        public async Task<List<ViewPedidos>> GetPedidosUsuarioView(int idUsuario)
        {
            return await context.ViewPedidos
                .Where(pedido => pedido.IdUsuario == idUsuario)
                .ToListAsync();
        }

        public async Task<List<ViewPedidos>> GetPedidosUsuario(int id)
        {
            return await context.ViewPedidos.Where(c => c.IdUsuario == id).ToListAsync();
        }

    }
}
