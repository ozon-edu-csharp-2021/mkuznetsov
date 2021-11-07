﻿using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public class Sku : ValueObject
    {
        public long Value { get; }

        public Sku(long sku)
        {
            Value = sku;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}