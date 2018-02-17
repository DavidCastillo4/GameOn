//  --------------------------------------------------------------------------------------
// GameOn.Repository.InMemoryRepository.cs
// 2018/02/16
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using GameOn.Model;

namespace GameOn.Repository
{
    public class InMemoryRepository : IRepository
    {
        static readonly IList<Product> products;

        static InMemoryRepository()
        {
            products = new List<Product>();
            CreateSampleProducts();
        }

        public IList<Product> Products => products;

        static void CreateSampleProducts()
        {
            products.Add(new Product {Id = 1, Description = "Product 1 Description", Name = "Product 1", Price = 9.99});
            products.Add(new Product {Id = 2, Description = "Product 2 Description", Name = "Product 2", Price = 19.99});
            products.Add(new Product {Id = 3, Description = "Product 3 Description", Name = "Product 3", Price = 29.99});
            products.Add(new Product {Id = 4, Description = "Product 4 Description", Name = "Product 4", Price = 39.99});
            products.Add(new Product {Id = 5, Description = "Product 5 Description", Name = "Product 5", Price = 49.99});
        }
    }
}