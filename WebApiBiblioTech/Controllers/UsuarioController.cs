using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapibibliotech.Domains;
using webapibibliotech.Interfaces;
using webapibibliotech.Repositories;
using webapibibliotech.Utils.BlobStorage;
using webapibibliotech.Utils.Mail;
using webapibibliotech.ViewModel;

namespace webapibibliotech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuario _usuario;
        private readonly EmailSendService _emailSendService;

        public UsuarioController(IUsuario usuario, EmailSendService emailSend)
        {
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario)); 
            _emailSendService = emailSend;
        }

        [HttpPut("AlterarSenha")]
        public IActionResult UpdatePassword(string email, AlterarSenhaViewModel senha)
        {
            try
            {
                _usuario.AlterarSenha(email, senha.SenhaNova!);

                return Ok("Senha alterada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AlterarFotoPerfil")]
        public async Task<IActionResult> UpdateProfileImage(Guid id, [FromForm] UsuarioFotoViewModel fotoModel)
        {
            try
            {

                Usuarios usuarioBuscado = _usuario.BuscarPorId(id);


                if (usuarioBuscado == null)
                {
                    return NotFound();
                }


                var connectionString = "DefaultEndpointsProtocol=https;AccountName=blobbibliotech;AccountKey=flFKNyFFk9mH3TXaCqNlaX0g85mclKktqUp0UJw74yQPd28idikZSvGGgF6TzHCwb5+dEHgoVSuR+ASt+PcmLA==;EndpointSuffix=core.windows.net";

                var containerName = "blobbibliotech";

                string fotoUrl = await AzureBlobStorageHelper.UploadImageBlobAsync(fotoModel.Arquivo!, connectionString!, containerName!);


                usuarioBuscado.Foto = fotoUrl;

                _usuario.AtualizarFoto(id, fotoUrl);

                return Ok();
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

                return NotFound("Usuário não foi encontrado!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UsuarioViewModel usuarioModel)
        {
            try
            {
                Usuarios user = new Usuarios();

                user.Email = usuarioModel.Email;
                user.Senha = usuarioModel.Senha;
                user.Nome = usuarioModel.Nome;
                user.IDTipoUsuario = usuarioModel.IdTipoUsuario;
                user.CodRecupSenha = usuarioModel.CodRecupSenha;

                // nome do conteiner e da string de conexao
                var containerName = "blobbibliotech";
                var connectionString = "DefaultEndpointsProtocol=https;AccountName=blobbibliotech;AccountKey=flFKNyFFk9mH3TXaCqNlaX0g85mclKktqUp0UJw74yQPd28idikZSvGGgF6TzHCwb5+dEHgoVSuR+ASt+PcmLA==;EndpointSuffix=core.windows.net";

                // Chamar método de upload de imagens

                user.Foto = await AzureBlobStorageHelper.UploadImageBlobAsync(usuarioModel.Arquivo!, connectionString, containerName);



                _usuario.Cadastrar(user);

                await _emailSendService.SendWelcomeEmail(user.Email!, user.Nome!);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} - Tipo de Exceção: {e.GetType().ToString()}");
            }
        }

        [HttpDelete("DeletarPoId{id}")]
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
