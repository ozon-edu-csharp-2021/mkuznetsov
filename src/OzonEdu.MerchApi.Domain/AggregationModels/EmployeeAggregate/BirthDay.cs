using System;
using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate
{
    public class BirthDay : ValueObject
    {
        public DateTime Value { get; }

        public BirthDay(DateTime birthDay)
        {
            Value = birthDay;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}