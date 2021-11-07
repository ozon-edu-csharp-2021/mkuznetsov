using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchApi.Infrastructure.HttpModels;

namespace OzonEdu.MerchApi.HttpClient
{
    public interface IMerchHttpClient
    {
        public Task<IReadOnlyList<Merch>?> GetHistory(long employeeId, CancellationToken token);

        public Task<MerchStatus> MakeOrder(MerchOrderPost merchOrder, CancellationToken token);
    }
}