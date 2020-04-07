using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AjudaHumana.Core.Communication.Email
{
    public class EmailService : IEmailSender
    {
        private readonly Settings _emailSettings;

        public EmailService(IOptions<Settings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, "Ruan Pelissoli")
                };

                mail.To.Add(new MailAddress(email));

                mail.Subject = "Seja bem vindo ao Ajuda Humana - " + subject;
                mail.Body = htmlMessage;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort);

                byte[] data = Convert.FromBase64String(_emailSettings.UsernamePassword);
                string decodedString = Encoding.UTF8.GetString(data);

                smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, decodedString);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
