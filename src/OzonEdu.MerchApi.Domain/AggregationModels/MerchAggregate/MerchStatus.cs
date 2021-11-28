using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public class MerchStatus : Enumeration
    {
        public static MerchStatus Ready = new(10, nameof(Ready));
        public static MerchStatus Waiting = new(20, nameof(Waiting));
        public static MerchStatus Unavailable = new(30, nameof(Unavailable));
        
        public MerchStatus(int id, string name) : base(id, name)
        {
        }
    }
}