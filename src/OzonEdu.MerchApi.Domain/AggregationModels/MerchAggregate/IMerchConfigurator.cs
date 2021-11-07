using System;
using System.Collections.Generic;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public interface IMerchConfigurator
    {
        public Dictionary<long, Quantity> Configure(MerchType merchType, ISet<Tuple<SkuOption, SkuOptionValue>> options);
    }
}