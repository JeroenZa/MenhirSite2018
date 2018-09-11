using MenhirSite.Model;
using MenhirSite.Repository.Interfaces;
using MenhirSite.Services.Interface;

namespace MenhirSite.Services
{
    public class PersonService : GenericService<Person>, IPersonService
    {
        public PersonService(IUnitOfWork unitOfWork, IGenericRepository<Person> repository) : base(unitOfWork, repository)
        {
        }
    }
}