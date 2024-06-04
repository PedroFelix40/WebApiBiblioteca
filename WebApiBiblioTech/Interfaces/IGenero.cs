using webapibibliotech.Domains;

namespace webapibibliotech.Interfaces
{
    public interface IGenero
    {
        Generos BuscarPorId(Guid id);
        void CadastrarGenero(Generos genero);
        void DeletarGenero(Guid id);
        List<Generos> ListarGeneros();
    }
}