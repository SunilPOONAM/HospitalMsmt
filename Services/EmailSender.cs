using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        } 

        public async Task SendEmailAsync(string email, string subject, string message)
        {
             await Execute(subject, message, email);
        }

        public async Task Execute(string subject, string message, string email)
        {            
            var senderEmail = new MailAddress(_configuration.GetSection("AppSettings")["EmailUsername"], _configuration.GetSection("AppSettings")["EmailSenderDisplayName"]);
            var receiverEmail = new MailAddress(email, "Index Support");
            var password = _configuration.GetSection("AppSettings")["EmailPassword"];
            var sub = subject;
            var body = message;
            var smtp = new SmtpClient
            {
                Host = _configuration.GetSection("AppSettings")["EmailSMTP"],
                Port = Convert.ToInt32(_configuration.GetSection("AppSettings")["EmailPort"]),
                EnableSsl =Convert.ToBoolean(Convert.ToInt32(_configuration.GetSection("AppSettings")["EmailEnableSSL"])),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)                 
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
              await smtp.SendMailAsync(mess);
            }           
        }
    }
}
