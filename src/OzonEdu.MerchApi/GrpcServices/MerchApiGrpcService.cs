using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using dm = OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using corelib = CSharpCourse.Core.Lib.Enums;
using OzonEdu.MerchApi.Grpc;
using OzonEdu.MerchApi.Infrastructure.Commands;
using OzonEdu.MerchApi.Infrastructure.Queries;

namespace OzonEdu.MerchApi.GrpcServices
{
    public class MerchApiGrpcService : MerchApiGrpc.MerchApiGrpcBase
    {
        private readonly IMediator _mediator;

        public MerchApiGrpcService(IMediator mediator) => _mediator = mediator;

        public override async Task<GetHistoryResponse> GetHistory(GetHistoryRequest request, ServerCallContext context)
        {
            var query = new GetMerchByEmployeeIdQuery
            {
                EmployeeId = request.EmployeeId
            };

            var merches = await _mediator.Send(query, context.CancellationToken);

            return new GetHistoryResponse
            {
                Orders =
                {
                    merches.Select(merch =>
                    {
                        MerchType merchType;
                        OrderStatus merchStatus;
                        return new GetHistoryResponseUnit
                        {
                            Id = merch.Id,
                            EmployeeId = merch.EmployeeId,
                            IssueDate = merch.IssueDate.ToString(),
                            MerchType = MerchType.TryParse(merch.MerchType.ToString(), out merchType)
                                ? merchType
                                : MerchType.Unspecified,
                            Status = OrderStatus.TryParse(merch.MerchStatus.ToString(), out merchStatus)
                                ? merchStatus
                                : OrderStatus.Unspecified
                        };
                    })
                }
            };
        }

        public override async Task<MakeOrderResponse> MakeOrder(MakeOrderRequest request, ServerCallContext context)
        {
            var query = new OrderMerchCommand
            {
                EmployeeId = request.EmployeeId,
                MerchType = corelib.MerchType.TryParse<corelib.MerchType>(request.MerchType.ToString(), out var mType) ? mType : corelib.MerchType.WelcomePack,
                MerchOptions = request.MerchOptions
            };

            var result = await _mediator.Send(query, context.CancellationToken);

            OrderStatus status;
            
            return new MakeOrderResponse
            {
                Status = OrderStatus.TryParse(result.Name, out status) ? status : OrderStatus.Unspecified
            };
        }
    }
}