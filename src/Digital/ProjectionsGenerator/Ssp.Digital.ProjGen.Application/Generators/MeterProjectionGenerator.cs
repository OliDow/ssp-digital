using Ssp.Common;
using Ssp.Common.Data.Projections;
using Ssp.Digital.Projections.Meter;
using Ssp.EP.Events.Source;

namespace Ssp.Digital.ProjGen.Application.Generators;

public class MeterProjectionGenerator : ProjectionGenerator
{
    public MeterProjectionGenerator()
    {
        UpdateEvent = new List<Type>
        {
            typeof(Meter),
            typeof(MeteringPoint),
            typeof(MeteringPointDeliveredService),
            typeof(MeteringPointMeter),
            typeof(Meter),
            typeof(MeterReadingSubmitted)
        };
    }

    protected override ICollection<IProjection> UpdateProjections(IEvent @event, IReadOnlyCollection<IProjection> projections)
    {
        var meterProjection = projections.OfType<MeterProjection>().SingleOrDefault() ?? new MeterProjection
        {
            Id = Guid.NewGuid().ToString()
        };

        switch (@event)
        {
            case Meter meterCreated:
                meterProjection.MeterSerialNumber = meterCreated.SerialNumber;
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