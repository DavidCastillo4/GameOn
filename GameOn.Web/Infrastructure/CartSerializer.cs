//  --------------------------------------------------------------------------------------
// GameOn.Web.CartSerializer.cs
// 2018/02/18
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using GameOn.Repository;
using GameOn.Web.Models;
using GameOn.Web.ViewModel;
using Newtonsoft.Json;

namespace GameOn.Web.Infrastructure
{
    public class CartSerializer
    {
        readonly IRepository repository;
        readonly CartViewModel.Factory cartFactory;
        readonly CartListItemViewModel.Factory itemFactory;

        public CartSerializer(IRepository repository, CartViewModel.Factory cartFactory, CartListItemViewModel.Factory itemFactory)
        {
            this.repository = repository;
            this.cartFactory = cartFactory;
            this.itemFactory = itemFactory;
        }

        public CartViewModel Deserialize(string cartData)
        {
            IList<CartItem> rawItems = JsonConvert.DeserializeObject<List<CartItem>>(cartData);
            IList<CartListItemViewModel> items = new List<CartListItemViewModel>();
            foreach (var item in rawItems)
            {
                var product = repository.Products.FirstOrDefault(p => p.Id == item.ProductId);
                items.Add(itemFactory.Invoke(item.Quantity, product));
            }

            var viewModel = cartFactory.Invoke();
            viewModel.Items = items;
            return viewModel;   
        }

        public string Serialize(CartViewModel cartViewModel)
        {
            return JsonConvert.SerializeObject(cartViewModel.Items);
        }
    }
}