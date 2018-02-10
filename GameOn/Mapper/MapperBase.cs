//  --------------------------------------------------------------------------------------
// slnGameOn.MapperBase.cs
// 2018/02/10
//  --------------------------------------------------------------------------------------

namespace GameOn.Mapper
{
    public abstract class MapperBase
    {
        protected string GetStringValue(object input)
        {
            return input.ToString();
        }
    }
}