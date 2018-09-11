using System.Threading.Tasks;
using MenhirSite.Model;
using MenhirSite.Repository.Interfaces;
using MenhirSite.Services.Interface;

namespace MenhirSite.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository repository) : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _repository.FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}