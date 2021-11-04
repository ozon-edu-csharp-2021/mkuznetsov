using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Commands
{
    public class OrderMerchCommand : IRequest<MerchStatus>
    {
        public MerchType MerchType { get; init; }
        
        public EmployeeId EmployeeId { get; init; }
    }
}