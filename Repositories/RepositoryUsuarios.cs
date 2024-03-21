using SegundaPracticaMVC.Data;
using SegundaPracticaMVC.Models;
using SegundaPracticaMVC.Models.PruebaExamen.Models;

namespace SegundaPracticaMVC.Repositories
{
    public class RepositoryUsuarios
    {
        private LibrosContext context;

        public RepositoryUsuarios(LibrosContext context)
        {
            this.context = context;
        }
        public async Task<Usuario> GetUserByEmailPasswordAsync(string email, string password)
        {
            return this.context.Usuarios.Where(x => x.Email == email && x.Password == password).AsEnumerable().FirstOrDefault();
        }
    }
}
