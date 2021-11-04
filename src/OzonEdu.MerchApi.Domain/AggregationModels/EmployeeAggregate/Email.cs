using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate
{
    public class Email : ValueObject
    {
        public string Value { get; }

        public Email(string email)
        {
            Value = email;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}