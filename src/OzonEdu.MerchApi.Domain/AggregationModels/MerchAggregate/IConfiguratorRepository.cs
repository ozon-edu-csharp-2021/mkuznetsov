using System;
using System.Collections.Generic;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public interface IConfiguratorRepository
    {
        public IDictionary<SkuGroup, IDictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>> GetSkuSet();
        
        public IDictionary<MerchType, ISet<Tuple<SkuGroup, Quantity>>> GetMerchTemplates();
    }
}