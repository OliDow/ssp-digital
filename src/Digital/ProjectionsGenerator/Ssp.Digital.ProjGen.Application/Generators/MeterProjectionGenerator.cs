using Ssp.Common.Messaging;
using Ssp.Common.Messaging.Projections;
using Ssp.Digital.Projections;
using Ssp.EP.Events.Source;

namespace Ssp.Digital.ProjGen.Application.Generators;

public class MeterProjectionGenerator : IProjectionGenerator
{
    public List<Type> UpdateEvent { get; set; } = new() { typeof(MeterCreated), typeof(MeterReadingSubmitted) };

    public ICollection<IProjection> Generate(IEvent @event, IReadOnlyCollection<IProjection> projections)
    {
        // todo Abstract boiler plate code
        var eventType = @event.GetType();
        if (!UpdateEvent.Contains(eventType))
        {
            throw new ArgumentException($"Supplied Event was not in UpdateEvent List");
        }

        var meterProjection = projections.OfType<MeterProjection>().SingleOrDefault() ?? new MeterProjection();

        switch (@event)
        {
            case MeterCreated createMeter:
                meterProjection.MeterSerialNumber = createMeter.MeterSerialNumber;
                meterProjection.FuelType = createMeter.FuelType;
                meterProjection.SiteAddress = createMeter.MeterSerialNumber;
                meterProjection.MeterPointNumber = createMeter.MeterPointNumber;
                meterProjection.MeterType = createMeter.MeterType;
                break;
            case MeterReadingSubmitted meterReadingSubmitted:
                meterProjection.Rate.LatestMeterRateReading.RateReading = meterReadingSubmitted.Rate;
                meterProjection.Rate.LatestMeterRateReading.Date = meterReadingSubmitted.SubmissionDate;
                break;
        }

        return new List<IProjection> { meterProjection };
    }
}