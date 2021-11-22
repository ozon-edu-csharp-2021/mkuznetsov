using System;
using System.Collections.Generic;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public interface IConfiguratorRepository
    {
        public IDictionary<SkuGroup, IDictionary<SkuOption, Sku>> GetSkuSet();
        
        public IDictionary<MerchType, ISet<Tuple<SkuGroup, Quantity>>> GetMerchTemplates();
    }
}