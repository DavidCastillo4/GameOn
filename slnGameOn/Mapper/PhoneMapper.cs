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
                       PhoneId = Convert.ToInt32(FieldNames.Phone.Id),
                       TypeId = Convert.ToInt32(FieldNames.Phone.PhoneTypeId),
                       Type = phoneRow[FieldNames.Phone.PhoneType].ToString(),
                       PhoneNumber = phoneRow[FieldNames.Phone.PhoneNumber].ToString()
                   };
        }
    }
}