using System;
using System.Net;
using MailKit;
using System.Security;
using System.Threading.Tasks;
using Driver.Models;
using Driver.Service;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Driver.Controllers
{
    public class Site : Controller
    {
        private readonly EmailService _emailService = new();
        private readonly TGService _tgService = new();

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
            try
            {
                _tgService.SendMessageAsync(sender);
            }
            catch (Exception e)
            {
                Logger logger = new Logger();
                logger.CreateLog(new FileLogger(), e.Message);
            }
        }
    }
}