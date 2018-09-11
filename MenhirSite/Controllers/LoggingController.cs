﻿using Autofac.Integration.WebApi;
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
    public class LoggingController : ApiController
    {
        private readonly ILogger _logger;
        private readonly ILoggingService _loggingService;

        public LoggingController(ILogger logger, ILoggingService loggingService)
        {
            _logger = logger;
            _loggingService = loggingService;
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/logging")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Model.Logging>))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public async Task<IHttpActionResult> GetAllLogging()
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
        [SwaggerResponse(HttpStatusCode.OK, typeof(Model.Logging))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public IHttpActionResult GetLoggingById(int id)
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
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Model.Logging>))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]

        public IHttpActionResult GetLoggingByLevel(string level)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, "Logging by level requested");
                var logLevel = (LogLevel) Enum.Parse(typeof(LogLevel), level);
                var loggingByLevel = _loggingService.FindBy(l => l.Level == logLevel);
                return Ok(loggingByLevel);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "Exception occured in LoggingController.GetLoggingByLevel", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/logging")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int))]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public IHttpActionResult CreateLogging([FromBody] Model.Logging logging)
        {
            if (logging == null)
                return BadRequest("Logging object was empty");

            try
            {
                _logger.WriteLog(LogLevel.Information, "Create logging requested");
                var committed = _loggingService.Create(logging);

                if (committed == 0)
                    return BadRequest("Logging could not be saved");

                return Ok(logging.Id);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "Exception occured in LoggingController.CreateLogging", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/loggin/{id}")]
        [HttpDelete]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public IHttpActionResult DeleteLogging(int id)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, $"Delete of logging {id} requested");
                var loggingToDelete = _loggingService.GetById(id);

                if (loggingToDelete == null)
                    return BadRequest ($"Logging with id {id} not found");

                _loggingService.Delete(loggingToDelete);

                return Ok(id);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "Exception occured in LoggingController.Delete", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }
    }
}