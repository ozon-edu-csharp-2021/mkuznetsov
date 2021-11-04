using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate
{
    public class EmployeeId : ValueObject
    {
        public long Value { get; }

        public EmployeeId(long id)
        {
            Value = id;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}