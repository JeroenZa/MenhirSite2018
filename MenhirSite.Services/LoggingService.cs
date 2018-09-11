using MenhirSite.Model;
using MenhirSite.Repository.Interfaces;
using MenhirSite.Services.Interface;

namespace MenhirSite.Services
{
    public class LoggingService : GenericService<Logging>, ILoggingService
    {
        public LoggingService(IUnitOfWork unitOfWork, IGenericRepository<Logging> repository) : base(unitOfWork, repository)
        {
        }
    }
}