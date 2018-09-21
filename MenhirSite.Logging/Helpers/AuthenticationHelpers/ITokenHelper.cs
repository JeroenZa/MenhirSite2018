using System;
using System.Threading.Tasks;
using MenhirSite.Model;

namespace MenhirSite.BusinessLogic.Helpers.AuthenticationHelpers
{
    public interface ITokenHelper
    {
        (Guid token, DateTime until) SetToken(User user);
        Task<(Guid token, DateTime until)> ExtendTokenAsync(Guid token);
    }
}