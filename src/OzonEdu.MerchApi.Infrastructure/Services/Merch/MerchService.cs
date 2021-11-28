using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Services
{
    public class MerchService : IMerchService
    {
        private readonly IMerchRepository _merchRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMerchConfigurator _merchConfigurator;

        public MerchService(IMerchRepository merchRepository, IEmployeeRepository employeeRepository, IMerchConfigurator merchConfigurator)
        {
            _merchRepository = merchRepository;
            _employeeRepository = employeeRepository;
            _merchConfigurator = merchConfigurator;
        }
        
        public async Task<MerchStatus> OrderMerch(MerchType merchType, long employeeId, ISet<SkuOption> merchOptions, CancellationToken cancellationToken = default)
        {
            var merchStatus = MerchStatus.Unavailable;

            var employeeHasRight = await CheckEmployee(employeeId, merchType, cancellationToken);

            if (!employeeHasRight)
            {
                merchStatus = MerchStatus.Unavailable;
                
                return merchStatus;
            }

            var merchIsAvailable = await CheckEmployeesMerch(employeeId, merchType, cancellationToken);

            if (!merchIsAvailable)
            {
                merchStatus = MerchStatus.Unavailable;

                return merchStatus;
            }
            
            var merchSet = await _merchConfigurator.Configure(merchType, merchOptions);

            merchStatus = MerchStatus.Ready;

            var merch = new Merch(
                merchType,
                employeeId,
                new IssueDate(DateTime.Today),
                merchStatus,
                merchSet);

            await _merchRepository.Insert(merch, cancellationToken);

            return merchStatus;
        }

        private async Task<bool> CheckEmployee(long employeeId, MerchType merchType, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.FindByIdAsync(employeeId, cancellationToken);
            
            var workDays = (DateTime.Today - employee.HiringDate.Value).TotalDays;
            
            if (merchType.Equals(MerchType.VeteranPack))
            {
                return workDays > 365 * 5;
            }

            if (merchType.Equals(MerchType.ProbationPeriodEndingPack))
            {
                return workDays > 30 * 3;
            }

            return true;
        }

        private async Task<bool> CheckEmployeesMerch(long employeeId, MerchType merchType, CancellationToken cancellationToken)
        {
            var employeesMerch = await _merchRepository.FindByEmployeeIdAsync(employeeId, cancellationToken);

            var merchTypeDate = employeesMerch.Where(m => m.MerchType.Equals(merchType))
                .Select(m => m.IssueDate)
                .Max();

            if (merchTypeDate is null)
                return true;
            
            var days = (DateTime.Today - merchTypeDate.Value).TotalDays;

            return days > 365;
        }
    }
}