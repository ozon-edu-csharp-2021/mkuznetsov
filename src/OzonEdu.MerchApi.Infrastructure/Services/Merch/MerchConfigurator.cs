using System;
using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Services
{
    public class MerchConfigurator : IMerchConfigurator
    {
        private readonly IConfiguratorRepository _configuratorRepository;
        public IDictionary<SkuGroup, IDictionary<SkuOption, Sku>> SkuSelector { get; init; }
        public IDictionary<MerchType, ISet<Tuple<SkuGroup, Quantity>>> MerchTemplates { get; init; }

        public MerchConfigurator(IConfiguratorRepository configuratorRepository)
        {
            _configuratorRepository = configuratorRepository;

            SkuSelector = _configuratorRepository.GetSkuSet();

            MerchTemplates = _configuratorRepository.GetMerchTemplates();
        }
        
        public Dictionary<Sku, Quantity> Configure(MerchType merchType, ISet<SkuOption> options)
        {
            var templSet = MerchTemplates[merchType];

            Dictionary<Sku, Quantity> result = new Dictionary<Sku, Quantity>();

            foreach (var merchItem in templSet)
            {
                var (skuGroup, quantity) = merchItem.ToValueTuple();
                var sku = SkuSelector[skuGroup]
                    .Where(opt => options.Contains(opt.Key))
                    .Select(opt => opt.Value)
                    .First();

                result[sku] = quantity;
            }

            return result;
        }
    }
}