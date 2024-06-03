using WebApiBiblioTech.Domains;

namespace WebApiBiblioTech.Interfaces
{
    public interface IGenero
    {
        Generos BuscarPorId(Guid id);
        void CadastrarGenero(Generos genero);
        void DeletarGenero(Guid id);
        List<Generos> ListarGeneros();
    }
}
