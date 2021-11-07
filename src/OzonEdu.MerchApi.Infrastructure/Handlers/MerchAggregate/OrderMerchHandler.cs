using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchApi.Infrastructure.Commands;
using OzonEdu.MerchApi.Infrastructure.Services;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.MerchAggregate
{
    public class OrderMerchHandler : IRequestHandler<OrderMerchCommand, MerchStatus>
    {
        private readonly IMerchService _merchService;

        public OrderMerchHandler(IMerchService merchService)
        {
            _merchService = merchService;
        }
        
        public Task<MerchStatus> Handle(OrderMerchCommand request, CancellationToken cancellationToken)
        {
            var options = request.MerchOptions
                .Select(d => Tuple.Create(new SkuOption(d.Key), new SkuOptionValue(d.Value)))
                .ToHashSet();
            
            return _merchService.OrderMerch(MerchType.FromValue<MerchType>((int)request.MerchType), new EmployeeId(request.EmployeeId), options, cancellationToken);
        }
    }
}