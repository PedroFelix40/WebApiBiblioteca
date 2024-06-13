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
                     IDUsuario = l.IDUsuario,

                     Usuario = new Usuarios
                     {
                         IdUsuario = l.IDUsuario,
                         Nome = l.Usuario!.Nome,
                         Email = l.Usuario.Email,
                         IDTipoUsuario = l.Usuario!.IDTipoUsuario,

                         TipoUsuario = new TiposUsuario
                         {
                             TituloTipoUsuario = l.Usuario.TipoUsuario!.TituloTipoUsuario,
                         }
                     },

                     Livro = new Livros
                     {
                         Titulo = l.Livro!.Titulo,
                         Autor = l.Livro!.Autor,
                         Ano = l.Livro!.Ano,
                         Editora = l.Livro!.Editora,
                         ISBN = l.Livro!.ISBN,
                         Capa = l.Livro!.Capa,

                         Genero = new Generos
                         {
                             IDGenero = l.Livro.Genero!.IDGenero,
                             TituloGenero = l.Livro.Genero!.TituloGenero
                         }

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
                     IDUsuario = l.IDUsuario,

                     Usuario = new Usuarios
                     {
                         IdUsuario = l.IDUsuario,
                         Nome = l.Usuario!.Nome,
                         Email = l.Usuario.Email,
                         IDTipoUsuario = l.Usuario!.IDTipoUsuario,

                         TipoUsuario = new TiposUsuario
                         {
                             TituloTipoUsuario = l.Usuario.TipoUsuario!.TituloTipoUsuario,
                         }
                     },

                     IDLivro = l.IDLivro,
                     Livro = new Livros
                     {
                         Titulo = l.Livro!.Titulo,
                         Autor = l.Livro!.Autor,
                         Ano = l.Livro!.Ano,
                         Editora = l.Livro!.Editora,
                         ISBN = l.Livro!.ISBN,
                         Capa = l.Livro!.Capa,

                         Genero = new Generos
                         {
                             IDGenero = l.Livro.Genero!.IDGenero,
                             TituloGenero = l.Livro.Genero!.TituloGenero
                         }

                     }

                 }).Where(l => l.IDLivro == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }   
        }
    }
}

