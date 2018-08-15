using System;
using System.Threading.Tasks;
using CtlgEver.Core.Domains;

namespace CtlgEver.Infrastructure.EmailFactory.Interfaces
{
    public interface IUserEmailFactory
    {
        Task SendActivationEmailAsync(User user, Guid activationKey);
        
    }
}