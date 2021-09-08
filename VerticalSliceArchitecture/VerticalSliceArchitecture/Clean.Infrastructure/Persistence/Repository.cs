using Clean.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Clean.Infrastructure.Persistence
{
    public class Repository<T> : IRepository<T>
    {
        // Implement Entity Framework, NHibernate, Dapper, etc.
        public async Task<int> AddAsync(T entity, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> FindAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> SaveAsync(T entity, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
