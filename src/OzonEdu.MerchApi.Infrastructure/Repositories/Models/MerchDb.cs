using System;

namespace OzonEdu.MerchApi.Infrastructure.Repositories.Models
{
    public class MerchDb
    {
        public long Id { get; set; }
        
        public long MerchType { get; set; }
        
        public long MerchStatus { get; set; }
        
        public long EmployeeId { get; set; }
        
        public DateTime IssueDate { get; set; }
    }
}