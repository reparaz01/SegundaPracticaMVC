using Microsoft.AspNetCore.Mvc;
using SegundaPracticaMVC.Repositories;
using SegundaPracticaMVC.Filters;
using PruebaExamen.Repositories;
using SegundaPracticaMVC.Models;
using SegundaPracticaMVC.Extensions;

namespace SegundaPracticaMVC.Controllers
{
    public class LibrosController : Controller
    {
        private RepositoryLibros repo;
        public LibrosController(RepositoryLibros repo)
        {
            this.repo = repo;
        }

        [AuthorizeUsuarios]
        public IActionResult PerfilUsuario()
        {
            return View();
        }
        [AuthorizeUsuarios]
        public async Task<IActionResult> Index()
        {
            List<Libro> libros = await this.repo.GetLibrosAsync();
            return View(libros);
        }


        [AuthorizeUsuarios]
        public async Task<IActionResult> LibrosGenero(int idgenero)
        {
            List<Libro> peliculasGenero = await this.repo.LibrosGeneroAsync(idgenero);
            return View(peliculasGenero);
        }

        [AuthorizeUsuarios]
        public async Task<IActionResult> DetallesLibro(int id)
        {
            Libro libro = await this.repo.FindLibroAsync(id);
            return View(libro);
        }
        public IActionResult GuardarLibroCarrito(int idLibro)
        {
            int cantidadCarrito = HttpContext.Session.GetObject<int>("CANTIDADCARRITO");
            if (idLibro != null)
            {
                List<int> carrito;
                if (HttpContext.Session.GetObject<List<int>>("CARRITO") == null)
                {
                    carrito = new List<int>();
                }
                else
                {
                    carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
                }
                carrito.Add(idLibro);
                HttpContext.Session.SetObject("CARRITO", carrito);
                HttpContext.Session.SetObject("CANTIDADCARRITO", carrito.Count);
            }

                return RedirectToAction("DetallesLibro", new { id = idLibro });

        }

        public IActionResult Carrito(int? idLibroEliminar)
        {
            //LE PASAMOS EL CARRITO
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
            int cantidadCarrito = carrito.Count;
            //TIENES QUE CREAR PARA AÑADIR DATOS AL CARRITO
            if (carrito == null)
            {
                return View();
            }
            else
            {
                if (idLibroEliminar != null)
                {
                    carrito.Remove(idLibroEliminar.Value);
                    cantidadCarrito--;
                    HttpContext.Session.SetObject("CARRITO", carrito);
                    HttpContext.Session.SetObject("CANTIDADCARRITO", cantidadCarrito);
                }
                List<Libro> libros = this.repo.GetLibrosCarrito(carrito);
                return View(libros);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Comprar(List<int> libros, int iduser)
        {
            int idpedido = await repo.GetUltimoPedido();
            int idfactura = await repo.GetUltimaFactura()+1;
            for (int i = 0; i < libros.Count; i++)
            {
                int libro = libros[i];

                idpedido++;
                Pedido nuevoPedido = new Pedido()
                {
                    IdPedido = idpedido,
                    IdFactura = idfactura,
                    IdLibro = libro,
                    FechaCompra = DateTime.Now,
                    IdUsuario = iduser,
                    Cantidad = 1
                };

                await repo.Comprar(nuevoPedido);

            }
            HttpContext.Session.Remove("CARRITO");
            HttpContext.Session.Remove("CANTIDADCARRITO");

            return RedirectToAction("Index");
        }


        [AuthorizeUsuarios]
        public async Task<IActionResult> PedidosUsuario(int id)
        {
            List<ViewPedidos> pedidos = await this.repo.GetPedidosUsuario(id);
            return View(pedidos);
        }



    }
}
