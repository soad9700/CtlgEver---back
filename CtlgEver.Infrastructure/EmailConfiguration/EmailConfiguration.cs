using CtlgEver.Infrastructure.EmailConfiguration.Interfaces;

namespace CtlgEver.Infrastructure.EmailConfiguration
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public string SmtpServer { get; set; } = "smtp.gmail.com";
        public int SmtpPort { get; set; } = 587;
        public string SmtpUsername { get; set; } = "ctlgevertest@gmail.com";
        public string SmtpPassword { get; set; } = "ctlgever";
        public string Name { get; set; } = "CtlgEver";
    }
}