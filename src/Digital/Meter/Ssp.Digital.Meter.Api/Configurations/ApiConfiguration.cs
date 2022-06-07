namespace Ssp.Digital.Meter.API.Configurations;

using Ssp.Digital.Meter.Infrastructure.Configurations;

/// <summary>
/// This Config class allows to pull configuration from several sub projects and setting files.
/// </summary>
public class ApiConfiguration
{
    public MongoDbConfiguration MongoDbConfiguration { get; set; } = new();
}