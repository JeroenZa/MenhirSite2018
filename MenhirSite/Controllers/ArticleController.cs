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
    public class ArticleController : ApiController
    {
        private readonly IArticleService _articleService;
        private readonly ILogger _logger;

        public ArticleController(IArticleService articleService, 
                                 ILogger logger)
        {
            _articleService = articleService;
            _logger = logger;
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/article")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Article>))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public async Task<IHttpActionResult> GetAllArticles()
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, "All articles requested");                
                var allArticles = await _articleService.GetAllAsync();
                return Ok(allArticles);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "Exception occured in ArticeController.GetAllArticles", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/article/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Article))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public IHttpActionResult GetArticle(int id)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, "Article requested");
                var article = _articleService.GetById(id);
                return Ok(article);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "Exception occured in ArticeController.GetArticle", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/article")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public IHttpActionResult CreateArticle([FromBody] Article article)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, "Create article requested");
                var committed = _articleService.Create(article);

                if (committed == 0)
                    return BadRequest("Article could not be saved");

                return Ok(article.Id);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "Exception occured in ArticeController.CreateArticle", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/article/{id}")]
        [HttpPut]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public IHttpActionResult UpdateArticle([FromBody] Article article)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, $"Update of article with id {article.Id} requested");
                var committed = _articleService.Update(article);

                if (committed == 0)
                    return BadRequest("Article could not be saved");

                return Ok(article.Id);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "Exception occured in ArticeController.UpdateArticle", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/article/{id}")]
        [HttpDelete]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(bool))]
        public IHttpActionResult DeleteArticle(int id)
        {
            try
            {
                _logger.WriteLog(LogLevel.Information, $"Delete of article {id} requested");
                var articleToDelete = _articleService.GetById(id);

                if (articleToDelete == null)
                    return BadRequest ($"Article with id {id} not found");

                _articleService.Delete(articleToDelete);

                return Ok(id);
            }
            catch (Exception e)
            {
                _logger.WriteLog(LogLevel.Error, "Exception occured in ArticeController.Delete", e.Message, e.StackTrace);
                return StatusCode(HttpStatusCode.Conflict);
            }
        }
    }
}