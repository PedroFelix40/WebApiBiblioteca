using webapibibliotech.Domains;

namespace webapibibliotech.Interfaces
{
    public interface IUsuario
    {

        bool AlterarSenha(string email, string senhaNova);
        public void AtualizarFoto(Guid id, string novaUrlFoto);
        Usuarios BuscarPorEmailESenha(string email, string senha);
        Usuarios BuscarPorEmail(string email);
        Usuarios BuscarPorId(Guid id);
        void Cadastrar(Usuarios usuario);
        void Deletar(Guid id);
        List<Usuarios> ListarUsuarios();
    }
}
