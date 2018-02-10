//  --------------------------------------------------------------------------------------
// slnGameOn.CustomerMapper.cs
// 2018/02/10
//  --------------------------------------------------------------------------------------

using System;
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

            foreach (DataRow phoneRow in phoneData.Rows)
                customer.Phone.Add(new Phone
                                   {
                                       PhoneId = Convert.ToInt32(phoneRow["PhoneId"]),
                                       TypeId = Convert.ToInt32(phoneRow["PhoneTypeId"]),
                                       Type = phoneRow["PhoneType"].ToString(),
                                       PhoneNumber = phoneRow["Phone"].ToString()
                                   });
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
    }
}