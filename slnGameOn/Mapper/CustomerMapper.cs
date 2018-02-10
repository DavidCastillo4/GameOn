//  --------------------------------------------------------------------------------------
// slnGameOn.CustomerMapper.cs
// 2018/02/10
//  --------------------------------------------------------------------------------------

using System.Data;
using slnGameOn.Models;

namespace slnGameOn.Mapper
{
    public class CustomerMapper
    {
        public Customer Map(DataSet data)
        {
            var customerDataRow = data.Tables[0].Rows[0];
            var phoneData = data.Tables[1];
            var customer = CreateCustomer(customerDataRow);

            MapPhoneNumbers(phoneData, customer);
            return customer;
        }

        static Customer CreateCustomer(DataRow customerDataRow)
        {
            var customer = new Customer
                           {
                               FirstName = customerDataRow[FieldNames.Customer.FirstName].ToString(),
                               LastName = customerDataRow[FieldNames.Customer.LastName].ToString(),
                               Gender = customerDataRow[FieldNames.Customer.Gender].ToString(),
                               DOB = customerDataRow[FieldNames.Customer.DateOfBirth].ToString(),
                               MaritalStatus = customerDataRow[FieldNames.Customer.MaritalStatus].ToString(),
                               EmailId = customerDataRow[FieldNames.Customer.EmailId].ToString(),
                               Email = customerDataRow[FieldNames.Customer.Email].ToString(),
                               AddressId = customerDataRow[FieldNames.Customer.AddressId].ToString(),
                               Address = customerDataRow[FieldNames.Customer.Address].ToString(),
                               CityStateZip = customerDataRow[FieldNames.Customer.CityStateZip].ToString(),
                               PassWord = customerDataRow[FieldNames.Customer.Password].ToString()
                           };
            return customer;
        }

        static void MapPhoneNumbers(DataTable phoneData, Customer customer)
        {
            var phoneMapper = new PhoneMapper();
            foreach (DataRow phoneRow in phoneData.Rows)
                customer.Phone.Add(phoneMapper.Map(phoneRow));
        }
    }
}