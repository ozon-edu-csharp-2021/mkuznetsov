using System;
using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate
{
    public class HiringDate : ValueObject
    {
        public DateTime Value { get; }

        public HiringDate(DateTime hiringDate)
        {
            Value = hiringDate;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}