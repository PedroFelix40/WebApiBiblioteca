using webapibibliotech.Domains;

namespace webapibibliotech.Interfaces
{
    public interface IResenha
    {
        void CadastrarResenha(Resenhas resenha);
        void DeletarResenha(Guid id);
        List<Resenhas> ListarComId(Guid id);
        List<Resenhas> ListarCaralho();
    }
}
