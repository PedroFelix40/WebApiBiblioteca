using webapibibliotech.Contexts;
using webapibibliotech.Domains;
using webapibibliotech.Interfaces;

namespace webapibibliotech.Repositories
{
    public class EmprestimoRepository : IEmprestimo
    {
        private readonly BiblioTechContext _context;

        public EmprestimoRepository()
        {
            _context = new BiblioTechContext();
        }

        public void Atualizar(Guid id, EmprestimosLivro emprestimoLivro)
        {
            throw new NotImplementedException();
        }

        public EmprestimosLivro BuscarPorId(Guid id)
        {
            try
            {
                return _context.EmprestimosLivro.Select(e => new EmprestimosLivro
                {
                    IDEmprestimoLivro = e.IDEmprestimoLivro,
                    Situacao = e.Situacao,
                    DataDevolucao = e.DataDevolucao,
                    IDUsuario = e.IDUsuario,

                    

                    Usuario = new Usuarios
                    {
                        IdUsuario = e.IDUsuario,
                        Nome = e.Usuario!.Nome,
                        Email = e.Usuario.Email,
                        IDTipoUsuario = e.Usuario!.IDTipoUsuario,
                        
                        TipoUsuario = new TiposUsuario
                        {
                            TituloTipoUsuario = e.Usuario.TipoUsuario!.TituloTipoUsuario,
                        }
                    },

                    IDLivro = e.IDLivro,

                    Livro = new Livros
                    {
                        IDLivro = e.IDLivro,
                        Titulo = e.Livro!.Titulo,
                        Autor = e.Livro.Autor,
                        Ano = e.Livro.Ano,
                        Editora = e.Livro.Editora,
                        ISBN = e.Livro.ISBN,
                        Capa = e.Livro.Capa,

                        IDGenero = e.Livro.IDGenero,

                        Genero = new Generos
                        {
                            TituloGenero = e.Livro.Genero!.TituloGenero
                        }
                    }
                }).FirstOrDefault(e => e.IDEmprestimoLivro == id)!;
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
                EmprestimosLivro emprestimoBuscado = _context.EmprestimosLivro.FirstOrDefault(e => e.IDEmprestimoLivro == id)!;

                if (emprestimoBuscado != null)
                {
                    _context.EmprestimosLivro.Remove(emprestimoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Inscrever(EmprestimosLivro inscricao)
        {
            try
            {
                _context.EmprestimosLivro.Add(inscricao);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EmprestimosLivro> Listar()
        {
            try
            {
                return _context.EmprestimosLivro.Select(e => new EmprestimosLivro
                {
                    IDEmprestimoLivro = e.IDEmprestimoLivro,
                    Situacao = e.Situacao,
                    DataDevolucao = e.DataDevolucao,
                    IDUsuario = e.IDUsuario,
                    Usuario = new Usuarios
                    {
                        IdUsuario = e.IDUsuario,
                        Nome = e.Usuario!.Nome,
                        Email = e.Usuario.Email,
                        IDTipoUsuario = e.Usuario!.IDTipoUsuario,

                        TipoUsuario = new TiposUsuario
                        {
                            TituloTipoUsuario = e.Usuario.TipoUsuario!.TituloTipoUsuario,
                        }
                    },

                    IDLivro = e.IDLivro,

                    Livro = new Livros
                    {
                        IDLivro = e.IDLivro,
                        Titulo = e.Livro!.Titulo,
                        Autor = e.Livro.Autor,
                        Ano = e.Livro.Ano,
                        Editora = e.Livro.Editora,
                        ISBN = e.Livro.ISBN,
                        Capa = e.Livro.Capa,

                        IDGenero = e.Livro.IDGenero,

                        Genero = new Generos
                        {
                            TituloGenero = e.Livro.Genero!.TituloGenero
                        }
                    }
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EmprestimosLivro> ListarMeus(Guid id)
        {
            try
            {
                return _context.EmprestimosLivro.Select(e => new EmprestimosLivro
                {
                    IDEmprestimoLivro = e.IDEmprestimoLivro,
                    Situacao = e.Situacao,
                    DataDevolucao = e.DataDevolucao,
                    IDUsuario = e.IDUsuario,
                    Usuario = new Usuarios
                    {
                        IdUsuario = e.IDUsuario,
                        Nome = e.Usuario!.Nome,
                        Email = e.Usuario.Email,
                        IDTipoUsuario = e.Usuario!.IDTipoUsuario,

                        TipoUsuario = new TiposUsuario
                        {
                            TituloTipoUsuario = e.Usuario.TipoUsuario!.TituloTipoUsuario,
                        }
                    },

                    Livro = new Livros
                    {
                        IDLivro = e.IDLivro,
                        Titulo = e.Livro!.Titulo,
                        Autor = e.Livro.Autor,
                        Ano = e.Livro.Ano,
                        Editora = e.Livro.Editora,
                        ISBN = e.Livro.ISBN,
                        Capa = e.Livro.Capa,

                        IDGenero = e.Livro.IDGenero,

                        Genero = new Generos
                        {
                            TituloGenero = e.Livro.Genero!.TituloGenero
                        }
                    }
                }).Where(e => e.IDUsuario == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
