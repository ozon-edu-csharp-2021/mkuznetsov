using System;
using System.Collections.Generic;
using System.Linq;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public class MerchConfigurator : IMerchConfigurator
    {
        public Dictionary<SkuGroup, Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>> SkuSelector { get; init; }
        public Dictionary<MerchType, ISet<Tuple<SkuGroup, Quantity>>> MerchTemplates { get; init; }

        public MerchConfigurator()
        {
            SkuSelector = new Dictionary<SkuGroup, Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>>();
            SkuSelector[new SkuGroup("pen")] = new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>()
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
            SkuSelector[new SkuGroup("cup")] = new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>()
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
            SkuSelector[new SkuGroup("t-shirt")] = new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>()
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
            SkuSelector[new SkuGroup("hoodie")] = new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>()
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
            SkuSelector[new SkuGroup("earplug")] = new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>()
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
            SkuSelector[new SkuGroup("mouthguard")] = new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>()
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
            SkuSelector[new SkuGroup("car")] = new Dictionary<ISet<Tuple<SkuOption, SkuOptionValue>>, Sku>()
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
            
            MerchTemplates = new Dictionary<MerchType, ISet<Tuple<SkuGroup, Quantity>>>();
            MerchTemplates[MerchType.WelcomePack] = new HashSet<Tuple<SkuGroup, Quantity>>
            {
                Tuple.Create(new SkuGroup("pen"), new Quantity(2))
            };
            MerchTemplates[MerchType.VeteranPack] = new HashSet<Tuple<SkuGroup, Quantity>>
            {
                Tuple.Create(new SkuGroup("car"), new Quantity(1))
            };
            MerchTemplates[MerchType.ProbationPeriodEndingPack] = new HashSet<Tuple<SkuGroup, Quantity>>
            {
                Tuple.Create(new SkuGroup("cup"), new Quantity(1)),
                Tuple.Create(new SkuGroup("t-shirt"), new Quantity(1))
            };
            MerchTemplates[MerchType.ConferenceListenerPack] = new HashSet<Tuple<SkuGroup, Quantity>>
            {
                Tuple.Create(new SkuGroup("hoodie"), new Quantity(1)),
                Tuple.Create(new SkuGroup("mouthguard"), new Quantity(1))
            };
            MerchTemplates[MerchType.ConferenceSpeakerPack] = new HashSet<Tuple<SkuGroup, Quantity>>
            {
                Tuple.Create(new SkuGroup("hoodie"), new Quantity(1)),
                Tuple.Create(new SkuGroup("earplug"), new Quantity(2))
            };
        }
        
        public Dictionary<long, Quantity> Configure(MerchType merchType, ISet<Tuple<SkuOption, SkuOptionValue>> options)
        {
            var templSet = MerchTemplates[merchType];

            //ISet<Tuple<Sku, Quantity>> result = new HashSet<Tuple<Sku, Quantity>>();
            Dictionary<long, Quantity> result = new Dictionary<long, Quantity>();

            foreach (var merchItem in templSet)
            {
                var (skuGroup, quantity) = merchItem.ToValueTuple();
                var sku = SkuSelector[skuGroup]
                    .Where(opt => opt.Key.IsSubsetOf(options))
                    .Select(opt => opt.Value)
                    .First();

                //result.Add(Tuple.Create<Sku, Quantity>(sku, quantity));
                result[sku.Value] = quantity;
            }

            return result;
        }
    }
}