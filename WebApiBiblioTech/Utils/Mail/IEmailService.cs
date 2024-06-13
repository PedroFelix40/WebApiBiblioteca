namespace webapibibliotech.Utils.Mail
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailResquest);
    }
}
