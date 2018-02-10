//  --------------------------------------------------------------------------------------
// slnGameOn.PhoneMapper.cs
// 2018/02/10
//  --------------------------------------------------------------------------------------

using System;
using System.Data;
using GameOn.Models;

namespace GameOn.Mapper
{
    public class PhoneMapper : MapperBase
    {
        public Phone Map(DataRow phoneRow)
        {
            return new Phone
                   {
                       PhoneId = Convert.ToInt32(FieldNames.Phone.Id),
                       TypeId = Convert.ToInt32(FieldNames.Phone.PhoneTypeId),
                       Type = GetStringValue(phoneRow[FieldNames.Phone.PhoneType]),
                       PhoneNumber = GetStringValue(phoneRow[FieldNames.Phone.PhoneNumber])
                   };
        }
    }
}