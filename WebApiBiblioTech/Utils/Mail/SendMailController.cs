using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapibibliotech.Utils.Mail;

namespace webapibibliotech.Utils.Mail
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly IEmailService emailService;
        public SendMailController(IEmailService service)
        {

            emailService = service;

        }

        [HttpPost("EnviarEmail")]
        public async Task<IActionResult> SendMail(string email, string userName)
        {
            try
            {
                // Cria objeto para receber os dados do e-mail a ser enviado
                MailRequest mailRequest = new MailRequest();

                // Define o endereço e assunto
                mailRequest.ToEmail = email;
                mailRequest.Subject = "Olá, esse é um email vindo da turma de DEV";

                // Toda parte visual do Email(corpo do email)
                mailRequest.Body = GetHtmlContent(userName);

                // Chama o método que enviará o email
                await emailService.SendEmailAsync(mailRequest);

                return Ok("Email enviado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Falha ao enviar o email! ");
            };
        }

        private string GetHtmlContent(string userName)
        {
            // Constrói o conteúdo HTML do e-mail, incluindo o nome do usuário
            string Response = @"
         <div style=""width:100%; background-color:rgba(96, 191, 197, 1); padding: 20px;"">
            <div style=""max-width: 600px; margin: 0 auto; background-color:#FFFFFF; border-radius: 10px; padding: 20px;"">
                <img src=""https://blobbibliotech.blob.core.windows.net/blobbibliotech/LOGO.png"" alt="" Logotipo da Aplicação"" style="" display: block; margin: 0 auto; max-width: 200px;"" />
                <h1 style=""color: #333333; text-align: center;"">Bem-vindo ao BiblioTech!</h1>
                <p style=""color: #666666; text-align: center;"">Olá <strong>" + userName + @"</strong>,</p>
                <p style=""color: #666666;text-align: center"">Estamos muito felizes por você ter se inscrito na plataforma BiblioTech.</p>
                <p style=""color: #666666;text-align: center"">Explore todas as funcionalidades que oferecemos e encontre os melhores livros.</p>
                <p style=""color: #666666;text-align: center"">Se tiver alguma dúvida ou precisar de assistência, nossa equipe de suporte está sempre pronta para ajudar.</p>
                <p style=""color: #666666;text-align: center"">Aproveite sua experiência conosco!</p>
                <p style=""color: #666666;text-align: center"">Atenciosamente,<br>Equipe BiblioTech</p>
            </div>
        </div>";

            // Retorna o conteúdo HTML do e-mail
            return Response;
        }
    }
}