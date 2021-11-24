using System.Diagnostics.CodeAnalysis;

namespace OzonEdu.MerchApi.Infrastructure.Repositories.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class MerchSkuDb
    {
        public long MerchId { get; set; }
        
        public long SkuId { get; set; }
        
        public int Quantity { get; set; }
    }
}