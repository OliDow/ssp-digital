using MongoDB.Driver;

namespace Ssp.Digital.Meter.Infrastructure.Data;

public interface IMeterProjectionsContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}