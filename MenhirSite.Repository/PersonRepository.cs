using MenhirSite.Model;
using MenhirSite.Model.Context;
using MenhirSite.Repository.Interfaces;

namespace MenhirSite.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}