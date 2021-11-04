using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Stubs
{
    public class MerchStubRepository : IMerchRepository
    {
        private IEnumerable<Merch> _merches;

        public MerchStubRepository()
        {
            _merches = new List<Merch>
            {
                new Merch(
                    MerchType.WelcomePack,
                    new EmployeeId(1),
                    new IssueDate(new DateTime(2020, 10, 12)),
                    MerchStatus.Ready),
                new Merch(
                    MerchType.ConferenceListenerPack,
                    new EmployeeId(1),
                    new IssueDate(new DateTime(2021, 11, 2)),
                    MerchStatus.Ready),
                new Merch(
                    MerchType.VeteranPack,
                    new EmployeeId(2),
                    new IssueDate(new DateTime(2021, 10, 20)),
                    MerchStatus.Ready),
                new Merch(
                    MerchType.ConferenceSpeakerPack,
                    new EmployeeId(2),
                    new IssueDate(new DateTime(2021, 11, 2)),
                    MerchStatus.Ready),
                new Merch(
                    MerchType.ConferenceListenerPack,
                    new EmployeeId(3),
                    new IssueDate(new DateTime(2021, 11, 2)),
                    MerchStatus.Ready),
            };
        }
        
        public async Task<IEnumerable<Merch>> FindByEmployeeIdAsync(EmployeeId employeeId, CancellationToken cancellationToken = default)
        {
            IEnumerable<Merch> merches = null;
            if (_merches != null)
            {
                merches = _merches.Where(m => m.EmployeeId.Equals(employeeId));
            }

            if (merches != null)
            {
                return merches;
            }
            
            _merches = await FindAll(cancellationToken);
            
            return _merches.Where(m => m.EmployeeId.Equals(employeeId));
        }

        public Task<IEnumerable<Merch>> FindAll(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_merches);
        }

        public async Task<MerchStatus> Order(MerchType merchType, EmployeeId employeeId, CancellationToken cancellationToken = default)
        {
            ((List<Merch>)_merches).Add(
                new Merch(merchType: merchType,
                    employeeId: employeeId,
                    issueDate: new IssueDate(DateTime.Now),
                    merchStatus: MerchStatus.Ready ));

            return MerchStatus.Ready;
        }
    }
}