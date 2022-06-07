using Ssp.Common.Messaging;
using Ssp.Common.Messaging.Projections;
using Ssp.Digital.Projections;
using Ssp.EP.Events.Source;

namespace Ssp.Digital.ProjGen.Application.Generators;

public class MeterProjectionGenerator : IProjectionGenerator
{
    public List<Type> UpdateEvent { get; } = new() { typeof(MeterCreated), typeof(MeterReadingSubmitted) };

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
            case MeterCreated meterCreated:
                meterProjection.MeterSerialNumber = meterCreated.MeterSerialNumber;
                meterProjection.FuelType = meterCreated.FuelType;
                meterProjection.SiteAddress = meterCreated.MeterSerialNumber;
                meterProjection.MeterPointNumber = meterCreated.MeterPointNumber;
                meterProjection.MeterType = meterCreated.MeterType;
                break;
            case MeterReadingSubmitted meterReadingSubmitted:
                // demo purposes only
                var rate = meterProjection.Rates.Single(s => s.RateType == meterReadingSubmitted.RateType);
                var reading = rate.MeterRateReadings.Single(s => s.ReadingType == meterReadingSubmitted.ReadingType);
                reading.RateReading = meterReadingSubmitted.Rate;
                reading.Date = meterReadingSubmitted.SubmissionDate;
                break;
        }

        return new List<IProjection> { meterProjection };
    }
}