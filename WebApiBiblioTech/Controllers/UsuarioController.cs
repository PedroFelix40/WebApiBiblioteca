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

        [HttpPost]  
        public IActionResult Post(Usuarios usuario)
        {
            try
            {
                _usuario.Cadastrar(usuario);
                return Ok(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
