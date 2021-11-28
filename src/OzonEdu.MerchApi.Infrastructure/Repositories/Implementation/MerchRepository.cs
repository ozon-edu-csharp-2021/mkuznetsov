using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchApi.Infrastructure.Infrastructure.Interfaces;
using OzonEdu.MerchApi.Infrastructure.Repositories.Models;

namespace OzonEdu.MerchApi.Infrastructure.Repositories.Implementation
{
    public class MerchRepository : IMerchRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private const int Timeout = 5;

        public MerchRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public Task<IEnumerable<Merch>> FindByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                select m.id, m.type_id MerchType, m.merch_status MerchStatus,
                       m.employee_id EmployeeId, m.issue_date IssueDate,
                       s.sku_id SkuId, s.quantity Quantity
                  from merches m
                  left join merch_sku s
                    on m.id = s.merch_id 
                 where m.employee_id = @EmployeeId;";

            var parameters = new
            {
                EmployeeId = employeeId,
            };
            
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);

            return FindMerch(commandDefinition, cancellationToken);
        }

        public Task<IEnumerable<Merch>> FindByStatusAndSku(MerchStatus merchStatus, IEnumerable<Sku> skus, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                select m.id, m.type_id MerchType, m.merch_status MerchStatus,
                       m.employee_id EmployeeId, m.issue_date IssueDate,
                       s.sku_id SkuId, s.quantity Quantity
                  from merches m
                  left join merch_sku s
                    on m.id = s.merch_id 
                 where m.merch_status = @MerchStatus
                   and s.sku_id = ANY(@Skus);";

            var parameters = new
            {
                MerchStatus = merchStatus.Id,
                Skus = skus.Select(s => s.Value).ToArray()
            };
            
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            
            return FindMerch(commandDefinition, cancellationToken);
        }

        private async Task<IEnumerable<Merch>> FindMerch(CommandDefinition commandDefinition, CancellationToken cancellationToken = default)
        {
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var merchLines = await connection.QueryAsync<MerchDb>(commandDefinition);

            var merchDict = new Dictionary<long, Merch>();
            
            foreach (var m in merchLines)
            {
                Merch merch = null;

                if (merchDict.ContainsKey(m.Id))
                {
                    merch = merchDict[m.Id];
                }
                else
                {
                    merch = new Merch(
                        m.Id,
                        MerchType.FromValue<MerchType>((int) m.MerchType),
                        m.EmployeeId,
                        new IssueDate(m.IssueDate),
                        MerchStatus.FromValue<MerchStatus>((int) m.MerchStatus),
                        new Dictionary<Sku, Quantity>()
                    );
                    merchDict[m.Id] = merch;
                }

                var sku = new Sku(m.SkuId);
                var quantity = new Quantity(m.Quantity);

                merch.SkuSet[sku] = quantity;
            }

            var result = merchDict.Select(kv => kv.Value)
                .ToHashSet();

            return result;
        }
        
        public async Task<bool> Insert(Merch merch, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                INSERT INTO merches (type_id, merch_status, employee_id, issue_date)
                VALUES (@MerchType, @MerchStatus, @EmployeeId, @IssueDate)
                RETURNING id;";

            var parameters = new
            {
                MerchType  = merch.MerchType.Id,
                MerchStatus = merch.MerchStatus.Id,
                EmployeeId = merch.EmployeeId,
                IssueDate = merch.IssueDate.Value
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var merch_ids = await connection.QueryAsync<long>(commandDefinition); //ExecuteAsync<long>(commandDefinition);

            var merchId = (merch_ids.Count() > 0) ? merch_ids.First() : 0;

            if (merch.SkuSet.Count > 0)
            {
                var sb = new StringBuilder();
                sb.Append("INSERT INTO merch_sku (merch_id, sku_id, quantity) VALUES ");
                foreach (var sku in merch.SkuSet)
                {
                    sb.Append($"({merchId}, {sku.Key.Value}, {sku.Value.Value}),");
                }

                sb[^1] = ';';

                var sqlSku = sb.ToString();
                var commandDefinitionSku = new CommandDefinition(
                    sqlSku,
                    commandTimeout: Timeout,
                    cancellationToken: cancellationToken);
                await connection.ExecuteAsync(commandDefinitionSku);
            }
            
            return true;
        }
        
        public Task<bool> UpdateStatus(Merch merch, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}