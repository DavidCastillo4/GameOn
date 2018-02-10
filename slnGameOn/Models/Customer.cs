//  --------------------------------------------------------------------------------------
// slnGameOn.Customer.cs
// 2018/02/09
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace slnGameOn.Models
{
    public class Customer
    {
        public Customer(int id)
            : this()
        {
            CustomerId = id;
        }

        public Customer()
        {
            // Default constructor
            Phone = new List<Phone>();
        }

        public string Address { get; set; }

        public string AddressId { get; set; }

        public string CityStateZip { get; set; }

        public int CustomerId { get; set; }

        public string DOB { get; set; }

        public string Email { get; set; }

        public string EmailId { get; set; }

        public string FirstName { get; set; }

        public string Gender { get; set; }

        public string LastName { get; set; }

        public string MaritalStatus { get; set; }

        public string Password { get; set; }

        public List<Phone> Phone { get; set; }

        public int PhoneId { get; set; }
    }
}