using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.Contracts;

namespace OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> FindByIdAsync(EmployeeId id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Employee>> FindAll(CancellationToken cancellationToken = default);
    }
}