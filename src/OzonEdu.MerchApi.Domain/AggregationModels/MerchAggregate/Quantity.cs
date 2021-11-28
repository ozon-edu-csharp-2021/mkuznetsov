using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public class Quantity : ValueObject
    {
        public int Value { get; }

        public Quantity(int value)
        {
            Value = value;
        }   
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}