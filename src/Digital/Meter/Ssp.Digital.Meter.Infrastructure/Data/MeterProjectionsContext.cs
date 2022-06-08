using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Ssp.Common.Data.Mongo;

namespace Ssp.Digital.Meter.Infrastructure.Data;

public class MeterProjectionsContext : IMeterProjectionsContext
{
    private readonly IMongoDatabase _database;

    public MeterProjectionsContext(IOptions<MongoSettings> mongoDbConfigurationOptions)
    {
        var mongoSettings = mongoDbConfigurationOptions.Value;
        var client = new MongoClient(mongoSettings.ConnectionString);

        _database = client.GetDatabase(mongoSettings.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}