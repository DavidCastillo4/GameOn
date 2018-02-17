using System.Collections.Generic;
using GameOn.Model;

namespace GameOn.Repository
{
    public interface IRepository
    {
        IList<Product> Products { get; }
    }
}