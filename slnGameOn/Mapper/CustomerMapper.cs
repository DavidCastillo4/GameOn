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
                               FirstName = customerDataRow["FirstName"].ToString(),
                               LastName = customerDataRow["LastName"].ToString(),
                               Gender = customerDataRow["Gender"].ToString(),
                               DOB = customerDataRow["DOB"].ToString(),
                               MaritalStatus = customerDataRow["MaritalStatus"].ToString(),
                               EmailId = customerDataRow["EmailId"].ToString(),
                               Email = customerDataRow["Email"].ToString(),
                               AddressId = customerDataRow["AddressId"].ToString(),
                               Address = customerDataRow["Address"].ToString(),
                               CityStateZip = customerDataRow["CityStateZip"].ToString(),
                               PassWord = customerDataRow["PassWord"].ToString()
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