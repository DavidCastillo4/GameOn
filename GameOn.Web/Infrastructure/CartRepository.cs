//  --------------------------------------------------------------------------------------
// GameOn.Web.CartRepository.cs
// 2018/02/18
//  --------------------------------------------------------------------------------------

using System.Linq;
using GameOn.Repository;
using GameOn.Web.ViewModel;

namespace GameOn.Web.Infrastructure
{
    public class CartRepository
    {
        readonly CartListItemViewModel.Factory itemViewModelFactory;
        readonly IRepository repository;

        public CartRepository(IRepository repository, CartListItemViewModel.Factory itemViewModelFactory)
        {
            this.repository = repository;
            this.itemViewModelFactory = itemViewModelFactory;
        }

        public CartViewModel AddItem(CartViewModel cart, int productId, int quantity)
        {
            var existingItem = cart.Items.FirstOrDefault(p => p.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var product = repository.Products.FirstOrDefault(p => p.Id == productId);
                var itemViewModel = itemViewModelFactory.Invoke(quantity, product);
                cart.Items.Add(itemViewModel);
            }
            return cart;
        }

        public CartViewModel RemoveItem(CartViewModel cart, int productId)
        {
            var item = cart.Items.FirstOrDefault(p => p.ProductId == productId);
            if (item != null)
                cart.Items.Remove(item);
            return cart;
        }
    }
}