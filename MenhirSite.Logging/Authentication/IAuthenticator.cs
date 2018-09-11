using System;
using System.Threading.Tasks;

namespace MenhirSite.BusinessLogic.Authentication
{
    public interface IAuthenticator
    {
        Task<(Guid token, DateTime until)> AuthenticateAsync(string username, string password);
    }
}