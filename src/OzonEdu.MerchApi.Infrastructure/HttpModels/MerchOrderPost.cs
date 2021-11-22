using System.Collections.Generic;
using CSharpCourse.Core.Lib.Enums;

namespace OzonEdu.MerchApi.Infrastructure.HttpModels
{
    public class MerchOrderPost
    {
        public long EmployeeId { get; set; }
        
        public MerchType MerchType { get; set; }
        
        public IList<long> MerchOptions { get; set; }
    }
}