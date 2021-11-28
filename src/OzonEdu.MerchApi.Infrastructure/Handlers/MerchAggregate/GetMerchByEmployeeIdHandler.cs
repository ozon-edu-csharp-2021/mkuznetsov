using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchApi.Infrastructure.HttpModels;
using OzonEdu.MerchApi.Infrastructure.Queries;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.MerchAggregate
{
    public class GetMerchByEmployeeIdHandler : GetMerchHandler, IRequestHandler<GetMerchByEmployeeIdQuery, IEnumerable<MerchInfo>>
    {
        private readonly IMerchRepository _merchRepository;

        public GetMerchByEmployeeIdHandler(IMerchRepository merchRepository) =>
            _merchRepository = merchRepository;

        public async Task<IEnumerable<MerchInfo>> Handle(GetMerchByEmployeeIdQuery request,
            CancellationToken cancellationToken)
        {
            var merchList =
                await _merchRepository.FindByEmployeeIdAsync(request.EmployeeId, cancellationToken);

            return PrepareResponse(merchList);
        }

        // private IEnumerable<MerchInfo> PrepareResponse(IEnumerable<Merch> merchList) =>
        //     merchList.Select(m => ConvertMerch(m)).ToList();
        

        // private MerchInfo ConvertMerch(Merch merch)
        // {
        //     var skus = merch.SkuSet
        //         ?.ToDictionary(t => t.Key.Value, t => t.Value.Value );
        //
        //     return new MerchInfo
        //     {
        //         Id = merch.Id,
        //         MerchType = (MType) merch.MerchType.Id,
        //         EmployeeId = merch.EmployeeId,
        //         IssueDate = merch.IssueDate.Value,
        //         MerchStatus = (MerchStatus) merch.MerchStatus.Id,
        //         SkuSet = skus
        //     };
        // }
    }
}