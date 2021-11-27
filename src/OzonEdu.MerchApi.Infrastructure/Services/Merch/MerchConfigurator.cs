using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Services
{
    public class MerchConfigurator : IMerchConfigurator
    {
        private readonly IConfiguratorRepository _configuratorRepository;
        private IDictionary<SkuGroup, IDictionary<SkuOption, Sku>> SkuSelector { get; set; }
        private IDictionary<MerchType, IDictionary<SkuGroup, Quantity>> MerchTemplates { get; set; }

        public MerchConfigurator(IConfiguratorRepository configuratorRepository)
        {
            _configuratorRepository = configuratorRepository;
        }
        
        public async Task<Dictionary<Sku, Quantity>> Configure(MerchType merchType, ISet<SkuOption> options, CancellationToken cancellationToken = default)
        {
            SkuSelector = await _configuratorRepository.GetSkuSet(cancellationToken);

            MerchTemplates = await _configuratorRepository.GetMerchTemplates(cancellationToken);
            
            var templSet = MerchTemplates[merchType];

            Dictionary<Sku, Quantity> result = new Dictionary<Sku, Quantity>();

            foreach (var mi in templSet)
            {
                var skuGroup = mi.Key;
                var quantity = mi.Value;

                Sku sku = null;

                var keys = new HashSet<SkuOption>(SkuSelector[skuGroup].Keys);

                var intersection = options.Intersect(keys).ToArray();

                if (intersection.Length == 1)
                {
                    var opt = intersection[0];

                    sku = SkuSelector[skuGroup][opt];
                }
                else if (intersection.Length == 0)
                {
                    sku = SkuSelector[skuGroup][skuGroup.DefaultOption];
                }
                else
                {
                    throw new ApplicationException("Not found SKU");
                }

                if (sku != null)
                {
                    result[sku] = quantity;
                }
            }

            return result;
        }
    }
}