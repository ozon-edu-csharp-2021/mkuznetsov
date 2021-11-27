using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Stubs
{
    public class EmployeeStubRepository : IEmployeeRepository
    {
        private IEnumerable<Employee> _employees;

        public EmployeeStubRepository()
        {
            _employees = new List<Employee>
            {
                new Employee(
                    1,
                    new FirstName("Василий"),
                    new LastName("Пупкин"),
                    new MiddleName("Фёдорович"),
                    new BirthDay(new DateTime(1983, 03, 23)),
                    new HiringDate(new DateTime(2020, 05, 12)),
                    new Email("pupkin@ozon.ru")),
                new Employee(
                    2,
                    new FirstName("Владимир"),
                    new LastName("Ленин"),
                    new MiddleName("Ильич"),
                    new BirthDay(new DateTime(1978, 11, 03)),
                    new HiringDate(new DateTime(2021, 10, 11)),
                    new Email("lenin@ozon.ru")),
                new Employee(
                    3,
                    new FirstName("Джеймс"),
                    new LastName("Бонд"),
                    new MiddleName("Янович"),
                    new BirthDay(new DateTime(1969, 05, 13)),
                    new HiringDate(new DateTime(2020, 06, 10)),
                    new Email("bond@ozon.ru")),
            };
        }
        
        public async Task<Employee> FindByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            Employee employee = null;
            if (_employees != null)
            {
                employee = _employees.First(e => e.Id == id);
            }

            if (employee != null)
            {
                return employee;
            }
            
            _employees = await FindAll(cancellationToken);
            
            return _employees.First(e => e.Id.Equals(id));
        }

        public Task<IEnumerable<Employee>> FindAll(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_employees);
        }
    }
}