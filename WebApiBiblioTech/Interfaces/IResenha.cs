using webapibibliotech.Domains;

namespace webapibibliotech.Interfaces
{
    public interface IResenha
    {
        void CadastrarResenha(Resenhas resenha);
        void DeletarResenha(Guid id);
        List<Resenhas> Listar(Guid id);
        List<Resenhas> ListarCaralho();
        Resenhas BuscarPorId(Guid id);
    }
}
