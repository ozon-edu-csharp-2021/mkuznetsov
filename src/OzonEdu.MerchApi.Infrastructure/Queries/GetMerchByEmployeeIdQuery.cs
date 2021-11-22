using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchApi.Infrastructure.HttpModels;

namespace OzonEdu.MerchApi.Infrastructure.Queries
{
    public class GetMerchByEmployeeIdQuery : IRequest<IEnumerable<MerchInfo>>
    {
        public long EmployeeId { get; init; }
    }
}