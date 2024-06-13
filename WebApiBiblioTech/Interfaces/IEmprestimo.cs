using webapibibliotech.Domains;

namespace webapibibliotech.Interfaces
{
    public interface IEmprestimo
    {
        void Atualizar(Guid id, EmprestimosLivro emprestimoLivro);
        void AtualizarEmprestimo(Guid id, string status);
        EmprestimosLivro BuscarPorId(Guid id);
        void Deletar(Guid id);                  
        void Inscrever(EmprestimosLivro inscricao);
        List<EmprestimosLivro> ListarMeus(Guid id);
        List<EmprestimosLivro> Listar();
    }
}
