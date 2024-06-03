using WebApiBiblioTech.Domains;

namespace WebApiBiblioTech.Interfaces
{
    public interface ITipoUsuario
    {
        TiposUsuario BuscarPorId(Guid id);
        void CadastrarTipoUsuario(TiposUsuario tiposUsuario);
        void DeletarTipoUsuario(Guid id);
        List<TiposUsuario> ListarTiposUsuarios();
    }
}
