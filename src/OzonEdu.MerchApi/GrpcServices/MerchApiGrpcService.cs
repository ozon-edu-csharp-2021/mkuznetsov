using System;
using System.Threading.Tasks;
using Grpc.Core;
using OzonEdu.MerchApi.Grpc;

namespace OzonEdu.MerchApi.GrpcServices
{
    public class MerchApiGrpcService : MerchApiGrpc.MerchApiGrpcBase
    {
        public override Task<GetHistoryResponse> GetHistory(GetHistoryRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GetHistoryResponse
            {
                Orders =
                {
                    new GetHistoryResponseUnit
                    {
                        EmployeeId = 12,
                        IssueDate = DateTime.Now.ToString(),
                        MerchType = MerchType.WelcomePack,
                        Status = OrderStatus.Ready
                    },
                    new GetHistoryResponseUnit
                    {
                        EmployeeId = 25,
                        IssueDate = DateTime.Now.ToString(),
                        MerchType = MerchType.VeteranPack,
                        Status = OrderStatus.Unavailable
                    },
                }
            });
        }

        public override Task<MakeOrderResponse> MakeOrder(MakeOrderRequest request, ServerCallContext context)
        {
            return Task.FromResult(new MakeOrderResponse
            {
                Status = OrderStatus.Waiting
            });
        }
    }
}