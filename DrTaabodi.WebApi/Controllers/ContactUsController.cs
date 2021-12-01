using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DrTaabodi.WebApi.Controllers;

[ApiController]
[Route("api/contact-us")]
public class ContactUsController : Controller
{
    private readonly IConfiguration configuration;

    public ContactUsController(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    [HttpPost]
    public void SendMail([FromBody] ContactUsStructure contact)
    {
        var client = new SmtpClient();
        client.Host = configuration["SMTP:Host"];
        client.Port = configuration.GetValue<int>("SMTP:Port");
        client.Credentials =
            new NetworkCredential(configuration["SMTP:Username"] ?? "", configuration["SMTP:Password"] ?? "");
        client.EnableSsl = true;

        var messageObject = new MailMessage(new MailAddress(contact.email),
            new MailAddress(configuration["SMTP:MailAddress"]));
        messageObject.Subject = contact.subject;
        messageObject.Body = contact.message;

        client.Send(messageObject);
    }

    public struct ContactUsStructure
    {
        public string fullname;
        public string email;
        public string subject;
        public string message;
    }
}