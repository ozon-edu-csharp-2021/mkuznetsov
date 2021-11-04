using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchApi.Infrastructure.Commands;
using OzonEdu.MerchApi.Infrastructure.Queries;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.MerchAggregate
{
    public class GetMerchByEmployeeIdHandler : IRequestHandler<GetMerchByEmployeeIdQuery, IEnumerable<Merch>>
    {
        private readonly IMerchRepository _merchRepository;

        public GetMerchByEmployeeIdHandler(IMerchRepository merchRepository) =>
            _merchRepository = merchRepository;
        
        public Task<IEnumerable<Merch>> Handle(GetMerchByEmployeeIdQuery request, CancellationToken cancellationToken) =>
            _merchRepository.FindByEmployeeIdAsync(new EmployeeId(request.EmployeeId), cancellationToken);
    }
}