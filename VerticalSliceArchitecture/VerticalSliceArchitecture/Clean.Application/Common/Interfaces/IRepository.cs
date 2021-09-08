using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Clean.Application.Common.Interfaces
{
    public interface IRepository<T>
    {
        Task<int> AddAsync(T entity, CancellationToken cancellationToken);
        Task<int> SaveAsync(T entity, CancellationToken cancellationToken);
        Task<T> FindAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}
