using System.Diagnostics.CodeAnalysis;

namespace OzonEdu.MerchApi.Infrastructure.Repositories.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class MerchTemplateDb
    {
        public long MerchTypeId { get; set; }
        
        public string SkuGroupName { get; set; }
        
        public string SkuGroupDefault { get; set; }
        
        public int Quantity { get; set; }
    }
}