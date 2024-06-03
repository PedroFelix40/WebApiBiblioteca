using WebApiBiblioTech.Contexts;
using WebApiBiblioTech.Domains;
using WebApiBiblioTech.Interfaces;

namespace WebApiBiblioTech.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuario
    {
        private readonly BiblioTechContext _context;

        public TipoUsuarioRepository()
        {
            _context = new BiblioTechContext();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            try
            {
                TiposUsuario buscado = _context.TiposUsuario.FirstOrDefault(t => t.IDTipoUsuario == id)!;
                return buscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CadastrarTipoUsuario(TiposUsuario tiposUsuario)
        {
            try
            {
                _context.TiposUsuario.Add(tiposUsuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeletarTipoUsuario(Guid id)
        {
            try
            {
                TiposUsuario buscado = BuscarPorId(id);
                _context.TiposUsuario.Remove(buscado);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TiposUsuario> ListarTiposUsuarios()
        {
            return _context.TiposUsuario.ToList();
        }
    }
}
