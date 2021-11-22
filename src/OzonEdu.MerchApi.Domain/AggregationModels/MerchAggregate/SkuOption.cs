using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public class SkuOption : ValueObject
    {
        public long Value { get; }
        public string Description { get; }

        public SkuOption(long value)
        {
            Value = value;
            Description = "Not specified";
        }
        
        public SkuOption(long value, string description)
        {
            Value = value;
            Description = description;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Description;
        }
    }
}