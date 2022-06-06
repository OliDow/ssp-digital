using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Ssp.Common.Messaging.Functions;
using Ssp.Common.Messaging.Functions.Builders;
using Ssp.Common.Messaging.Messaging;
using Ssp.Common.Messaging.Repository;

namespace Ssp.Digital.ProjGen.FunctionApp;

public class PreparedViewGenerator : ServiceBusTriggerBase
{
    public PreparedViewGenerator(IMessageContext messageContext, IErrorMetadataBuilder errorMetadataBuilder,
        IMessageReceiver messageReceiver, IEventSchemaRepository eventSchemaRepository)
        : base(messageContext, errorMetadataBuilder, messageReceiver, eventSchemaRepository) { }

    [FunctionName("PreparedViewGenerator")]
    public Task RunAsync(
        [ServiceBusTrigger("%OutEventTopicName%", "%OutEventSubscriptionName%", Connection = "MessageBusConnectionString")]
        ServiceBusReceivedMessage message, ServiceBusMessageActions messageActions, CancellationToken cancellationToken)
        => ProcessMessageAsync(message, messageActions, cancellationToken);
}