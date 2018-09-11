using MenhirSite.Model;
using MenhirSite.Model.Context;
using MenhirSite.Repository.Interfaces;

namespace MenhirSite.Repository
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        public MatchRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}