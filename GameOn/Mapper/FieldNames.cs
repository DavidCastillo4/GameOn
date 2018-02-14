//  --------------------------------------------------------------------------------------
// GameOn.FieldNames.cs
// 2018/02/10
//  --------------------------------------------------------------------------------------

namespace GameOn.Mapper
{
    public class FieldNames
    {
        public class Customer
        {
            public const string Address = "Address";
            public const string AddressId = "AddressId";
            public const string CityStateZip = "CityStateZip";
            public const string DateOfBirth = "DOB";
            public const string Email = "Email";
            public const string EmailId = "EmailId";
            public const string FirstName = "FirstName";
            public const string Gender = "Gender";
            public const string LastName = "LastName";
            public const string MaritalStatus = "MaritalStatus";
            public const string Password = "Password";
        }

        public class Phone
        {
            public const string Id = "PhoneId";
            public const string PhoneNumber = "Phone";
            public const string PhoneType = "PhoneType";
            public const string PhoneTypeId = "PhoneTypeId";
        }
    }
}