using System;
using System.Threading.Tasks;
using MenhirSite.BusinessLogic.Logging;
using MenhirSite.Model;
using MenhirSite.Services.Interface;

namespace MenhirSite.BusinessLogic.Authentication
{
    public class Authenticator : IAuthenticator
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        public Authenticator(ILogger logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public async Task<(Guid token, DateTime until)> AuthenticateAsync(string username, string password)
        {
            User user = null;

            try
            {
                user = await _userService.GetUserByUsername(username);
                return (Guid.Empty, DateTime.MinValue);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "An exception occurred in Authenticator.AuthenticateAsync", e.Message,
                    e.StackTrace);
                return (Guid.Empty, DateTime.MinValue);
            }
            finally
            {
                if (user != null)
                    _userService.Update(user);
            }

        }
    }
}