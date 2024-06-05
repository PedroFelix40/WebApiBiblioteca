using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapibibliotech.Domains;
using webapibibliotech.Interfaces;

namespace webapibibliotech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LivroController : ControllerBase
    {
        private ILivro _livro;

        // Injeção
        public LivroController(ILivro livro)
        {
            _livro = livro ?? throw new ArgumentNullException(nameof(livro)); // validação para conferir se a instância de IGenero é != de null
        }

        // Métodos

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
        public IActionResult Post(Livros livro)
        {

            try
            {
                _livro.Cadastrar(livro);

                return Ok(livro);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeletarPorId/{id}")]
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

        [HttpPut("{id}")]
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


