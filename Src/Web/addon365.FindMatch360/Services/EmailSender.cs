using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender()
        {

        }
        //help support
        //https://stackoverflow.com/questions/20906077/gmail-error-the-smtp-server-requires-a-secure-connection-or-the-client-was-not
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string fromMail = "ilamaimatrimony@gmail.com";
            string fromPassword = "M@trim0ny1234";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = "<html><body> " + htmlMessage + " </body></html>";
            message.IsBodyHtml = true;

            //client.UseDefaultCredentials = true;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
            
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };
            smtpClient.Send(message);
        }

    }
}
