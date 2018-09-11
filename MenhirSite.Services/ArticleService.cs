using MenhirSite.Model;
using MenhirSite.Repository.Interfaces;
using MenhirSite.Services.Interface;

namespace MenhirSite.Services
{
    public class ArticleService : GenericService<Article>, IArticleService
    {
        public ArticleService(IUnitOfWork unitOfWork, IGenericRepository<Article> repository) : base(unitOfWork, repository)
        {
        }
    }
}