using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate
{
    public class Merch : Entity
    {
        public MerchType MerchType { get; }
        public EmployeeId EmployeeId { get; }
        public IssueDate IssueDate { get; }
        public MerchStatus MerchStatus { get; }

        public Merch(
            MerchType merchType,
            EmployeeId employeeId,
            IssueDate issueDate,
            MerchStatus merchStatus)
        {
            MerchType = merchType;
            EmployeeId = employeeId;
            IssueDate = issueDate;
            MerchStatus = merchStatus;
        }
    }
}