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
            skuSet[new SkuGroup("pen", new SkuOption("small"))] = new Dictionary<SkuOption,Sku>()
            {
                {
                    new SkuOption("small"),
                    new Sku(1)
                },
                {
                    new SkuOption("big"),
                    new Sku(2)
                },
            };
            skuSet[new SkuGroup("cup", new SkuOption("white"))] = new Dictionary<SkuOption, Sku>()
            {
                {
                    new SkuOption("white"),
                    new Sku(11)
                },
                {
                    new SkuOption("black"),
                    new Sku(12)
                },
                {
                    new SkuOption("green"),
                    new Sku(11)
                },
                {
                    new SkuOption("red"),
                    new Sku(12)
                },
            };
            skuSet[new SkuGroup("t-shirt", new SkuOption("m"))] = new Dictionary<SkuOption, Sku>()
            {
                {
                    new SkuOption("s"),
                    new Sku(101)
                },
                {
                    new SkuOption("m"),
                    new Sku(101)
                },
                {
                    new SkuOption("l"),
                    new Sku(101)
                },
            };
            skuSet[new SkuGroup("hoodie", new SkuOption("m"))] = new Dictionary<SkuOption, Sku>()
            {
                {
                    new SkuOption("s"),
                    new Sku(101)
                },
                {
                    new SkuOption("m"),
                    new Sku(101)
                },
                {
                    new SkuOption("l"),
                    new Sku(101)
                },
            };
            skuSet[new SkuGroup("earplug", new SkuOption("small"))] = new Dictionary<SkuOption, Sku>()
            {
                {
                    new SkuOption("small"),
                    new Sku(1)
                },
                {
                    new SkuOption("big"),
                    new Sku(2)
                },
            };
            skuSet[new SkuGroup("mouthguard", new SkuOption("small"))] = new Dictionary<SkuOption, Sku>()
            {
                {
                    new SkuOption("small"),
                    new Sku(1)
                },
                {
                    new SkuOption("big"),
                    new Sku(2)
                },
            };
            skuSet[new SkuGroup("car", new SkuOption("subaru impreza"))] = new Dictionary<SkuOption, Sku>()
            {
                {
                    new SkuOption("toyota camry"),
                    new Sku(1)
                },
                {
                    new SkuOption("subaru impreza"),
                    new Sku(2)
                },
                {
                    new SkuOption("suzuki escudo"),
                    new Sku(1)
                },
            };

            return skuSet;
        }
       
        public IDictionary<MerchType, IDictionary<SkuGroup, Quantity>> GetMerchTemplates()
        {
            IDictionary<MerchType, IDictionary<SkuGroup, Quantity>> merchTemplates;
            
            merchTemplates = new Dictionary<MerchType, IDictionary<SkuGroup, Quantity>>();
            merchTemplates[MerchType.WelcomePack] = new Dictionary<SkuGroup, Quantity>
            {
                { new SkuGroup("pen", new SkuOption("big")), new Quantity(2)},
            };
            merchTemplates[MerchType.VeteranPack] = new Dictionary<SkuGroup, Quantity>
            {
                { new SkuGroup("car", new SkuOption("subaru impreza")), new Quantity(1)},
            };
            merchTemplates[MerchType.ProbationPeriodEndingPack] = new Dictionary<SkuGroup, Quantity>
            {
                { new SkuGroup("cup", new SkuOption("white")), new Quantity(1)},
                { new SkuGroup("t-shirt", new SkuOption("m")), new Quantity(1)},
            };
            merchTemplates[MerchType.ConferenceListenerPack] = new Dictionary<SkuGroup, Quantity>
            {
                { new SkuGroup("hoodie", new SkuOption("m")), new Quantity(1)},
                { new SkuGroup("mouthguard", new SkuOption("small")), new Quantity(1)}
            };
            merchTemplates[MerchType.ConferenceSpeakerPack] = new Dictionary<SkuGroup, Quantity>
            {
                {new SkuGroup("hoodie", new SkuOption("m")), new Quantity(1)},
                {new SkuGroup("earplug", new SkuOption("small")), new Quantity(2)}
            };

            return merchTemplates;
        }
    }
}