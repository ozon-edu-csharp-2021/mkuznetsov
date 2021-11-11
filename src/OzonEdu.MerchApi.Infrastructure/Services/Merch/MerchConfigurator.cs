using System;
using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Services
{
    public class MerchConfigurator : IMerchConfigurator
    {
        private readonly IConfiguratorRepository _configuratorRepository;
        public IDictionary<SkuGroup, IDictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>> SkuSelector { get; init; }
        public IDictionary<MerchType, ISet<Tuple<SkuGroup, Quantity>>> MerchTemplates { get; init; }

        public MerchConfigurator(IConfiguratorRepository configuratorRepository)
        {
            _configuratorRepository = configuratorRepository;

            SkuSelector = _configuratorRepository.GetSkuSet();

            MerchTemplates = _configuratorRepository.GetMerchTemplates();
        }
        
        public Dictionary<long, Quantity> Configure(MerchType merchType, ISet<Tuple<SkuOption, SkuOptionValue>> options)
        {
            var templSet = MerchTemplates[merchType];

            //ISet<Tuple<Sku, Quantity>> result = new HashSet<Tuple<Sku, Quantity>>();
            Dictionary<long, Quantity> result = new Dictionary<long, Quantity>();

            foreach (var merchItem in templSet)
            {
                var (skuGroup, quantity) = merchItem.ToValueTuple();
                var sku = SkuSelector[skuGroup]
                    .Where(opt => opt.Key.IsSubsetOf(options))
                    .Select(opt => opt.Value)
                    .First();

                result[sku.Value] = quantity;
            }

            return result;
        }
    }
}