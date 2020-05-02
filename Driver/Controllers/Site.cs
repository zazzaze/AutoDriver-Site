using System;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Threading.Tasks;
using Driver.Models;
using Driver.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Driver.Controllers
{
    public class Site : Controller
    {
        private EmailAccount _emailAccount;

        public Site()
        {
            _emailAccount =
                JsonConvert.DeserializeObject<EmailAccount>(System.IO.File.ReadAllText("SecretInfo/mailinfo.json"));
        }
        
        // GET
        public ActionResult<String> Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(Sender sender)
        {
            try
            {
                SendMessage(sender);
            }
            catch (Exception e)
            {
                LogError(e);
                return BadRequest();
            }
            return Ok("Успешно");
        }

        private void LogError(Exception e)
        {
            Logger logger = new Logger();
            Task.Run(() => logger.CreateLog(new FileLogger(), e.Message));
        }

        private void SendMessage(Sender sender)
        {
            SmtpClient smtp = new SmtpClient(_emailAccount.Smtp);
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(_emailAccount.Email, _emailAccount.Password);
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(_emailAccount.Email);
                mailMessage.To.Add(sender.ForMail);
                mailMessage.Subject = "Новая заявка с сайта";
                mailMessage.Body = sender.ToString();
                smtp.Send(mailMessage);
            }
        }
    }
}