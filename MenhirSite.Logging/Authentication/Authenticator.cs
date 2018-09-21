using System;
using System.Threading.Tasks;
using MenhirSite.BusinessLogic.Helpers.AuthenticationHelpers;
using MenhirSite.BusinessLogic.Logging;
using MenhirSite.Model;
using MenhirSite.Services.Interface;

namespace MenhirSite.BusinessLogic.Authentication
{
    public class Authenticator : IAuthenticator
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly IPasswordHelper _passwordHelper;
        private readonly ITokenHelper _tokenHelper;

        public Authenticator(ILogger logger, 
                             IUserService userService,
                             IPasswordHelper passwordHelper,
                             ITokenHelper tokenHelper)
        {
            _logger = logger;
            _userService = userService;
            _passwordHelper = passwordHelper;
            _tokenHelper = tokenHelper;
        }

        public async Task<(Guid token, DateTime until)> AuthenticateAsync(string username, string password)
        {
            try
            {
                var user = await _userService.GetUserByUsernameAsync(username);

                if (user == null)
                    throw new UnauthorizedAccessException("User not found");

                var isValidPassword = _passwordHelper.ValidatePassword(user.HashedPassword, password);

                if (!isValidPassword)
                    throw new UnauthorizedAccessException("Password incorrect");

                return _tokenHelper.SetToken(user);
            }
            catch (Exception e) when (!(e is UnauthorizedAccessException)) 
            {
                _logger.WriteLog(LogLevel.Error, "An exception occurred in Authenticator.AuthenticateAsync", e.Message,
                    e.StackTrace);
                throw;
            }
        }

        public async Task<(Guid token, DateTime until)> ExtendAuthenticationAsync(Guid token)
        {
            try
            {
                return await _tokenHelper.ExtendTokenAsync(token);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "An exception occurred in Authenticator.ExtendAuthenticationAsync", e.Message,
                    e.StackTrace);
                throw;
            }
        }
    }
}