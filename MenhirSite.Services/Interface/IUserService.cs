using System;
using System.Threading.Tasks;
using MenhirSite.Model;

namespace MenhirSite.Services.Interface
{
    public interface IUserService : IGenericService<User>
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByTokenAsync(Guid token);
    }
}