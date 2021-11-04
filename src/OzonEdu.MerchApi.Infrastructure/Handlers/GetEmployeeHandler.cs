using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Infrastructure.Commands;

namespace OzonEdu.MerchApi.Infrastructure.Handlers
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeRequest, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<Employee> Handle(GetEmployeeRequest request, CancellationToken cancellationToken) =>
            _employeeRepository.FindByIdAsync(new EmployeeId(request.EmployeeId), cancellationToken);
    }
}