using System.Linq.Expressions;

namespace CrixusJa.iRepository
{
    public interface IGenericRepository<A> where A : class
    {
        Task<IList<A>> GetAll(
            Expression<Func<A,bool>> expression = null,
            Func<IQueryable<A>, IOrderedQueryable<A>> orderBy = null,
                List<string> includes = null
            );

        Task<A> Get(Expression<Func<A, bool>> expression, List<string> includes = null);

        Task Insert (A entity);

        Task InsertRange (IEnumerable<A> entities);

        Task Delete(string username);

        Task DeleteRange (string username);

        void Update(A entity);
    }
}
