using MongoDB.Driver;
using Ssp.Digital.Meter.Core.Entities;
using Ssp.Digital.Meter.Core.Repositories;
using Ssp.Digital.Meter.Infrastructure.Data;

namespace Ssp.Digital.Meter.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly IMongoCollection<T> _collection;

    public BaseRepository(IMeterProjectionsContext catalogContext)
    {
        if (catalogContext == null)
        {
            throw new ArgumentNullException(nameof(catalogContext));
        }

        _collection = catalogContext.GetCollection<T>(typeof(T).Name);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<T> GetByIdAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq(_ => _.Id, id);

        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<T> InsertAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);

        return entity;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        var result = await _collection.DeleteOneAsync(Builders<T>.Filter.Eq(_ => _.Id, id));

        return result.DeletedCount > 0;
    }
}