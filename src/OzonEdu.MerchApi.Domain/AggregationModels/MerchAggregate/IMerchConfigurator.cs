using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public interface IMerchConfigurator
    {
        public Task<Dictionary<Sku, Quantity>> Configure(MerchType merchType, ISet<SkuOption> options, CancellationToken cancellationToken = default);
    }
}