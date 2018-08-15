using System;
using System.Threading.Tasks;
using CtlgEver.Core.Domains;
using CtlgEver.Infrastructure.EmailConfiguration.Interfaces;
using CtlgEver.Infrastructure.EmailFactory.Interfaces;
using MimeKit;

namespace CtlgEver.Infrastructure.EmailFactory
{
    public class UserEmailFactory : IUserEmailFactory
    {
        private readonly IEmailFactory _emailFactory;
        private readonly IEmailConfiguration _emailConfiguration;

        public UserEmailFactory (IEmailFactory emailFactory, IEmailConfiguration emailConfiguration)
        {
            _emailFactory = emailFactory;
            _emailConfiguration = emailConfiguration;
        }
        
        public async Task SendActivationEmailAsync(User user, Guid activationKey)
        {
            var message = new MimeMessage ();
            message.From.Add (new MailboxAddress (_emailConfiguration.Name, _emailConfiguration.SmtpUsername));
            message.To.Add (new MailboxAddress (user.Name, user.Email));
            message.Subject = "Aktywacja konta w CtlgEver";
            message.Body = new TextPart ("html") { Text = $"Oto automatycznie wygenerowany mail potwierdzajacy twoją rejestrację w serwisie <b>CtlgEver</b><br/> Kliknij w <a href=\"http://localhost:5000/api/user/activation/{activationKey}\">link aktywacyjny</a>, który aktywuje twoje konto."};
            await _emailFactory.SendEmailAsync (message);
        }
    }
}