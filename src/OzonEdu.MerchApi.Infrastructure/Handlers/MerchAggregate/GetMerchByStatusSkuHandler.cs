using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchApi.Infrastructure.HttpModels;
using OzonEdu.MerchApi.Infrastructure.Queries;
using MerchStatus = OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate.MerchStatus;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.MerchAggregate
{
    public class GetMerchByStatusSkuHandler : GetMerchHandler, IRequestHandler<GetMerchByStatusSkuQuery, IEnumerable<MerchInfo>>, IRequest<IEnumerable<MerchInfo>>
    {
        private readonly IMerchRepository _merchRepository;

        public GetMerchByStatusSkuHandler(IMerchRepository merchRepository) =>
            _merchRepository = merchRepository;

        public async Task<IEnumerable<MerchInfo>> Handle(GetMerchByStatusSkuQuery request, CancellationToken cancellationToken)
        {
            var skuList = request.Skus.Select(s => new Sku(s)).ToList();
            
            var merchList =
                await _merchRepository.FindByStatusAndSku(MerchStatus.FromValue<MerchStatus>((int)request.MerchStatus), skuList, cancellationToken);
            
            return PrepareResponse(merchList);
        }
    }
}