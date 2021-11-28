using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Commands
{
    public class GetEmployeeRequest : IRequest<Employee>
    {
        public long EmployeeId { get; init; }
    }
}