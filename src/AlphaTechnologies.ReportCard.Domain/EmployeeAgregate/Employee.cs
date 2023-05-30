using AlphaTechnologies.ReportCard.Domain.ComingEntity;
using AlphaTechnologies.ReportCard.Domain.DepartmentAgregate;
using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate.Events;
using AlphaTechnologies.ReportCard.Domain.PositionEntity;
using AlphaTechnologies.ReportCard.Domain.WorkStatusEntity;
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
        public int? DepartmentId { get; protected set; }
        public PersonalData PersonalData { get; protected set; }
        public DateOnly Birthday { get; protected set; }
        public ServiceNumber ServiceNumber { get; protected set; }
        //public int Age { get; protected set; } must be calculated
        public Address Address { get; protected set; }
        private List<Position> _positions = new List<Position>();
        public IReadOnlyCollection<Position> Positions => _positions.AsReadOnly();

        private List<Coming> _comings = new List<Coming>();
        public IReadOnlyCollection<Coming> Comings => _comings.AsReadOnly();

        public bool IsRemote { get; protected set; } = false;

        protected Employee() { }

        public Employee(DateOnly birthday, ServiceNumber serviceNumber, PersonalData personalData, Address address)
        {
            PersonalData = personalData;
            if (birthday >= DateOnly.FromDateTime(DateTime.Today))
                throw new InvalidOperationException($"Invalid birthday value: {birthday}");
            Birthday = birthday;
            ServiceNumber = serviceNumber;
            Address = address;
        }

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

        //public void ChangeAge(int age)
        //{
        //    if (age < 1 || age > 150)
        //        throw new ArgumentException($"Invalid age value: {age}");
        //    Age = age;
        //    AddDomainEvent(new AgeChangedEvent(Id, Age));
        //}

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

        public void AddPosition(Position position)
        {
            _positions ??= new List<Position>();
            if (_positions.Any(p => p.Id == position.Id))
                throw new InvalidOperationException($"Employee with id: {Id} is already on position with id: {position.Id}");
            _positions.Add(position);
            position.AddEmployee(this);
            AddDomainEvent(new PositionAddedEvent(Id, position.Id));
        }

        public void RemovePosition(Position position) 
        {
            if (_positions?.Any(p => p.Id == position.Id) != true)
                throw new InvalidOperationException($"Employee with id: {Id} has no such position with id: {position.Id}");
            _positions?.Remove(position);
            position.RemoveEmployee(this);
            AddDomainEvent(new PositionRemovedEvent(Id, position.Id));
        }

        internal void AddDepartment(Department department)
        {
            if (DepartmentId != null || DepartmentId == department.Id)
                throw new InvalidOperationException($"This employee (id: {Id}) is already works in department with id: {DepartmentId}");
            DepartmentId = department.Id;
        }

        internal void RemoveDepartment(Department department)
        {
            if (DepartmentId == null)
                throw new InvalidOperationException($"Employee (id: '{Id}') is not working on any department");
            if (DepartmentId != department.Id)
                throw new InvalidOperationException($"Unable to remove department with id: {department.Id} because of this employee (id: {Id}) works in department with id" +
                    $"{DepartmentId}");
            DepartmentId = null;
        }

        public Coming CheckIn(DateOnly date, WorkStatus status)
        {
            Coming coming = new Coming(date);
            if (_comings.Any(c => c.Date == coming.Date))
                throw new InvalidOperationException($"Employee with id: {Id} is already cheked in");
            coming.ChangeWorkStatus(status);
            coming.ChangeEmployee(this);
            _comings.Add(coming);
            status.AddComing(coming);
            AddDomainEvent(new EmployeeChekedInEvent(Id, date, status.Code));
            return coming;
        }

        public void ChangeWorkStatus(DateOnly date, WorkStatus oldStatus, WorkStatus status)
        {
            Coming? coming = _comings.FirstOrDefault(c => c.Date == date);
            if (coming == default)
                throw new InvalidOperationException($"Employee was not cheked yet. Check it first");
            coming.ChangeWorkStatus(status);
            oldStatus.RemoveComing(coming);
            status.AddComing(coming);
            AddDomainEvent(new WorkStatusChangedEvent(Id, date, status.Code));
        }

        public void TransferToRemoteWork()
        {
            if (IsRemote)
                throw new InvalidOperationException($"Employee (id: {Id}) is already on remote work");
            IsRemote = true;
        }
        public void TransferFromRemoteWork()
        {
            if (!IsRemote)
                throw new InvalidOperationException($"Employee (id: {Id}) is not on remote work");
            IsRemote = false;
        }
    }
}
