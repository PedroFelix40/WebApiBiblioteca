using Microsoft.EntityFrameworkCore;
using WebApiBiblioTech.Contexts;
using WebApiBiblioTech.Domains;
using WebApiBiblioTech.Interfaces;

namespace WebApiBiblioTech.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly BiblioTechContext _context;
        
        public UsuarioRepository()
        {
            _context = new BiblioTechContext();
        }

        public Usuarios BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                return _context.Usuarios.
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuarios BuscarPorId(Guid id)
        {
            try
            {
                return _context.Usuarios.Include(t => t.TipoUsuario).FirstOrDefault(u => u.IdUsuario == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuarios> ListarUsuarios()
        {
            try
            {
                return _context.Usuarios.Include(t => t.TipoUsuario).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
