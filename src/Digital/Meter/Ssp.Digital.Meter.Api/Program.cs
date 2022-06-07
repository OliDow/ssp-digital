using Ssp.Digital.Meter.API.Configurations;
using Ssp.Digital.Meter.API.Queries;
using Ssp.Digital.Meter.Api.Schema.Queries;
using Ssp.Digital.Meter.Core.Repositories;
using Ssp.Digital.Meter.Infrastructure.Data;
using Ssp.Digital.Meter.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurations
var configValue = builder.Configuration.Get<ApiConfiguration>();
builder.Services.AddSingleton(configValue.MongoDbConfiguration);

// Repositories
builder.Services.AddSingleton<IMeterProjectionsContext, MeterProjectionsContext>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IMeterRepository, MeterRepository>();

// GraphQL
builder.Services
    .AddGraphQLServer()
    // .AddAssetTypes() //for assembly registration of annotated using type attributes
    .AddQueryType<Query>()
        .AddTypeExtension<MeterQueries>()
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

var app = builder.Build();

app.MapGraphQL();

app.UseAuthentication();

app.Run();