using Ssp.Common.Messaging.Projections;

namespace Ssp.Digital.Projections;

public class MeterProjection : IProjection
{
    public string MeterSerialNumber { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string FuelType { get; set; } = string.Empty;
    public string SiteAddress { get; set; } = string.Empty;
    public string MeterPointNumber { get; set; } = string.Empty;
    public string MeterType { get; set; } = string.Empty;

    // Unknown
    public string BillingDueDate { get; set; } = string.Empty;
    public string MeterRatePreviousReadingValue { get; set; } = string.Empty;
    public string AdminSystem { get; set; } = string.Empty;
    public string LastEstimate { get; set; } = string.Empty;

    public MeterRate Rate { get; set; }

    public class MeterRate
    {
        public string RateType { get; set; } = string.Empty;
        public string MeterRateReadingDigits { get; set; } = string.Empty;

        public LatestMeterRateReading LatestMeterRateReading { get; set; }
    }

    public class LatestMeterRateReading
    {
        public string RateReading { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public string ReadingType { get; set; } = string.Empty;
        public DateTime? LastSubmittedDate { get; set; }
    }
}