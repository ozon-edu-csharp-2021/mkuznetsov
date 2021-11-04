using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.Contracts;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public interface IMerchRepository : IRepository<Merch>
    {
        Task<IEnumerable<Merch>> FindByEmployeeIdAsync(EmployeeId employeeId, CancellationToken cancellationToken = default);

        Task<IEnumerable<Merch>> FindAll(CancellationToken cancellationToken = default);

        Task<MerchStatus> Order(MerchType merchType, EmployeeId employeeId, CancellationToken cancellationToken = default);
    }
}