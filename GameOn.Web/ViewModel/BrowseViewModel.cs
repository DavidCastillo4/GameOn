//  --------------------------------------------------------------------------------------
// GameOn.Web.BrowseViewModel.cs
// 2018/02/16
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using GameOn.Model;

namespace GameOn.Web.ViewModel
{
    public class BrowseViewModel
    {
        public delegate BrowseViewModel Factory(IList<Product> products);

        public BrowseViewModel(IList<Product> products, ProductSummaryViewModel.Factory productSummaryFactory)
        {
            Products = new List<ProductSummaryViewModel>();
            foreach (var product in products)
                Products.Add(productSummaryFactory.Invoke(product));
        }

        public IList<ProductSummaryViewModel> Products { get; }
    }
}