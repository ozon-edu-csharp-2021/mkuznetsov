using System.Diagnostics.CodeAnalysis;

namespace OzonEdu.MerchApi.Infrastructure.Repositories.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class SkuSetDb
    {
        public string SkuGroupName { get; set; }
        
        public string SkuGroupDefault { get; set; }
        
        public string SkuOption { get; set; }
        
        public long SkuId { get; set; }
    }
}