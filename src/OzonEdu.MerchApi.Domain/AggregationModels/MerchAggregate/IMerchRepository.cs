using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.Contracts;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public interface IMerchRepository : IRepository<Merch>
    {
        Task<IEnumerable<Merch>> FindByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);

        Task<bool> Insert(Merch merch, CancellationToken cancellationToken = default);

        Task<IEnumerable<Merch>> FindByStatusAndSku(MerchStatus merchStatus, IEnumerable<Sku> skus, CancellationToken cancellationToken = default);

        Task<bool> UpdateStatus(Merch merch, CancellationToken cancellationToken = default);
    }
}