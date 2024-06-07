using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapibibliotech.Contexts;
using webapibibliotech.Utils.Mail;

namespace webapibibliotech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RecuperarSenhaController : ControllerBase
    {
        private readonly BiblioTechContext _context;
        private readonly EmailSendService _emailSendingService;
        public RecuperarSenhaController(BiblioTechContext context, EmailSendService emailSendService)
        {
            _context = context;
            _emailSendingService = emailSendService;
        }

        [HttpPost]
        public async Task<IActionResult> SendRecoveryCodePassword(string email)
        {
            try
            {
                var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);

                if (user == null)
                {
                    return NotFound("Usuário não encontrado!");
                }

                // Gerar um código com quatro digitos ( Baseado na tela do projeto Vitalhub ):
                Random random = new Random();
                int recoveryCode = random.Next(1000, 9999);

                user.CodRecupSenha = recoveryCode;
                await _context.SaveChangesAsync();

                await _emailSendingService.SendRecovery(user.Email!, recoveryCode);

                return Ok("Codigo gerado com sucesso!");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostValidacao")]
        public async Task<IActionResult> ValidateRecoveryCode(string email, int codigo)
        {
            try
            {
                var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null)
                {
                    return NotFound("Usuário não encontrado!");
                }

                if (user.CodRecupSenha != codigo)
                {
                    return BadRequest("Código de recuperação inválido!");
                }

                // Resetar o codigo no banco:
                user.CodRecupSenha = null;

                await _context.SaveChangesAsync();
                return Ok("Código de recuperação válido!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
