using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MsHttp = System.Net.Http;
using OzonEdu.MerchApi.HttpModels.Request;
using OzonEdu.MerchApi.HttpModels.Response;

namespace OzonEdu.MerchApi.HttpClient
{
    public class MerchHttpClient : IMerchHttpClient
    {
        private readonly MsHttp.HttpClient _httpClient;
        private readonly string _serverUrl;

        public MerchHttpClient(MsHttp.HttpClient httpClient, string serverUrl)
        {
            _httpClient = httpClient;
            _serverUrl = serverUrl;
        }

        public async Task<List<MerchHistoryResult>?> GetHistory(long employeeId, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"{_serverUrl}/api/merch/history/{employeeId}", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<List<MerchHistoryResult>>(body);
        }

        public async Task<MerchOrderResult> MakeOrder(MerchOrderPost merchOrder, CancellationToken token)
        {
            var json = JsonSerializer.Serialize(merchOrder);
            MsHttp.HttpContent content = new MsHttp.StringContent(json);
            using var response = await _httpClient.PostAsync($"{_serverUrl}/api/merch/order", content, token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchOrderResult>(body) ?? throw new InvalidOperationException();
        }
    }
}