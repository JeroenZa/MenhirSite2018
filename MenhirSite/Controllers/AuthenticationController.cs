using Autofac.Integration.WebApi;
using MenhirSite.BusinessLogic.Logging;
using MenhirSite.Model;
using NSwag.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using MenhirSite.BusinessLogic.Authentication;

namespace MenhirSite.Controllers
{
    [AutofacControllerConfiguration]
    public class AuthenticationController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IAuthenticator _authenticator;

        public AuthenticationController(ILogger logger,
                                        IAuthenticator authenticator)
        {
            _logger = logger;
            _authenticator = authenticator;
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/authentication/{username}/{password}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof((Guid, DateTime)))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(bool))]
        public async Task<IHttpActionResult> Authenticate(string username, string password)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, "User attempting to login");
                var authentication = await _authenticator.AuthenticateAsync(username, password);
                return Ok(authentication);
            }
            catch (UnauthorizedAccessException)
            {
                _logger.WriteLog(LogLevel.Error, $"Failed attempt to login for {username}");
                return StatusCode(HttpStatusCode.Unauthorized);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "Exception occured in AuthenticationController.Authenticate", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/authentication/{token}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof((Guid, DateTime)))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(bool))]
        public async Task<IHttpActionResult> Extend(string token)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, "User attempting to extend");
                var authenticationToken = Guid.Parse(token);
                var authentication = await _authenticator.ExtendAuthenticationAsync(authenticationToken);
                return Ok(authentication);
            }
            catch (UnauthorizedAccessException)
            {
                _logger.WriteLog(LogLevel.Error, $"Failed attempt to extend with token {token}");
                return StatusCode(HttpStatusCode.Unauthorized);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "Exception occured in AuthenticationController.Authenticate", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

    }
}