using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchApi.Infrastructure.HttpModels;

namespace OzonEdu.MerchApi.Infrastructure.Queries
{
    public class GetMerchByStatusSkuQuery : IRequest<IEnumerable<MerchInfo>>
    {
        public MerchStatus MerchStatus { get; set; }

        public IEnumerable<long> Skus { get; set; }
    }
}