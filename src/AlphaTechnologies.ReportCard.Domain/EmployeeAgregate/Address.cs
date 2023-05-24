using AlphaTechnologies.ReportCard.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Domain.EmployeeAgregate
{
    public class Address : ValueObject
    {
        public string Country { get; }
        public string City { get; }
        public string Region { get; }
        public string Street { get; }
        public int HouseNumber { get; }
        private string _address = string.Empty;
        public virtual string Value { get => $"{Country}, {Region}, {City}, ул. {Street} {HouseNumber}"; protected set; } 

        public Address(string country, string city, string region, string street, int houseNumber)
        {
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country is null or empty");
            Country = country;
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City is null or empty");
            City = city;
            if (string.IsNullOrWhiteSpace(region))
                throw new ArgumentException("Region is null or empty");
            Region = region;
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street is null or empty");
            Street = street;
            if (houseNumber < 0)
                throw new ArgumentException($"Invalid value of House Number: {houseNumber}");
            HouseNumber = houseNumber;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Country; 
            yield return City; 
            yield return Region; 
            yield return Street; 
            yield return HouseNumber;
        }
    }
}
