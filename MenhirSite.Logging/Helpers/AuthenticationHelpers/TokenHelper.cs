using MenhirSite.Model;
using MenhirSite.Services.Interface;
using System;
using System.Threading.Tasks;

namespace MenhirSite.BusinessLogic.Helpers.AuthenticationHelpers
{
    public class TokenHelper : ITokenHelper
    {
        private readonly IUserService _userService;

        public TokenHelper(IUserService userService)
        {
            _userService = userService;
        }

        public (Guid token, DateTime until) SetToken(User user)
        {
            var token = Guid.NewGuid();
            var until = DateTime.UtcNow;

            user.AuthenticationToken = token;
            user.AuthenticatedUntil = until;
            _userService.Update(user);

            return (token, until);
        }

        public async Task<(Guid token, DateTime until)> ExtendTokenAsync(Guid token)
        {
            var user = await _userService.GetUserByTokenAsync(token);

            if (user == null)
                throw new UnauthorizedAccessException();

            var until = DateTime.UtcNow;
            user.AuthenticatedUntil = until;
            _userService.Update(user);

            return (token, until);
        }
    }
}
