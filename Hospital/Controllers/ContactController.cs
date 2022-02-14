using Hospital.Models;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Hospital.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailSender _emailSender;

        public ContactController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult ContactMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactMail(Contactus contactus)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("");
                mail.To.Add("");
                //mail.CC.Add("");
                //mail.Bcc.Add("");
                mail.Subject = contactus.Subject;
                mail.IsBodyHtml = true;
                string content = "Name : " + contactus.Name;
                content += "<br/> Message : " + contactus.Message;
                mail.Body = content;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                NetworkCredential networkCredential = new NetworkCredential("", "");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
                smtpClient.Host= "smtp.gmail.com";
                smtpClient.Timeout = 20000;
                ViewBag.Message = "Mail Send";
                ModelState.Clear();
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
            }
            return View();
        }
    }
}
