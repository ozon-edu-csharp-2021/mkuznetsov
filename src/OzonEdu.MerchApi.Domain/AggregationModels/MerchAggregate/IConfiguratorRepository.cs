using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public interface IConfiguratorRepository
    {
        public Task<IDictionary<SkuGroup, IDictionary<SkuOption, Sku>>> GetSkuSet(CancellationToken cancellationToken = default);
        
        public Task<IDictionary<MerchType, IDictionary<SkuGroup, Quantity>>> GetMerchTemplates(CancellationToken cancellationToken = default);
    }
}