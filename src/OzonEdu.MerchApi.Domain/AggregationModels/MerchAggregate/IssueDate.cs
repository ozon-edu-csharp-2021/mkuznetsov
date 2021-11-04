using System;
using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public class IssueDate : ValueObject
    {
        public DateTime Value { get; }

        public IssueDate(DateTime issueDate)
        {
            Value = issueDate;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}