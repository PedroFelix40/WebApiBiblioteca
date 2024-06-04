using webapibibliotech.Domains;

namespace webapibibliotech.Interfaces
{
    public interface IUsuario
    {
        Usuarios BuscarPorEmailESenha(string email, string senha);
        Usuarios BuscarPorId(Guid id);
        void Cadastrar(Usuarios usuario);
        List<Usuarios> ListarUsuarios();
    }
}
