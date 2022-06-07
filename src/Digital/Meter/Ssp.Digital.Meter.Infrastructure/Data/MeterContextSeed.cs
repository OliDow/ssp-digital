using MongoDB.Driver;

namespace Ssp.Digital.Meter.Infrastructure.Data;

public class MeterContextSeed
{
    public static void SeedData(IMongoDatabase database)
    {
        InsertMeters(database.GetCollection<Core.Entities.Meter>(nameof(Core.Entities.Meter)));
    }

    private static void InsertMeters(IMongoCollection<Core.Entities.Meter> categoryCollection)
    {
        categoryCollection.DeleteMany(_ => true);
        categoryCollection.InsertMany(
            new List<Core.Entities.Meter>
            {
                    new()
                    {
                        Id = "629f0d4adeca3a5d54138225",
                        TestField = "Category Description One"
                    },
                    new()
                    {
                        Id = "629f0d59827f3ea744ed11f8",
                        TestField = "Category Description Two"
                    }
            });
    }
}