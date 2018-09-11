namespace MenhirSite.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}