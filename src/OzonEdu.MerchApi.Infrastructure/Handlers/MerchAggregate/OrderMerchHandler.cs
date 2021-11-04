using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchApi.Infrastructure.Commands;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.MerchAggregate
{
    public class OrderMerchHandler : IRequestHandler<OrderMerchCommand, MerchStatus>
    {
        private readonly IMerchRepository _merchRepository;

        public OrderMerchHandler(IMerchRepository merchRepository)
        {
            _merchRepository = merchRepository;
        }
        
        public Task<MerchStatus> Handle(OrderMerchCommand request, CancellationToken cancellationToken)
        {
            return _merchRepository.Order(request.MerchType, request.EmployeeId, cancellationToken);
        }
    }
}