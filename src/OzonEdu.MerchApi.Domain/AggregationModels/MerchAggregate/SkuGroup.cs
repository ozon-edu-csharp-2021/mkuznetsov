using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public class SkuGroup : ValueObject
    {
        public string Value { get; }
        public SkuOption DefaultOption { get; }

        public SkuGroup(string value, SkuOption defaultOption)
        {
            Value = value;
            DefaultOption = defaultOption;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return DefaultOption;
        }
    }
}