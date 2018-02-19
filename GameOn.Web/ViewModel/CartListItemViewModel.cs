//  --------------------------------------------------------------------------------------
// GameOn.Web.CartListItemViewModel.cs
// 2018/02/18
//  --------------------------------------------------------------------------------------

using GameOn.Model;

namespace GameOn.Web.ViewModel
{
    public class CartListItemViewModel
    {
        public delegate CartListItemViewModel Factory(int quantity, Product product);

        readonly Product product;

        public CartListItemViewModel(int quantity, Product product)
        {
            Quantity = quantity;
            this.product = product;
        }

        public string Name => product.Name;

        public double Price => product.Price;

        public int Quantity { get; set; }

        public double Subtotal => Quantity * Price;

        public int ProductId => product.Id;
    }
}