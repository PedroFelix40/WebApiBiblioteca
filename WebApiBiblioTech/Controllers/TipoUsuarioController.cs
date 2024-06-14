using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapibibliotech.Domains;
using webapibibliotech.Interfaces;

namespace webapibibliotech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuario _tipoUsuario;

        public TipoUsuarioController(ITipoUsuario tipoUsuario)
        {
            _tipoUsuario = tipoUsuario ?? throw new ArgumentNullException(nameof(tipoUsuario)); 
        }



        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TiposUsuario tipoUsuarioBuscado = _tipoUsuario.BuscarPorId(id);

                if (tipoUsuarioBuscado != null)
                {
                    return Ok(tipoUsuarioBuscado);
                }
                else
                {
                    return NotFound("Tipo de usuário não encontrado, confira o ID!");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(TiposUsuario tiposUsuario)
        {
            try
            {
                _tipoUsuario.CadastrarTipoUsuario(tiposUsuario);

                return Ok(tiposUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                TiposUsuario tipoUsuarioBuscado = _tipoUsuario.BuscarPorId(id);

                if (tipoUsuarioBuscado != null)
                {
                    _tipoUsuario.DeletarTipoUsuario(id);

                    return Ok($"O tipoUsuario {tipoUsuarioBuscado.TituloTipoUsuario} foi deletado");
                }
                else
                {
                    return NotFound("Tipo de usuário não foi encontrado, confirao ID!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoUsuario.ListarTiposUsuarios());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
