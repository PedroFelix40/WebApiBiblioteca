using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBiblioTech.Domains;
using WebApiBiblioTech.Interfaces;
using WebApiBiblioTech.Repositories;

namespace WebApiBiblioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private IGenero _genero;

        // Injeção de dependencia
        public GeneroController(IGenero genero)
        {
            _genero = genero ?? throw new ArgumentNullException(nameof(genero)); // Validação para conferir se a instância de IGenero é != de null
        }

        // Métodos

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

        [HttpDelete("/{id}")]
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
                else {
                    return NotFound("Não foi encontrado nenhum genero com esse ID");
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
