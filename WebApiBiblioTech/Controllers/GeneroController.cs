using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapibibliotech.Interfaces;
using webapibibliotech.Domains;

namespace webapibibliotech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        private IGenero _genero;

        // Injeção
        public GeneroController(IGenero genero)
        {
            _genero = genero ?? throw new ArgumentNullException(nameof(genero)); // validação para conferir se a instância de IGenero é != de null
        }

        // Métodos"

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_genero.BuscarPorId(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("CadastrarGeneros")]
        public IActionResult Post(Generos genero)
        {

            try
            {
                _genero.CadastrarGenero(genero);

                return Ok(genero);
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
                Generos generoBuscado = _genero.BuscarPorId(id);

                if (generoBuscado != null)
                {
                    _genero.DeletarGenero(id);

                    return Ok("O genero foi deletado");
                }
                else
                {
                    return NotFound("Não foi encontrado nenhum gênero com esse ID");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ListarGeneros")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_genero.ListarGeneros());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
