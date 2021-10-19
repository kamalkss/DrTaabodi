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

        public struct ContactUsStructure
        {
            public string fullname;
            public string email;
            public string subject;
            public string message;
        }

        [HttpPost]
        public void SendMail([FromBody] ContactUsStructure contact)
        {
            SmtpClient client = new SmtpClient();
            client.Host = configuration["SMTP:Host"];
            client.Port = configuration.GetValue<int>("SMTP:Port");
            client.Credentials = new NetworkCredential(configuration["SMTP:Username"] ?? "", configuration["SMTP:Password"] ?? "");
            client.EnableSsl = true;

            MailMessage messageObject = new MailMessage(new MailAddress(contact.email), new MailAddress(configuration["SMTP:MailAddress"]));
            messageObject.Subject = contact.subject;
            messageObject.Body = contact.message;

            client.Send(messageObject);
        }
    }
}
