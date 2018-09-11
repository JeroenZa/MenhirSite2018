using MenhirSite.Model;
using MenhirSite.Model.Context;
using MenhirSite.Repository.Interfaces;

namespace MenhirSite.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}