using CrixusJa.Data;

namespace CrixusJa.iRepository
{
    public interface IUnitOfWork :IDisposable
    {
        IGenericRepository<User> Users { get; }

        Task Save();
    }
}
