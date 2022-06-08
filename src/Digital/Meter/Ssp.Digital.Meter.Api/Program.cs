using Ssp.Common.Data.Extensions;
using Ssp.Common.Extensions;
using Ssp.Digital.Meter.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add MongoDB
builder.Services.AddMongo();

// Repositories
builder.Services.AddMeterServiceCollections();

// GraphQL
builder.Services.AddGraphQlExtension(builder.Configuration);

// CQRS Command provider
builder.Services.AddCqrs();

// Cors Security
builder.Services.AddCorsExtension();

// Application Insights
builder.Services.AddApplicationInsights(builder.Configuration);

// Health Checks
builder.Services.AddHealthCheckExtension();

var app = builder.Build();

app.MapGraphQL();
app.UseGraphQLVoyager();
// app.UseAuthentication();

app.Run();