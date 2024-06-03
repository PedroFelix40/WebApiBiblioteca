using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBiblioTech.Domains;
using WebApiBiblioTech.Interfaces;

namespace WebApiBiblioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario)); // Validação para conferir se a instância de IGenero é != de null
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
