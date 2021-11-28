using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Commands
{
    public class OrderMerchCommand : IRequest<MerchStatus>
    {
        public CSharpCourse.Core.Lib.Enums.MerchType MerchType { get; init; }
        
        public long EmployeeId { get; init; }
        
        public IList<string> MerchOptions { get; init; }
    }
}