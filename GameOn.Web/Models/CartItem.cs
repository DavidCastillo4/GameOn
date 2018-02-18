//  --------------------------------------------------------------------------------------
// GameOn.Web.CartItem.cs
// 2018/02/18
//  --------------------------------------------------------------------------------------

namespace GameOn.Web.Models
{
    public class CartItem
    {
        public delegate CartItem Factory(int productId, int quantity);

        public CartItem(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}