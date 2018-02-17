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

        public BrowseViewModel(IList<Product> products)
        {
            Products = products;
        }

        public IList<Product> Products { get; }
    }
}