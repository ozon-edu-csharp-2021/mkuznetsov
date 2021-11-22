using System;
using System.Collections.Generic;
using MerchType = CSharpCourse.Core.Lib.Enums.MerchType;

namespace OzonEdu.MerchApi.Infrastructure.HttpModels
{
    public class MerchInfo
    {
        public MerchType MerchType { get; set; }
        
        public long EmployeeId { get; set; }
        
        public DateTime IssueDate { get; set; }

        public MerchStatus MerchStatus { get; set; }
        
        public Dictionary<long, int> SkuSet { get; set; }
    }
}