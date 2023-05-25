using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate.Events;
using AlphaTechnologies.ReportCard.SharedKernel;
using AlphaTechnologies.ReportCard.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.EmployeeAgregate
{
    public class Employee : EntityBase<int>, IAgregateRoot
    {
        public int DepartmentId { get; protected set; }
        public PersonalData PersonalData { get; protected set; }
        public DateOnly Birthday { get; protected set; }
        public ServiceNumber ServiceNumber { get; protected set; }
        public int Age { get; protected set; }
        public Address Address { get; protected set; }

        public void ChangeFirstName(string firstName)
        {
            PersonalData = new PersonalData(firstName, PersonalData.LastName, PersonalData.Patronymic);
            AddDomainEvent(new FirstNameChangedEvent(Id, firstName));
        }

        public void ChangeLastName(string lastName)
        {
            PersonalData = new PersonalData(PersonalData.FirstName, lastName, PersonalData.Patronymic);
            AddDomainEvent(new LastNameChangedEvent(Id, lastName));
        }

        public void ChangePatronymic(string patronymic)
        {
            PersonalData = new PersonalData(PersonalData.FirstName, PersonalData.LastName, patronymic);
            AddDomainEvent(new PatronymicChangedEvent(Id, patronymic));
        }

        public void ChangeBirthday(DateOnly date)
        {
            Birthday = date;
            AddDomainEvent(new BirthdayChangedEvent(Id, Birthday));
        }

        public void ChangeServiceNumber(string serviceNumber)
        {
            ServiceNumber = new ServiceNumber(serviceNumber);
            AddDomainEvent(new ServiceNumberChangedEvent(Id, ServiceNumber.Value));
        }

        public void ChangeAge(int age)
        {
            if (age < 1 || age > 150)
                throw new ArgumentException($"Invalid age value: {age}");
            Age = age;
            AddDomainEvent(new AgeChangedEvent(Id, Age));
        }

        public void ChangeAddress(string address)
        {
            Address = new Address(address);
            AddDomainEvent(new AddressChangedEvent(Id, Address.Value));
        }
        public void ChangeAddress(Address address)
        {
            Address = new Address(address.Country, address.City, address.Region, address.Street, address.HouseNumber);
            AddDomainEvent(new AddressChangedEvent(Id, Address.Value));
        }
    }
}
