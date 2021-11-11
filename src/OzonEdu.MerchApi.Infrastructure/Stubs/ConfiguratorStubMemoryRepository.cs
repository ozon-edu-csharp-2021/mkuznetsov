using System;
using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Stubs
{
    public class ConfiguratorStubMemoryRepository : IConfiguratorRepository
    {
        
        public IDictionary<SkuGroup, IDictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>> GetSkuSet()
        {
            IDictionary<SkuGroup, IDictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>> skuSet;
            
            skuSet = new Dictionary<SkuGroup, IDictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>>();
            skuSet[new SkuGroup("pen")] = new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>()
            {
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("size"), new SkuOptionValue("big")),
                    },
                    new Sku(1)
                },
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("size"), new SkuOptionValue("small")),
                    },
                    new Sku(2)
                },
            };
            skuSet[new SkuGroup("cup")] = new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>()
            {
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("color"), new SkuOptionValue("white")),
                    },
                    new Sku(11)
                },
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("color"), new SkuOptionValue("black")),
                    },
                    new Sku(12)
                },
            };
            skuSet[new SkuGroup("t-shirt")] = new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>()
            {
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("dresssize"), new SkuOptionValue("s")),
                    },
                    new Sku(101)
                },
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("dresssize"), new SkuOptionValue("m")),
                    },
                    new Sku(102)
                },
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("dresssize"), new SkuOptionValue("l")),
                    },
                    new Sku(103)
                },
            };
            skuSet[new SkuGroup("hoodie")] = new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>()
            {
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("dresssize"), new SkuOptionValue("s")),
                    },
                    new Sku(1001)
                },
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("dresssize"), new SkuOptionValue("m")),
                    },
                    new Sku(1002)
                },
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("dresssize"), new SkuOptionValue("l")),
                    },
                    new Sku(1003)
                },
            };
            skuSet[new SkuGroup("earplug")] = new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>()
            {
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("size"), new SkuOptionValue("big")),
                    },
                    new Sku(10001)
                },
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("size"), new SkuOptionValue("small")),
                    },
                    new Sku(10002)
                },
            };
            skuSet[new SkuGroup("mouthguard")] = new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>()
            {
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("size"), new SkuOptionValue("big")),
                    },
                    new Sku(100001)
                },
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("size"), new SkuOptionValue("small")),
                    },
                    new Sku(100002)
                },
            };
            skuSet[new SkuGroup("car")] = new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>()
            {
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("brand"), new SkuOptionValue("toyota")),
                        Tuple.Create(new SkuOption("model"), new SkuOptionValue("cruiser")),
                    },
                    new Sku(1000001)
                },
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("brand"), new SkuOptionValue("toyota")),
                        Tuple.Create(new SkuOption("model"), new SkuOptionValue("camry")),
                    },
                    new Sku(1000002)
                },
                {
                    new HashSet<Tuple<SkuOption, SkuOptionValue>>()
                    {
                        Tuple.Create(new SkuOption("brand"), new SkuOptionValue("subaru")),
                        Tuple.Create(new SkuOption("model"), new SkuOptionValue("impreza")),
                    },
                    new Sku(1000003)
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