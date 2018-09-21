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
    [RoutePrefix("api/article")]
    public class ArticleController : GenericController<Article>
    {
        private readonly IGenericService<Article> _service;
        private readonly ILogger _logger;

        public ArticleController(IGenericService<Article> service, ILogger logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Article>))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, $"ArticleController GetAll requested");
                var all = await _service.GetAllAsync();
                return Ok(all);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, $"Exception occured in ArticleController.GetAll", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Article))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, $"ArticleController Get requested");
                var entity = _service.GetById(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, $"Exception occured in ArticleController.Get", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }
    }
}