using HotChocolate.Types.Pagination;

namespace Ssp.Digital.Meter.Api.Extensions;

public class GraphQlSettings
{
    public PagingOptions Paging { get; set; } = default!;
}