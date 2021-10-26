using System;
using CSharpCourse.Core.Lib.Enums;
using OzonEdu.MerchApi.HttpModels.Enums;

namespace OzonEdu.MerchApi.HttpModels.Response
{
    public class MerchHistoryResult
    {
        public long EmployeeId { get; set; }
        
        public MerchType MerchType { get; set; }
        
        public DateTime IssueDate { get; set; }
        
        public OrderStatus Status { get; set; }
    }
}