using MongoDB.Driver;
using Ssp.Common.Data.Projections;
using Ssp.Common.Data.Repository;
using Ssp.Digital.Meter.Infrastructure.Data;

namespace Ssp.Digital.Meter.Infrastructure.Repositories;

public class ReadModelRepository<T> : IReadModelRepository<T>
    where T : IProjection
{
    private readonly IMongoCollection<T> _collection;

    public ReadModelRepository(IMeterProjectionsContext catalogContext)
    {
        if (catalogContext == null)
        {
            throw new ArgumentNullException(nameof(catalogContext));
        }

        _collection = catalogContext.GetCollection<T>(typeof(T).Name);
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

    public async Task<T> GetByIdAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq(_ => _.Id, id);

        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
}