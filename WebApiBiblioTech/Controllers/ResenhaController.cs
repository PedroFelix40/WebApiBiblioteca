using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapibibliotech.Domains;
using webapibibliotech.Interfaces;

namespace webapibibliotech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ResenhaController : ControllerBase
    {
        private IResenha _resenha;

        // Injeção
        public ResenhaController(IResenha resenha)
        {
            _resenha = resenha ?? throw new ArgumentNullException(nameof(resenha)); 
        }

        [HttpPost]
        public IActionResult Post(Resenhas resenhas)
        {
            try
            {
                _resenha.CadastrarResenha(resenhas);

                return Ok(resenhas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _resenha.DeletarResenha(id);

                return Ok("Resenha excluida com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarResenhasComId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_resenha.ListarComId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarCARALHO")]
        public IActionResult GetCaralho()
        {
            try
            {
                return Ok(_resenha.ListarCaralho());
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
