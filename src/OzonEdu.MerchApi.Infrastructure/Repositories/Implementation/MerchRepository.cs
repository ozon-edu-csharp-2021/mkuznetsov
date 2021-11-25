using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
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

        public async Task<IEnumerable<Merch>> FindByEmployeeIdAsync(EmployeeId employeeId, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                select m.id, m.type_id MerchType, m.merch_status MerchStatus,
                       m.employee_id EmployeeId, m.issue_date IssueDate
                  from merches m
                 where m.employee_id = @EmployeeId";

            var parameters = new
            {
                EmployeeId = employeeId.Value,
            };
            
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var merchesDb = await connection.QueryAsync<MerchDb>(
                commandDefinition);

            var merches = merchesDb.Select(m => new Merch(
                m.Id,
                MerchType.FromValue<MerchType>((int) m.MerchType),
                new EmployeeId(m.EmployeeId),
                new IssueDate(m.IssueDate),
                MerchStatus.FromValue<MerchStatus>((int)m.MerchStatus),
                new Dictionary<Sku, Quantity>()
                ))
                .ToDictionary(m => m.Id, m => m);

            const string sqlSku = @"
                select ms.merch_id MerchId, ms.sku_id SkuId, ms.quantity 
                  from merches m
                  join merch_sku ms
                    on m.id = ms.merch_id
                 where m.employee_id = @EmployeeId";
            
            var commandDefinitionSku = new CommandDefinition(
                sqlSku,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            
            var merchesSku = await connection.QueryAsync<MerchSkuDb>(
                commandDefinitionSku);

            foreach (var sku in merchesSku)
            {
                merches[sku.MerchId].SkuSet[new Sku(sku.SkuId)] = new Quantity(sku.Quantity);
            }

            var result = merches.ToHashSet()
                .Select(kv => kv.Value)
                .ToList();
            
            return result;
        }

        public Task<IEnumerable<Merch>> FindAll(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
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
                EmployeeId = merch.EmployeeId.Value,
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
    }
}