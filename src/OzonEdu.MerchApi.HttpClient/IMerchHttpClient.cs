using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.HttpModels.Request;
using OzonEdu.MerchApi.HttpModels.Response;

namespace OzonEdu.MerchApi.HttpClient
{
    public interface IMerchHttpClient
    {
        public Task<IReadOnlyList<MerchHistoryResult>?> GetHistory(long employeeId, CancellationToken token);

        public Task<MerchOrderResult> MakeOrder(MerchOrderPost merchOrder, CancellationToken token);
    }
}