using Microsoft.AspNetCore.Mvc;
using PruebaExamen.Repositories;
using SegundaPracticaMVC.Filters;
using SegundaPracticaMVC.Models;
using SegundaPracticaMVC.Repositories;

namespace SegundaPracticaMVC.ViewComponents
{
    public class MenuGenerosViewComponent : ViewComponent
    {
        private RepositoryLibros repo;

        public MenuGenerosViewComponent(RepositoryLibros repo)
        {
            this.repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Genero> generos = await this.repo.GetAllGenerosAsync();
            return View(generos);
        }
    }
}