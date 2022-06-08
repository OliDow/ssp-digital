using Ssp.Common.Data.Extensions;
using Ssp.Common.Data.Repository;
using Ssp.Digital.Meter.Api.Schema.Queries;
using Ssp.Digital.Meter.Core.Repositories;
using Ssp.Digital.Meter.Infrastructure.Data;
using Ssp.Digital.Meter.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add MongoDB
builder.Services.AddMongo();

// Repositories
builder.Services.AddSingleton<IMeterProjectionsContext, MeterProjectionsContext>();
builder.Services.AddScoped(typeof(IReadModelRepository<>), typeof(ReadModelRepository<>));
builder.Services.AddScoped<IMeterRepository, MeterRepository>();

// GraphQL
builder.Services
    .AddGraphQLServer()
    .AddAssetTypes() // for assembly registration of annotated using type attributes
    .AddQueryType<Query>()
    // .AddTypeExtension<MeterQueries>()
    // .AddMutationType<Mutations>()
    // .AddTypeExtension<MeterMutations>()
    // .AddSubscriptionType()
    // .AddMutationConventions()

    // order of there next items: UsePaging > UseProjection > UseFiltering > UseSorting
    // .AddProjections()
    // .AddFiltering()
    // .AddSorting()

    // MongoDb Equivalents for Db Side: DbProjections, Filtering & Sorting
    .AddMongoDbPagingProviders()
    .AddMongoDbProjections()
    .AddMongoDbFiltering()
    .AddMongoDbSorting();

builder.Services.AddCqrs();

var app = builder.Build();

app.MapGraphQL();
app.UseGraphQLVoyager();
// app.UseAuthentication();

app.Run();