//  --------------------------------------------------------------------------------------
// GameOn.Web.AddToCartViewModel.cs
// 2018/02/18
//  --------------------------------------------------------------------------------------

using System.ComponentModel;
using GameOn.Model;

namespace GameOn.Web.ViewModel
{
    public class AddToCartViewModel
    {
        public delegate AddToCartViewModel Factory(Product product);

        public AddToCartViewModel()
        {
        }

        public AddToCartViewModel(Product product)
        {
            ProductId = product.Id;
            ProductName = product.Name;
        }

        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        public int Quantity { get; set; }
    }
}