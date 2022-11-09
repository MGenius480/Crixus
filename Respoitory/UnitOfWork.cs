using CrixusJa.Data;
using CrixusJa.iRepository;

namespace CrixusJa.Respoitory
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Datacontext _context;
        private IGenericRepository<User> _users;

        public UnitOfWork(Datacontext context)
        {
            _context = context;
        }

        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
