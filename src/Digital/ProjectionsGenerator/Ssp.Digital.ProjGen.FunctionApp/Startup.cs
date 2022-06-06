using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Ssp.Common.Extensions;
using Ssp.Common.Messaging.Extensions;
using Ssp.Common.Messaging.Messaging;
using Ssp.Digital.ProjGen.Application.Commands;
using Ssp.Digital.ProjGen.Application.Extensions;
using Ssp.Digital.ProjGen.FunctionApp;
using System.Reflection;

#pragma warning disable CS8603

[assembly: FunctionsStartup(typeof(Startup))]

namespace Ssp.Digital.ProjGen.FunctionApp;

public class Startup : FunctionsStartup
{
    private static string ExecutingAssemblyName => Assembly.GetExecutingAssembly().GetName().Name;

    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddTelemetry(ExecutingAssemblyName);
        builder.Services.AddCommonProviders();

        var configuration = builder.GetContext().Configuration;
        builder.Services.AddPocMessaging(configuration);
        builder.Services.AddPocEventHub(configuration);

        builder.Services.AddTransient<IMessageReceiver, MessageReceiver>();

        builder.Services.AddGenerators();
        builder.Services.AddMediatR(typeof(MeterCreatedHandler));
    }
}