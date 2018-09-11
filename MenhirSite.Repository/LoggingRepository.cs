using MenhirSite.Model;
using MenhirSite.Model.Context;
using MenhirSite.Repository.Interfaces;

namespace MenhirSite.Repository
{
    public class LoggingRepository : GenericRepository<Logging>, ILoggingRepository
    {
        public LoggingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}