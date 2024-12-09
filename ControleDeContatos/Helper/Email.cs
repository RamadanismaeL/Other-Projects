using System.Net;
using System.Net.Mail;

namespace ControleDeContatos.Helper
{
    /*
    *@author Ramadan ismaeL
    */
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;
        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                string? username = _configuration.GetValue<string>("SmtpSettings:UserName");
                string? name = _configuration.GetValue<string>("SmtpSettings:Name");
                string? password = _configuration.GetValue<string>("SmtpSettings:Password");
                string? host = _configuration.GetValue<string>("SmtpSettings:Host");
                int port = _configuration.GetValue<int>("SmtpSettings:Port");

                #pragma warning disable CS8604 // Possible null reference argument.
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(username, name)
                };
                #pragma warning restore CS8604 // Possible null reference argument.
                mail.To.Add(email);
                mail.Subject = assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using(SmtpClient smtp = new SmtpClient(host, port))
                {
                    smtp.Credentials = new NetworkCredential(username, password);
                    smtp.EnableSsl = true;

                    smtp.Send(mail);

                    return true;
                }
            }
            catch(Exception erro)
            {
                Console.WriteLine($"Erro ao enviar o email: {erro.Message}");
                Console.WriteLine(erro.StackTrace);
                return false;
            }
        }
    }
}