using System;
using Driver.Models;
using MailKit.Net.Smtp;
using MimeKit;
using Newtonsoft.Json;

namespace Driver.Service
{
    public class EmailService
    {
        private EmailAccount _emailAccount;
        public EmailService()
        {
            _emailAccount =
                JsonConvert.DeserializeObject<EmailAccount>(System.IO.File.ReadAllText("SecretInfo/mailinfo.json"));
        }

        public async void SendEmailAsync(String to, String subject, String body)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Сайт", _emailAccount.Email));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = body
            };
            using (SmtpClient client = new SmtpClient())
            {
                client.Timeout = 2000;
                await client.ConnectAsync(_emailAccount.Smtp, _emailAccount.Port, false);
                await client.AuthenticateAsync(_emailAccount.Email, _emailAccount.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}