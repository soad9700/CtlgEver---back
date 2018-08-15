using System.Threading.Tasks;
using MimeKit;

namespace CtlgEver.Infrastructure.EmailFactory.Interfaces
{
    public interface IEmailFactory
    {
        Task SendEmailAsync(MimeMessage mimeMessage);
    }
}