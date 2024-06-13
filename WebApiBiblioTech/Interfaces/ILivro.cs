using webapibibliotech.Domains;

namespace webapibibliotech.Interfaces
{
    public interface ILivro
    {
        void Atualizar(Guid id, Livros livro);
        void AtualizarLivro(Guid id, string situacaoLivro);
        Livros BuscarPorId(Guid id);
        void Cadastrar(Livros livro);
        void Deletar(Guid id);
        List<Livros> Listar();      
        List<Livros> ListarPorGenero(Guid idGenero);
    }
}