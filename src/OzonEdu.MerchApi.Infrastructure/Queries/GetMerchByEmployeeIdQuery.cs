using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Queries
{
    public class GetMerchByEmployeeIdQuery : IRequest<IEnumerable<Merch>>
    {
        public long EmployeeId { get; init; }
    }
}