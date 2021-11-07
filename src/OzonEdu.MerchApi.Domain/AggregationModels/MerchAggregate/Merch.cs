using System;
using System.Collections.Generic;
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
        public Dictionary<long, Quantity> SkuSet { get; }

        public Merch(
            MerchType merchType,
            EmployeeId employeeId,
            IssueDate issueDate,
            MerchStatus merchStatus,
            Dictionary<long, Quantity> skuSet)
        {
            MerchType = merchType;
            EmployeeId = employeeId;
            IssueDate = issueDate;
            MerchStatus = merchStatus;
            SkuSet = skuSet;
        }
    }
}