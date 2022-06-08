// using MongoDB.Driver;
// using Ssp.Digital.Projections.Meter;
//
// namespace Ssp.Digital.Meter.Infrastructure.Data;
//
// public class MeterContextSeed
// {
//     public static void SeedData(IMongoDatabase database)
//     {
//         InsertMeters(database.GetCollection<MeterProjection>(nameof(MeterProjection)));
//     }
//
//     private static void InsertMeters(IMongoCollection<MeterProjection> categoryCollection)
//     {
//         categoryCollection.DeleteMany(_ => true);
//         categoryCollection.InsertMany(
//             new List<MeterProjection>
//             {
//                 new()
//                 {
//                     Id = "629f0d4adeca3a5d54138225",
//                     AccountNumber = "Category Description One"
//                 },
//                 new()
//                 {
//                     Id = "629f0d59827f3ea744ed11f8",
//                     AccountNumber = "Category Description Two"
//                 }
//             });
//     }
// }