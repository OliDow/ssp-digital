using Ssp.Digital.Meter.Api.Schema.Queries;

namespace Ssp.Digital.Meter.Api.Extensions
{
    public static class GraphQlExtension
    {
        public static IServiceCollection AddGraphQlExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var graphQLOptions = configuration.GetRequiredSection("graphQLConfiguration").Get<GraphQlSettings>();

            services
            // Add GraphQL Server
            .AddGraphQLServer()

            // Assembly registration: Simplify your Hot Chocolate configuration code by using automatic type-registration.
            .AddAssetTypes()

            // Add GraphQL Query.
            .AddQueryType<Query>()

            // Add GraphQL Mutations.
            // .AddMutationType<Mutations>()

            // Add GraphQL Subscriptions.
            // .AddSubscriptionType()

            // Add alternitive GraphQL Conventions.
            // .AddMutationConventions()

            // Add Pagination option with Default global options with appsettings.json override.
            .SetPagingOptions(graphQLOptions.Paging)

            // MongoDb Equivalents for Db Side: DbProjections, Filtering & Sorting
            .AddMongoDbPagingProviders()
            .AddMongoDbProjections()
            .AddMongoDbFiltering()
            .AddMongoDbSorting()
            ;

            return services;
        }
    }
}