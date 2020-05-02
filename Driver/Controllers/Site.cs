using System;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Threading.Tasks;
using Driver.Models;
using Driver.Service;
using Microsoft.AspNetCore.Mvc;

namespace Driver.Controllers
{
    public class Site : Controller
    {

        private const String SmtpLine = "smtp.gmail.com";

        private const String Mail = "autoakula@gmail.com";
        private const String Password = "driver2018";
        
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
            SmtpClient smtp = new SmtpClient(SmtpLine);
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(Mail, Password);
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(Mail);
                mailMessage.To.Add(sender.ForMail);
                mailMessage.Subject = "Новая заявка с сайта";
                mailMessage.Body = sender.ToString();
                smtp.Send(mailMessage);
            }
        }
    }
}