using Autofac.Integration.WebApi;
using MenhirSite.BusinessLogic.Logging;
using MenhirSite.Model;
using MenhirSite.Services.Interface;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;


namespace MenhirSite.Controllers
{
    [AutofacControllerConfiguration]
    [RoutePrefix("api/logging")]
    public class LoggingController : GenericController<Logging>
    {
        private readonly ILogger _logger;
        private readonly ILoggingService _loggingService;

        public LoggingController(ILoggingService loggingService, ILogger logger) : base(loggingService, logger)
        {
            _logger = logger;
            _loggingService = loggingService;
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/logging")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Logging>))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, "All logging requested");                
                var allLogging = await _loggingService.GetAllAsync();
                return Ok(allLogging);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "Exception occured in LoggingController.GetAllLogging", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/logging/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Logging))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, "Logging by id requested");
                var article = _loggingService.GetById(id);
                return Ok(article);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "Exception occured in LoggingController.GetLoggingById", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/logging/{level}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Logging>))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public IHttpActionResult GetByLevel(string level)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, "Logging by level requested");
                var logLevel = (LogLevel)Enum.Parse(typeof(LogLevel), level);
                var loggingByLevel = _loggingService.FindBy(l => l.Level == logLevel);
                return Ok(loggingByLevel);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "Exception occured in LoggingController.GetLoggingByLevel", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }
    }
}