using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapibibliotech.Domains;
using webapibibliotech.Interfaces;
using webapibibliotech.Repositories;
using webapibibliotech.ViewModel;

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

        [HttpPut("AlterarSenha")]
        public IActionResult UpdatePassword(string email, AlterarSenhaViewModel senha)
        {
            try
            {
                _usuario.AlterarSenha(email, senha.SenhaNova!);

                return Ok("Senha alterada com sucesso !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpGet("BuscarPorEmail")]
        public IActionResult GetByEmail(string email)
        {
            try
            {
                return Ok(_usuario.BuscarPorEmail(email));
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

                if (usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);
                }

                return NotFound("Nada foi encontrado");
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

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Usuarios usuarioBuscado = _usuario.BuscarPorId(id);

                if (usuarioBuscado != null)
                {
                    _usuario.Deletar(id);

                    return Ok("O usuário foi deletado!");
                }
                return null!;
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

                if (ListaUsuario != null)
                {
                    return Ok(ListaUsuario);
                }
                return NotFound("Não foi encontrado nada!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
