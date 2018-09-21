using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Autofac.Integration.WebApi;
using MenhirSite.BusinessLogic.Logging;
using MenhirSite.Model;
using MenhirSite.Services.Interface;
using NSwag.Annotations;

namespace MenhirSite.Controllers
{
    [AutofacControllerConfiguration]
    [RoutePrefix("api/team")]
    public class TeamController : GenericController<Team>
    {
        private readonly ITeamService _service;
        private readonly ILogger _logger;

        public TeamController(ITeamService service, ILogger logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Team>))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, $"TeamController GetAll requested");                
                var all = await _service.GetAllAsync();
                return Ok(all);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, $"Exception occured in TeamController.GetAll", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Team))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, $"TeamController Get requested");
                var entity = _service.GetById(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, $"Exception occured in TeamController.Get", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("menu")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<string>))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public async Task<IHttpActionResult> GetMenuNames()
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, $"TeamController GetMenuNames requested");
                var menuNames = await _service.GetTeamMenuNamesAsync();
                return Ok(menuNames);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, $"Exception occured in TeamController.GetMenuNames", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

    }
}