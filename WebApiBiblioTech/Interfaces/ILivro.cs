using webapibibliotech.Domains;

namespace webapibibliotech.Interfaces
{
    public interface ILivro
    {
        void Cadastrar(Livros livro);
        void Deletar(Guid id);
        List<Livros> Listar();        
        Livros BuscarPorId(Guid id);
        void Atualizar(Guid id, Livros livro);
    }
}