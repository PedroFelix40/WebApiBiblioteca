using webapibibliotech.Contexts;
using webapibibliotech.Domains;
using webapibibliotech.Interfaces;

namespace webapibibliotech.Repositories
{
    public class ResenhaRepository : IResenha
    {

        private readonly BiblioTechContext _context;

        public ResenhaRepository()
        {
            _context = new BiblioTechContext();
        }

        public void CadastrarResenha(Resenhas resenha)
        {
            try
            {
                _context.Resenhas.Add(resenha);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeletarResenha(Guid id)
        {
            try
            {
                Resenhas resenhaBuscada = _context.Resenhas.FirstOrDefault(g => g.IDResenha == id)!;

                if (resenhaBuscada != null)
                {
                    _context.Resenhas.Remove(resenhaBuscada);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

    
        public List<Resenhas> ListarCaralho()
        {
            try
            {
                return _context.Resenhas
                 .Select(l => new Resenhas
                 {
                     Descricao = l.Descricao,
                     Exibe = l.Exibe,

                     Usuario = new Usuarios
                     {
                         Nome = l.Usuario!.Nome
                     },

                     Livro = new Livros
                     {
                         Titulo = l.Livro!.Titulo,
                     }

                 }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Resenhas> ListarComId(Guid id)
        {
            try
            {
                return _context.Resenhas
                 .Select(l => new Resenhas
                 {
                     Descricao = l.Descricao,
                     Exibe = l.Exibe,

                     Usuario = new Usuarios
                     {
                         Nome = l.Usuario!.Nome
                     },

                     
                     Livro = new Livros
                     {
                         //important !
                         IDLivro = l.Livro!.IDLivro,
                         Titulo = l.Livro!.Titulo,
                     }

                 }).Where(l => l.Livro!.IDLivro == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }   
        }
    }
}

