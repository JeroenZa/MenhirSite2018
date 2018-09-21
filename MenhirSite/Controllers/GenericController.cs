using MenhirSite.BusinessLogic.Logging;
using MenhirSite.Model;
using MenhirSite.Services.Interface;
using NSwag.Annotations;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MenhirSite.Controllers
{
    public class GenericController<T> : ApiController where T : DeletableBaseModel
    {
        private readonly IGenericService<T> _service;
        private readonly ILogger _logger;

        public GenericController(IGenericService<T> service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public IHttpActionResult Create([FromBody] T entity)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, $"{nameof(T)}Controller Create requested");
                var committed = _service.Create(entity);

                if (committed == 0)
                    return BadRequest($"{nameof(T)} could not be saved");

                return Ok(entity.Id);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, $"Exception occured in {nameof(T)}Controller.Create", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("{id}")]
        [HttpPut]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public IHttpActionResult Update([FromBody] T entity)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, $"{nameof(T)}Controller : Update of {entity.Id} requested");
                var committed = _service.Update(entity);

                if (committed == 0)
                    return BadRequest($"{nameof(T)} could not be saved");

                return Ok(entity.Id);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, $"Exception occured in {nameof(T)}Controller.Update", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("{id}")]
        [HttpDelete]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, $"{nameof(T)}Controller Delete of {id} requested");
                var entityToDelete = _service.GetById(id);

                if (entityToDelete == null)
                    return BadRequest($"{nameof(T)} with id {id} not found");

                _service.Delete(entityToDelete);

                return Ok(id);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, $"Exception occured in {nameof(T)}Controller.Delete", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }
    }
}