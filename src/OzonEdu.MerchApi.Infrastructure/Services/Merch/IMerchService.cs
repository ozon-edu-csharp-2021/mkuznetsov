using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Services
{
    public interface IMerchService
    {
        public Task<MerchStatus> OrderMerch(MerchType merchType, long employeeId, ISet<SkuOption> merchOptions,
            CancellationToken cancellationToken = default);
    }
}