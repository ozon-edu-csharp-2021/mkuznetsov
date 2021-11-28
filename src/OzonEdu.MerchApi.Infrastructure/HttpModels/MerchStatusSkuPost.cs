using System.Collections.Generic;

namespace OzonEdu.MerchApi.Infrastructure.HttpModels
{
    public class MerchStatusSkuPost
    {
        public MerchStatus MerchStatus { get; set; }

        public IEnumerable<long> Skus { get; set; }
    }
}