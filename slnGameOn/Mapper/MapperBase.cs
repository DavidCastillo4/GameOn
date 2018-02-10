//  --------------------------------------------------------------------------------------
// slnGameOn.MapperBase.cs
// 2018/02/10
//  --------------------------------------------------------------------------------------

using System.Runtime.InteropServices.ComTypes;

namespace slnGameOn.Mapper
{
    public abstract class MapperBase
    {
        protected string GetStringValue(object input)
        {
            return input.ToString();
        }
    }
}