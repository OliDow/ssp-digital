using Ssp.Common.Data.Mongo;

namespace Ssp.Digital.Meter.Api.Configurations;

/// <summary>
/// This Config class allows to pull configuration from several sub projects and setting files.
/// </summary>
public class ApiConfiguration
{
    public MongoDbConfiguration MongoDbConfiguration { get; set; } = new();
}