using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchApi.Infrastructure.Infrastructure.Interfaces;
using OzonEdu.MerchApi.Infrastructure.Repositories.Models;

namespace OzonEdu.MerchApi.Infrastructure.Repositories.Implementation
{
    public class ConfiguratorRepository : IConfiguratorRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private const int Timeout = 5;

        public ConfiguratorRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IDictionary<SkuGroup, IDictionary<SkuOption, Sku>>> GetSkuSet(CancellationToken cancellationToken = default)
        {
            const string sql = @"
              select t.""name"" SkuGroupName, od.""name"" SkuGroupDefault, o.""name"" SkuOption, s.sku_id SkuID 
                from item_types t
                    join item_type_sku s 
                on t.id = s.item_type_id 
                join item_options od
                    on t.default_option_id = od.id 
                join item_options o
                    on s.option_id = o.id";

            var commandDefinition = new CommandDefinition(
                sql,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var skus = await connection.QueryAsync<SkuSetDb>(commandDefinition);

            var result = new Dictionary<SkuGroup, IDictionary<SkuOption, Sku>>();
            
            foreach (var sku in skus)
            {
                var skuGroup = new SkuGroup(sku.SkuGroupName, new SkuOption(sku.SkuGroupDefault));
                var skuOption = new SkuOption(sku.SkuOption);
                var skuId = new Sku(sku.SkuId);

                if (!result.ContainsKey(skuGroup))
                {
                    result[skuGroup] = new Dictionary<SkuOption, Sku>();
                }

                result[skuGroup][skuOption] = skuId;
            }

            return result;
        }

        public async Task<IDictionary<MerchType, IDictionary<SkuGroup, Quantity>>> GetMerchTemplates(CancellationToken cancellationToken = default)
        {
            const string sql = @"
              select m.merch_type_id MerchTypeId, t.""name"" SkuGroupName, od.""name"" SkuGroupDefault, m.quantity Quantity 
                from merch_template m
                    join item_types t
                on m.item_type_id = t.id
                join item_options od
                    on t.default_option_id = od.id ";

            var commandDefinition = new CommandDefinition(
                sql,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var templates = await connection.QueryAsync<MerchTemplateDb>(commandDefinition);
            
            var result = new Dictionary<MerchType, IDictionary<SkuGroup, Quantity>>();
            
            foreach (var template in templates)
            {
                var merchType = MerchType.FromValue<MerchType>((int)template.MerchTypeId);
                var skuGroup = new SkuGroup(template.SkuGroupName, new SkuOption(template.SkuGroupDefault));
                var quantity = new Quantity(template.Quantity);

                if (!result.ContainsKey(merchType))
                {
                    result[merchType] = new Dictionary<SkuGroup, Quantity>();
                }

                result[merchType][skuGroup] = quantity;
            }

            return result;
        }
    }
}