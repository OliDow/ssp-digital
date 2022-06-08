using MongoDB.Driver;
using Ssp.Common.Data.Mongo;

namespace Ssp.Digital.Meter.Infrastructure.Data;

public class MeterProjectionsContext : IMeterProjectionsContext
{
    private readonly IMongoDatabase _database;

    public MeterProjectionsContext(IMongoSettings mongoDbConfiguration)
    {
        var client = new MongoClient(mongoDbConfiguration.ConnectionString);

        _database = client.GetDatabase(mongoDbConfiguration.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}