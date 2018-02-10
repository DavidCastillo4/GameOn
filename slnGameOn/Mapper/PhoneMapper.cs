//  --------------------------------------------------------------------------------------
// slnGameOn.PhoneMapper.cs
// 2018/02/10
//  --------------------------------------------------------------------------------------

using System;
using System.Data;
using slnGameOn.Models;

namespace slnGameOn.Mapper
{
    public class PhoneMapper
    {
        public Phone Map(DataRow phoneRow)
        {
            return new Phone
                   {
                       PhoneId = Convert.ToInt32(phoneRow["PhoneId"]),
                       TypeId = Convert.ToInt32(phoneRow["PhoneTypeId"]),
                       Type = phoneRow["PhoneType"].ToString(),
                       PhoneNumber = phoneRow["Phone"].ToString()
                   };
        }
    }
}