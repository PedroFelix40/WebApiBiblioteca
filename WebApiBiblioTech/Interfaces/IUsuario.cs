using WebApiBiblioTech.Domains;

namespace WebApiBiblioTech.Interfaces
{
    public interface IUsuario
    {
        Usuarios BuscarPorId(Guid id);
        void Cadastrar(Usuarios usuario);
        void Deletar(Guid id);
        List<Usuarios> ListarUsuarios();
    }
}
