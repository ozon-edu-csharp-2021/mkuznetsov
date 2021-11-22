using System;
using System.Collections.Generic;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public interface IMerchConfigurator
    {
        public Dictionary<Sku, Quantity> Configure(MerchType merchType, ISet<SkuOption> options);
    }
}