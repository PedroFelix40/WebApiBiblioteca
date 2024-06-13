using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapibibliotech.Domains;
using webapibibliotech.Interfaces;
using webapibibliotech.Utils.BlobStorage;
using webapibibliotech.ViewModel;

namespace webapibibliotech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LivroController : ControllerBase
    {
        private ILivro _livro;

        public LivroController(ILivro livro)
        {
            _livro = livro ?? throw new ArgumentNullException(nameof(livro)); 
        }


        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetActionResult(Guid id)
        {
            try
            {
                return Ok(_livro.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("CadastrarLivros")]
        public async Task<IActionResult> Post([FromForm] LivroViewModel livroModel)
        {
            try
            {
                Livros book = new Livros();


                book.Titulo = livroModel.Titulo;
                book.Autor = livroModel.Autor;
                book.Ano = livroModel.Ano;
                book.Editora = livroModel.Editora;
                book.ISBN = livroModel.ISBN;
                book.SituacaoLivro = livroModel.SituacaoLivro;

                book.IDGenero = livroModel.IDGenero;

                var containerName = "blobbibliotech";
                var connectionString = "DefaultEndpointsProtocol=https;AccountName=blobbibliotech;AccountKey=flFKNyFFk9mH3TXaCqNlaX0g85mclKktqUp0UJw74yQPd28idikZSvGGgF6TzHCwb5+dEHgoVSuR+ASt+PcmLA==;EndpointSuffix=core.windows.net";


                book.Capa = await AzureBlobStorageHelper.UploadImageBlobAsync(livroModel.Arquivo!, connectionString, containerName);

                _livro.Cadastrar(book);

                return Ok(book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeletarLivro/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Livros livroBuscado = _livro.BuscarPorId(id);

                if (livroBuscado != null)
                {
                    _livro.Deletar(id);

                    return Ok("O livro foi deletado!");
                }
                else
                {
                    return NotFound("Não foi encontrado nenhum livro com esse ID!");
                }
            }

            catch (Exception)
            {
                throw;
            }

        }


        [HttpGet("ListarLivros")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_livro.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("AtualizarStatus")]
        public IActionResult Put(Guid id, LivroStatusViewModel lViewModel)
        {
            try
            {

                var SituacaoLivro = lViewModel.SituacaoLivro;
                _livro.AtualizarLivro(id, SituacaoLivro);

                return Ok("Atualizado");
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("ListarLivrosPorGenero")]
        public IActionResult GetByGenero(Guid idGenero)
        {
            try
            {
                return Ok(_livro.ListarPorGenero(idGenero));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("Atualizar{id}")]
        public IActionResult Put(Guid id, Livros livro)
        {
            try
            {
                _livro.Atualizar(id, livro);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }

}


