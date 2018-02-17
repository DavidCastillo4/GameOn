//  --------------------------------------------------------------------------------------
// GameOn.Repository.Repository.cs
// 2018/02/16
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using GameOn.Model;

namespace GameOn.Repository
{
    public class Repository
    {
        static Repository()
        {
            Products = new List<Product>();
            CreateSampleProducts();
        }

        public static IList<Product> Products { get; }

        static void CreateSampleProducts()
        {
            Products.Add(new Product {Id = 1, Description = "Product 1 Description", Name = "Product 1", Price = 9.99});
            Products.Add(new Product {Id = 2, Description = "Product 2 Description", Name = "Product 2", Price = 19.99});
            Products.Add(new Product {Id = 3, Description = "Product 3 Description", Name = "Product 3", Price = 29.99});
            Products.Add(new Product {Id = 4, Description = "Product 4 Description", Name = "Product 4", Price = 39.99});
            Products.Add(new Product {Id = 5, Description = "Product 5 Description", Name = "Product 5", Price = 49.99});
        }
    }
}