using webapibibliotech.Domains;

namespace webapibibliotech.Interfaces
{
    public interface ILivro
    {
        void Cadastrar(Livros livro);
        void Deletar(Guid id);
        List<Livros> Listar();
        List<Livros> ListarMeus(Guid id);
        Livros BuscarPorId(Guid id);
        void Atualizar(Guid id, Livros livro);
    }
}