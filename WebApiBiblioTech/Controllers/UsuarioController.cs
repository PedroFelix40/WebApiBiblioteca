using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapibibliotech.Domains;
using webapibibliotech.Interfaces;

namespace webapibibliotech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario)); // Validação para conferir se a instância de IGenero é != de null
        }

        [HttpGet("BuscarPorEmailESenha")]
        public IActionResult GetByEmailAndPassword(string email, string senha)
        {
            try
            {
                return Ok(_usuario.BuscarPorEmailESenha(email, senha));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuarios usuarioBuscado = _usuario.BuscarPorId(id);

                return Ok(usuarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Usuarios usuario)
        {
            try
            {
                _usuario.Cadastrar(usuario);
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Usuarios> ListaUsuario = _usuario.ListarUsuarios();

                return Ok(ListaUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
