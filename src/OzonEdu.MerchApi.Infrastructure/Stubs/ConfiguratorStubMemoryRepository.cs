using System;
using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Stubs
{
    public class ConfiguratorStubMemoryRepository : IConfiguratorRepository
    {
        
        public IDictionary<SkuGroup, IDictionary<SkuOption, Sku>> GetSkuSet()
        {
            IDictionary<SkuGroup, IDictionary<SkuOption, Sku>> skuSet;
            
            skuSet = new Dictionary<SkuGroup, IDictionary<SkuOption, Sku>>();
            skuSet[new SkuGroup("pen")] = new Dictionary<SkuOption,Sku>()
            {
                {
                    new SkuOption(1, "small pen"),
                    new Sku(1)
                },
                {
                    new SkuOption(2, "big pen"),
                    new Sku(2)
                },
            };
            skuSet[new SkuGroup("cup")] = new Dictionary<SkuOption, Sku>()
            {
                {
                    new SkuOption(3, "white cup"),
                    new Sku(11)
                },
                {
                    new SkuOption(4, "black cup"),
                    new Sku(12)
                },
                {
                    new SkuOption(5, "green cup"),
                    new Sku(11)
                },
                {
                    new SkuOption(6, "red cup"),
                    new Sku(12)
                },
            };
            skuSet[new SkuGroup("t-shirt")] = new Dictionary<SkuOption, Sku>()
            {
                {
                    new SkuOption(7, "s t-shirt"),
                    new Sku(101)
                },
                {
                    new SkuOption(8, "m t-shirt"),
                    new Sku(101)
                },
                {
                    new SkuOption(9, "l t-shirt"),
                    new Sku(101)
                },
            };
            skuSet[new SkuGroup("hoodie")] = new Dictionary<SkuOption, Sku>()
            {
                {
                    new SkuOption(10, "s hoodie"),
                    new Sku(101)
                },
                {
                    new SkuOption(11, "m hoodie"),
                    new Sku(101)
                },
                {
                    new SkuOption(12, "l hoodie"),
                    new Sku(101)
                },
            };
            skuSet[new SkuGroup("earplug")] = new Dictionary<SkuOption, Sku>()
            {
                {
                    new SkuOption(13, "small earplug"),
                    new Sku(1)
                },
                {
                    new SkuOption(14, "big earplug"),
                    new Sku(2)
                },
            };
            skuSet[new SkuGroup("mouthguard")] = new Dictionary<SkuOption, Sku>()
            {
                {
                    new SkuOption(15, "small mouthguard"),
                    new Sku(1)
                },
                {
                    new SkuOption(18, "big mouthguard"),
                    new Sku(2)
                },
            };
            skuSet[new SkuGroup("car")] = new Dictionary<SkuOption, Sku>()
            {
                {
                    new SkuOption(17, "toyota camry"),
                    new Sku(1)
                },
                {
                    new SkuOption(18, "subaru impreza"),
                    new Sku(2)
                },
                {
                    new SkuOption(19, "suzuki escudo"),
                    new Sku(1)
                },
            };

            return skuSet;
        }

        public IDictionary<MerchType, ISet<Tuple<SkuGroup, Quantity>>> GetMerchTemplates()
        {
            IDictionary<MerchType, ISet<Tuple<SkuGroup, Quantity>>> merchTemplates;
            
            merchTemplates = new Dictionary<MerchType, ISet<Tuple<SkuGroup, Quantity>>>();
            merchTemplates[MerchType.WelcomePack] = new HashSet<Tuple<SkuGroup, Quantity>>
            {
                Tuple.Create(new SkuGroup("pen"), new Quantity(2))
            };
            merchTemplates[MerchType.VeteranPack] = new HashSet<Tuple<SkuGroup, Quantity>>
            {
                Tuple.Create(new SkuGroup("car"), new Quantity(1))
            };
            merchTemplates[MerchType.ProbationPeriodEndingPack] = new HashSet<Tuple<SkuGroup, Quantity>>
            {
                Tuple.Create(new SkuGroup("cup"), new Quantity(1)),
                Tuple.Create(new SkuGroup("t-shirt"), new Quantity(1))
            };
            merchTemplates[MerchType.ConferenceListenerPack] = new HashSet<Tuple<SkuGroup, Quantity>>
            {
                Tuple.Create(new SkuGroup("hoodie"), new Quantity(1)),
                Tuple.Create(new SkuGroup("mouthguard"), new Quantity(1))
            };
            merchTemplates[MerchType.ConferenceSpeakerPack] = new HashSet<Tuple<SkuGroup, Quantity>>
            {
                Tuple.Create(new SkuGroup("hoodie"), new Quantity(1)),
                Tuple.Create(new SkuGroup("earplug"), new Quantity(2))
            };

            return merchTemplates;
        }
    }
}