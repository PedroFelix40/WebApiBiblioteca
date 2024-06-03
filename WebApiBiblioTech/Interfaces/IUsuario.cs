using WebApiBiblioTech.Domains;

namespace WebApiBiblioTech.Interfaces
{
    public interface IUsuario
    {
        Usuarios BuscarPorEmailESenha(string email, string senha);
        Usuarios BuscarPorId(Guid id);
        void Cadastrar(Usuarios usuario);


        List<Usuarios> ListarUsuarios();

        /*
     

        Usuario BuscarPorEmailESenha(string email, string senha);

        bool AlterarSenha(string email, string senhaNova);

        public void AtualizarFoto(Guid id, string novaUrlFoto);
        */
    }
}
