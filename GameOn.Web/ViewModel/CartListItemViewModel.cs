//  --------------------------------------------------------------------------------------
// GameOn.Web.CartListItemViewModel.cs
// 2018/02/18
//  --------------------------------------------------------------------------------------

using GameOn.Model;

namespace GameOn.Web.ViewModel
{
    public class CartListItemViewModel
    {
        readonly Product product;

        public delegate CartListItemViewModel Factory(int quantity, Product product);

        public CartListItemViewModel(int quantity, Product product)
        {
            Quantity = quantity;
            this.product = product;
        }

        public string Name => product.Name;

        public int Quantity { get; }

        public double Price => product.Price;
    }
}