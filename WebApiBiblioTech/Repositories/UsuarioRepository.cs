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

        public Usuarios BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
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

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Usuarios> ListarUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}
