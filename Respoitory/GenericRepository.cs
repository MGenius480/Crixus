using CrixusJa.Data;
using CrixusJa.iRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CrixusJa.Respoitory
{
    public class GenericRepository<A> : IGenericRepository<A> where A : class
    {
        private readonly Datacontext _context;
        private readonly DbSet<A> _db;

        public GenericRepository(Datacontext context)
        {
            _context = context;
            _db = context.Set<A>();
        }

        public async Task Delete (string username)
        {
            var entity = await _db.FindAsync(username);
            _db.Remove(entity);
        }

        public void DeleteRange (IEnumerable<A> entities)
        {
            _db.RemoveRange(entities);
        }

        public async Task<A> Get(Expression<Func<A, bool>> expression = null, List<string> includes = null)
        {
            IQueryable<A> query = _db;
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<A>> GetAll(Expression<Func<A, bool>> expression = null, Func<IQueryable<A>, IOrderedQueryable<A>> orderBy = null, List<string> includes = null)
        {
            IQueryable<A> query = _db;

            if (expression != null)
            {
                query = query.Where(expression);
            }


            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }


            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(A entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<A> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(A entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        Task IGenericRepository<A>.DeleteRange(string username)
        {
            throw new NotImplementedException();
        }

        
    }
}
