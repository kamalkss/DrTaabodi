using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DrTaabodi.WebApi.Controllers
{
    [ApiController, Route("api/contact-us")]
    public class ContactUsController : Controller
    {
        readonly IConfiguration configuration;
        public ContactUsController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public void sendMail(string fullname, string email, string subject, string message)
        {
            SmtpClient client = new SmtpClient();
            client.Host = configuration["SMTP:Host"];
            client.Port = configuration.GetValue<int>("SMTP:Port");
            client.Credentials = new NetworkCredential(configuration["SMTP:Username"] ?? "", configuration["SMTP:Password"] ?? "");
            client.EnableSsl = true;

            MailMessage messageObject = new MailMessage(new MailAddress(email), new MailAddress(configuration["SMTP:MailAddress"]));
            messageObject.Subject = subject;
            messageObject.Body = message;

            client.Send(messageObject);
        }
    }
}
