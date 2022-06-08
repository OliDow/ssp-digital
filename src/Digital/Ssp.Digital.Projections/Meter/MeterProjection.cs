using HotChocolate;
using Ssp.Common.Data.Projections;

namespace Ssp.Digital.Projections.Meter;

public class MeterProjection : IProjection
{
    public string Id { get; set; } = string.Empty;

    [GraphQLDescription("MeterSerialNumber")]
    public string MeterSerialNumber { get; set; } = string.Empty;

    [GraphQLDescription("An enum")]
    public string AccountNumber { get; set; } = string.Empty;

    [GraphQLDescription("FuelType description")]
    public string FuelType { get; set; } = string.Empty;

    [GraphQLDescription("SiteAddress desc")]
    public string SiteAddress { get; set; } = string.Empty;

    public string MeterPointNumber { get; set; } = string.Empty;
    public string MeterType { get; set; } = string.Empty;

    // Unknown
    public string BillingDueDate { get; set; } = string.Empty;
    public string AdminSystem { get; set; } = string.Empty;

    public List<MeterRate> Rates { get; set; } = new();

    public class MeterRate
    {
        public string RateType { get; set; } = string.Empty;
        public string MeterRateReadingDigits { get; set; } = string.Empty;

        // this can contain a max of 2 (latest actual and latest estimate)
        public List<MeterRateReading> MeterRateReadings { get; set; } = new List<MeterRateReading>();
    }

    public class MeterRateReading
    {
        public string RateReading { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public string ReadingType { get; set; } = string.Empty;
        public DateTime? LastSubmittedDate { get; set; }
    }
}