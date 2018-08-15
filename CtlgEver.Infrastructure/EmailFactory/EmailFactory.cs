using System.Threading.Tasks;
using CtlgEver.Infrastructure.EmailConfiguration.Interfaces;
using CtlgEver.Infrastructure.EmailFactory.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace CtlgEver.Infrastructure.EmailFactory
{
    public class EmailFactory : IEmailFactory
    {
        private readonly IEmailConfiguration _emailConfiguration;
        public EmailFactory(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }
        public async Task SendEmailAsync(MimeMessage mimeMessage)
        {
            using(var client = new SmtpClient ()){
                await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}