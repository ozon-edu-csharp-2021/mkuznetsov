using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Services
{
    public class MerchFactory
    {
        public void GenerateMerch()
        {
            //SkuOptionValue<Size>

            Dictionary<string, Dictionary<List<Tuple<string, string>>, Sku>> MerchConfigurator;

            var t1 = Tuple.Create("size", "m");
            var t2 = Tuple.Create("size", "s");

            t1.Equals(t2);

        }
    }
}