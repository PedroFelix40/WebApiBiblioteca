using webapibibliotech.Contexts;
using webapibibliotech.Domains;
using webapibibliotech.Interfaces;

namespace webapibibliotech.Repositories
{
    public class GeneroRepository : IGenero
    {
        private readonly BiblioTechContext _context;

        public GeneroRepository()
        {
            _context = new BiblioTechContext();
        }

        public Generos BuscarPorId(Guid id)
        {
            try
            {
                Generos generoBuscado = _context.Generos.FirstOrDefault(g => g.IDGenero == id)!;

                return generoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CadastrarGenero(Generos genero)
        {
            try
            {
                _context.Add(genero);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeletarGenero(Guid id)
        {
            try
            {
                Generos generoBuscado = _context.Generos.FirstOrDefault(g => g.IDGenero == id)!;

                if (generoBuscado != null)
                {
                    _context.Generos.Remove(generoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Generos> ListarGeneros()
        {
            try
            {
                return _context.Generos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
