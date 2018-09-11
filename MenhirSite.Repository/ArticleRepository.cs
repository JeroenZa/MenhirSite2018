using MenhirSite.Model;
using MenhirSite.Model.Context;
using MenhirSite.Repository.Interfaces;

namespace MenhirSite.Repository
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}