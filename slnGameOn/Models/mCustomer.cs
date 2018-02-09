using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace slnGameOn.Models
{
	public class mCustomer
	{
		public mCustomer(int Id)
		{
			CustomerId = Id;
			Phone = new List<mPhone>();
		}
		public int CustomerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string DOB { get; set; }
		public string Gender { get; set; }
		public string MaritalStatus { get; set; }
		public string EmailId { get; set; }
		public string Email { get; set; }
		public int PhoneId { get; set; }
		public string AddressId { get; set; }
		public string Address { get; set; }
		public string CityStateZip { get; set; }
		public string PassWord { get; set; }
		public List<mPhone> Phone { get; set; }
	}
}