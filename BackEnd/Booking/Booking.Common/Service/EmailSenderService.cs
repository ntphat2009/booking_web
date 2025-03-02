using Booking.Common.Configuration;
using Booking.Common.Model;
using Booking.Common.Service.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;
using System.Net.Http;

namespace Booking.Common.Service
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailConfiguration _configuration;

        public EmailSenderService(EmailConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool SendEmail(Messages message)
        {
            try
            {
                var emailMessage = CreateEmailMessage(message);
                Send(emailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }
        private MimeMessage CreateEmailMessage(Messages message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("NoReply", _configuration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            //emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = message.Content // Thay vì body text
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }
        private void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_configuration.SmtpServer, _configuration.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_configuration.UserName, _configuration.Password);
                client.Send(mailMessage);
            }
            catch
            {
                //log an error message or throw an exception or both.
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
