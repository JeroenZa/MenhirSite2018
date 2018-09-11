using MenhirSite.Model;
using MenhirSite.Model.Context;
using MenhirSite.Repository.Interfaces;

namespace MenhirSite.Repository
{
    public class FileRepository : GenericRepository<File>, IFileRepository
    {
        public FileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}