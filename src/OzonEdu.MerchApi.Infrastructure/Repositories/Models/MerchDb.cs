using System;
using System.Diagnostics.CodeAnalysis;

namespace OzonEdu.MerchApi.Infrastructure.Repositories.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class MerchDb
    {
        public long Id { get; set; }
        
        public long MerchType { get; set; }
        
        public long MerchStatus { get; set; }
        
        public long EmployeeId { get; set; }
        
        public DateTime IssueDate { get; set; }
    }
}