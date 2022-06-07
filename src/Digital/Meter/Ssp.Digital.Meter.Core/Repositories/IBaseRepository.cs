using Ssp.Digital.Meter.Core.Entities;

namespace Ssp.Digital.Meter.Core.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T> GetByIdAsync(string id);

    // Not needed yet, so leaving these out.

    //Task<T> InsertAsync(T entity);
    //Task<bool> RemoveAsync(string id);
}