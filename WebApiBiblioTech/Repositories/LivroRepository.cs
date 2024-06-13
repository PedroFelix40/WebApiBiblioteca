using webapibibliotech.Contexts;
using webapibibliotech.Domains;
using webapibibliotech.Interfaces;

namespace webapibibliotech.Repositories
{
    public class LivroRepository : ILivro
    {
        private readonly BiblioTechContext _context;

        public LivroRepository()
        {
            _context = new BiblioTechContext();
        }

        public void Atualizar(Guid id, Livros livro)
        {
            try
            {
                Livros livroBuscado = _context.Livros.Find(id)!;

                if (livroBuscado != null)
                {
                    livroBuscado.Titulo = livro.Titulo;
                    livroBuscado.ISBN = livro.ISBN;
                    livroBuscado.Autor = livro.Autor;
                    livroBuscado.Ano = livro.Ano;
                    livroBuscado.Editora = livro.Editora;
                    livroBuscado.Capa = livro.Capa;
                }

                _context.Livros.Update(livroBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AtualizarLivro(Guid id, string situacaoLivro)
        {
            try
            {
                Livros situacaoL = _context.Livros.Find(id)!;

                if (situacaoL != null)
                {
                    situacaoL.SituacaoLivro = situacaoLivro;
                }

                _context.Livros.Update(situacaoL!);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Livros BuscarPorId(Guid id)
        {
            try
            {
                Livros livroBuscado = _context.Livros.Select(l => new Livros
                {
                    IDLivro = l.IDLivro,
                    Ano = l.Ano,
                    ISBN = l.ISBN,
                    Editora = l.Editora,
                    Autor = l.Autor,
                    Capa = l.Capa,
                    Titulo = l.Titulo,
                    SituacaoLivro = l.SituacaoLivro,

                    Genero = new Generos
                    {
                        TituloGenero = l.Genero!.TituloGenero
                    }
                }).FirstOrDefault(g => g.IDLivro == id)!;

                return livroBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Livros livro)
        {
            try
            {
                _context.Livros.Add(livro);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Livros livroBuscado = _context.Livros.FirstOrDefault(g => g.IDLivro == id)!;

                if (livroBuscado != null)
                {
                    _context.Livros.Remove(livroBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Livros> Listar()
        {
            try
            {
                return _context.Livros
                .Select(l => new Livros
                {
                    IDLivro = l.IDLivro,
                    Ano = l.Ano,
                    ISBN = l.ISBN,
                    SituacaoLivro = l.SituacaoLivro,
                    Editora = l.Editora,
                    Autor = l.Autor,
                    Capa = l.Capa,
                    Titulo = l.Titulo,

                    IDGenero = l.IDGenero,
                    Genero = new Generos
                    {
                        IDGenero = l.Genero!.IDGenero,
                        TituloGenero = l.Genero!.TituloGenero
                    }
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Livros> ListarPorGenero(Guid idGenero)
        {
            try
            {
                return _context.Livros
                .Select(l => new Livros
                {
                    IDLivro = l.IDLivro,
                    Ano = l.Ano,
                    ISBN = l.ISBN,
                    SituacaoLivro = l.SituacaoLivro,
                    Editora = l.Editora,
                    Autor = l.Autor,
                    Capa = l.Capa,
                    Titulo = l.Titulo,

                    IDGenero = l.IDGenero,
                    Genero = new Generos
                    {
                        IDGenero = l.Genero!.IDGenero,
                        TituloGenero = l.Genero!.TituloGenero
                    }
                }).Where(l => l.IDGenero == idGenero).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
