using MongoDB.Driver;
using Ssp.Digital.Meter.Infrastructure.Configurations;

namespace Ssp.Digital.Meter.Infrastructure.Data;

public class MeterProjectionsContext : IMeterProjectionsContext
{
    private readonly IMongoDatabase _database;

    public MeterProjectionsContext(MongoDbConfiguration mongoDbConfiguration)
    {
        var client = new MongoClient(mongoDbConfiguration.ConnectionString);

        _database = client.GetDatabase(mongoDbConfiguration.Database);

        // For testing purposes ;)
        MeterContextSeed.SeedData(_database);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}