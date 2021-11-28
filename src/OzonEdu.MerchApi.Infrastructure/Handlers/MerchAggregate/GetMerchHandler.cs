using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchApi.Infrastructure.HttpModels;
using MerchStatus = OzonEdu.MerchApi.Infrastructure.HttpModels.MerchStatus;
using MType = CSharpCourse.Core.Lib.Enums.MerchType;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.MerchAggregate
{
    public abstract class GetMerchHandler
    {
        protected IEnumerable<MerchInfo> PrepareResponse(IEnumerable<Merch> merchList) =>
            merchList.Select(m => ConvertMerch(m)).ToList();
        

        protected MerchInfo ConvertMerch(Merch merch)
        {
            var skus = merch.SkuSet
                ?.ToDictionary(t => t.Key.Value, t => t.Value.Value );

            return new MerchInfo
            {
                Id = merch.Id,
                MerchType = (MType) merch.MerchType.Id,
                EmployeeId = merch.EmployeeId,
                IssueDate = merch.IssueDate.Value,
                MerchStatus = (MerchStatus) merch.MerchStatus.Id,
                SkuSet = skus
            };
        }
    }
}