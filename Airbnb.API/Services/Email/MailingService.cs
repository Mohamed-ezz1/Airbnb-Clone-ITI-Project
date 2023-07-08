using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net.Mail;
using System.Net;
namespace Airbnb.API;
public class MailingService : IMailingService
{
    private readonly MailSetting mailSetting;

    public MailingService(IOptions<MailSetting> _mailSetting)
    {
        this.mailSetting = _mailSetting.Value;
    }
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        string fromMail = "amrkotp111@gmail.com";
        string fromPassword = "wfhesrtplhtvagkv";

        MailMessage message = new MailMessage();
        message.From = new MailAddress(fromMail);
        message.Subject = subject;
        message.Body = $"<html><body>{htmlMessage}</body></html>";
        message.IsBodyHtml = true;
        message.To.Add(email);

        var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromMail, fromPassword),
            EnableSsl = true,
        };

        smtpClient.Send(message);
    }
}
