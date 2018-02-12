//  --------------------------------------------------------------------------------------
// slnGameOn.Customer.cs
// 2018/02/09
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;

namespace GameOn.Models
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
            PhoneNumbers = new List<Phone>();
        }

        [DisplayName("Billing Address")]
        public string Address { get; set; }

        public string AddressId { get; set; }

        public string CityStateZip { get; set; }

        public int CustomerId { get; set; }

        [DisplayName("Birth Date")]
        public string DOB { get; set; }

        [DisplayName("Login Email")]
        public string Email { get; set; }

        public string EmailId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public string Gender { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Marital Status")]
        public string MaritalStatus { get; set; }

        public string Password { get; set; }

        public List<Phone> PhoneNumbers { get; set; }

        public int PhoneId { get; set; }
    }
}