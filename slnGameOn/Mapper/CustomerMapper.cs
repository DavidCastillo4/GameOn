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
            var customerData = data.Tables[0];
            var phoneData = data.Tables[1];

            var customer = new Customer();
            customer.FirstName = customerData.Rows[0]["FirstName"].ToString();
            customer.LastName = customerData.Rows[0]["LastName"].ToString();
            customer.Gender = customerData.Rows[0]["Gender"].ToString();
            customer.DOB = customerData.Rows[0]["DOB"].ToString();
            customer.MaritalStatus = customerData.Rows[0]["MaritalStatus"].ToString();
            customer.EmailId = customerData.Rows[0]["EmailId"].ToString();
            customer.Email = customerData.Rows[0]["Email"].ToString();
            customer.AddressId = customerData.Rows[0]["AddressId"].ToString();
            customer.Address = customerData.Rows[0]["Address"].ToString();
            customer.CityStateZip = customerData.Rows[0]["CityStateZip"].ToString();
            customer.PassWord = customerData.Rows[0]["PassWord"].ToString();
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
    }
}