using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Stubs
{
    public class ConfiguratorStubFileRepository // : IConfiguratorRepository
    {
        public IDictionary<SkuGroup, IDictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>> GetSkuSet()
        {
            var contentRootPath = AppContext.BaseDirectory;
                //@"C:\Users\Dell\RiderProjects\ozon-edu\OzonEdu.MerchandiseService\src\OzonEdu.MerchApi.Infrastructure"; //AppContext.BaseDirectory;
            
            string csvSkuOptions = Path.Combine(contentRootPath, "Setup", "skuoptions.csv");

            int id = 1;
            var options = File.ReadAllLines(csvSkuOptions)
                .Skip(1) // skip header column
                .Distinct()
                .Select(s => s.Split(';'))
                .ToList();
            
            IDictionary<SkuGroup, ISet<Tuple<Sku, Tuple<SkuOption, SkuOptionValue>>>> tempSet =
                new Dictionary<SkuGroup, ISet<Tuple<Sku, Tuple<SkuOption, SkuOptionValue>>>>();

            foreach (var option in options)
            {
                var skuGroup = new SkuGroup(option[0]);
                var sku = new Sku(long.Parse(option[1]));
                //var skuOption = new SkuOption(option[2]);
                var skuOptionVal = new SkuOptionValue(option[3]);

                ISet<Tuple<Sku, Tuple<SkuOption, SkuOptionValue>>> skuOptions = null;

                if (tempSet.ContainsKey(skuGroup))
                {
                    skuOptions = tempSet[skuGroup];
                }
                else
                {
                    skuOptions = new HashSet<Tuple<Sku, Tuple<SkuOption, SkuOptionValue>>>();
                    tempSet[skuGroup] = skuOptions;
                }

                //skuOptions.Add(Tuple.Create(sku, Tuple.Create(skuOption, skuOptionVal)));

            }
            
            IDictionary<SkuGroup, IDictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>> skuSet = new Dictionary<SkuGroup, IDictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>>();

            foreach (var tempOpt in tempSet)
            {
                var skuGr = tempOpt.Key;
                
                IDictionary<Sku, ISet<Tuple<SkuOption, SkuOptionValue>>> tempDict =
                    new Dictionary<Sku, ISet<Tuple<SkuOption, SkuOptionValue>>>();
                
                foreach (var oTuple in tempOpt.Value)
                {
                    var sku = oTuple.Item1;
                    var opt = oTuple.Item2;
                    ISet<Tuple<SkuOption, SkuOptionValue>> tSet = null;
                    
                    if (tempDict.ContainsKey(sku))
                    {
                        tSet = tempDict[sku];
                    }
                    else
                    {
                        tSet = new HashSet<Tuple<SkuOption, SkuOptionValue>>();
                        tempDict[sku] = tSet;
                    }

                    tSet.Add(opt);
                }

                IDictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku> rDict =
                    new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>();

                foreach (var skuOpt in tempDict)
                {
                    rDict[skuOpt.Value] = skuOpt.Key;
                }

                skuSet[skuGr] = rDict;
            }
            
            return skuSet;
        }

        public IDictionary<MerchType, ISet<Tuple<SkuGroup, Quantity>>> GetMerchTemplates()
        {
            var contentRootPath =AppContext.BaseDirectory;
            //@"C:\Users\Dell\RiderProjects\ozon-edu\OzonEdu.MerchandiseService\src\OzonEdu.MerchApi.Infrastructure"; 
            
            string csvMerchTemplates = Path.Combine(contentRootPath, "Setup", "merchtemplates.csv");

            int id = 1;
            var templList = File.ReadAllLines(csvMerchTemplates)
                .Skip(1) // skip header column
                .Distinct()
                .Select(s => s.Split(';'))
                .ToList();

            IDictionary<MerchType, ISet<Tuple<SkuGroup, Quantity>>> merchTemplates = new Dictionary<MerchType, ISet<Tuple<SkuGroup, Quantity>>>();
            
            foreach (var templ in templList)
            {
                var tuple = Tuple.Create(new SkuGroup(templ[1]), new Quantity(int.Parse(templ[2])));
                var merchType = MerchType.FromValue<MerchType>(int.Parse(templ[0]));

                ISet<Tuple<SkuGroup, Quantity>> merchSet = null;
                
                if (merchTemplates.ContainsKey(merchType))
                {
                    merchSet = merchTemplates[merchType];
                }
                else
                {
                    merchSet = new HashSet<Tuple<SkuGroup, Quantity>>();
                    merchTemplates[merchType] = merchSet;
                }

                merchSet.Add(tuple);
            }

            return merchTemplates;
        }
    }
}