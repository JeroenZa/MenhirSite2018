using MenhirSite.Model;
using MenhirSite.Repository.Interfaces;
using MenhirSite.Services.Interface;

namespace MenhirSite.Services
{
    public class FileService : GenericService<File>, IFileService
    {
        public FileService(IUnitOfWork unitOfWork, IGenericRepository<File> repository) : base(unitOfWork, repository)
        {
        }
    }
}