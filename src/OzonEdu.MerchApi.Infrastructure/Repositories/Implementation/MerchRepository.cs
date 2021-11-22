using System.Collections.Generic;
using System.Linq;
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
                select m.id, m.type_id MerchType, m.merch_status MerchStatus, m.employee_id EmployeeId, m.issue_date IssueDate
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
            var merchesDb = await connection.QueryAsync<MerchDb>(commandDefinition);

            var result =merchesDb.Select(m => new Merch(
                MerchType.FromValue<MerchType>((int) m.MerchType),
                new EmployeeId(m.EmployeeId),
                new IssueDate(m.IssueDate),
                MerchStatus.FromValue<MerchStatus>((int)m.MerchStatus),
                null
                ));

            return result;
        }

        public Task<IEnumerable<Merch>> FindAll(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Insert(Merch merch, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}