//  --------------------------------------------------------------------------------------
// slnGameOn.CustomerMapper.cs
// 2018/02/10
//  --------------------------------------------------------------------------------------

using System.Data;
using GameOn.Models;

namespace GameOn.Mapper
{
    public class CustomerMapper : MapperBase
    {
        public Customer Map(DataSet data)
        {
            var customerDataRow = data.Tables[0].Rows[0];
            var phoneData = data.Tables[1];
            var customer = CreateCustomer(customerDataRow);

            MapPhoneNumbers(phoneData, customer);
            return customer;
        }

        static void MapPhoneNumbers(DataTable phoneData, Customer customer)
        {
            var phoneMapper = new PhoneMapper();
            foreach (DataRow phoneRow in phoneData.Rows)
                customer.Phone.Add(phoneMapper.Map(phoneRow));
        }

        Customer CreateCustomer(DataRow customerDataRow)
        {
            var customer = new Customer
                           {
                               FirstName = GetStringValue(customerDataRow[FieldNames.Customer.FirstName]),
                               LastName = GetStringValue(customerDataRow[FieldNames.Customer.LastName]),
                               Gender = GetStringValue(customerDataRow[FieldNames.Customer.Gender]),
                               DOB = GetStringValue(customerDataRow[FieldNames.Customer.DateOfBirth]),
                               MaritalStatus = GetStringValue(customerDataRow[FieldNames.Customer.MaritalStatus]),
                               EmailId = GetStringValue(customerDataRow[FieldNames.Customer.EmailId]),
                               Email = GetStringValue(customerDataRow[FieldNames.Customer.Email]),
                               AddressId = GetStringValue(customerDataRow[FieldNames.Customer.AddressId]),
                               Address = GetStringValue(customerDataRow[FieldNames.Customer.Address]),
                               CityStateZip = GetStringValue(customerDataRow[FieldNames.Customer.CityStateZip]),
                               Password = GetStringValue(customerDataRow[FieldNames.Customer.Password])
                           };
            return customer;
        }
    }
}