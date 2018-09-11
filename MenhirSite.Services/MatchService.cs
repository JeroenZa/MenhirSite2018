using MenhirSite.Model;
using MenhirSite.Repository.Interfaces;
using MenhirSite.Services.Interface;

namespace MenhirSite.Services
{
    public class MatchService : GenericService<Match>, IMatchService
    {
        public MatchService(IUnitOfWork unitOfWork, IGenericRepository<Match> repository) : base(unitOfWork, repository)
        {
        }
    }
}