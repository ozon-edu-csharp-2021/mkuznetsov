using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate
{
    public class Employee : Entity
    {
        public FirstName FirstName { get; }
        public LastName LastName { get; }
        public MiddleName MiddleName { get; }
        public BirthDay BirthDay { get; }
        public HiringDate HiringDate { get; }
        public Email Email { get; }
        
        public Employee(
            long id,
            FirstName firstName,
            LastName lastName,
            MiddleName middleName,
            BirthDay birthDay,
            HiringDate hiringDate,
            Email email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            BirthDay = birthDay;
            HiringDate = hiringDate;
            Email = email;
        }
    }
}