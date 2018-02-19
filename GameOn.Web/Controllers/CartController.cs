//  --------------------------------------------------------------------------------------
// GameOn.Web.CartController.cs
// 2018/02/18
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameOn.Repository;
using GameOn.Web.Infrastructure;
using GameOn.Web.Models;
using GameOn.Web.ViewModel;
using Newtonsoft.Json;

namespace GameOn.Web.Controllers
{
    public class CartController : Controller
    {
        const string CartCookieName = "cart";
        readonly CartItem.Factory cartItemFactory;
        readonly CartListItemViewModel.Factory listItemViewModelFactory;
        readonly CartViewModel.Factory cartViewModelFactory;
        readonly IRepository repository;
        readonly CartCalculator cartCalculator;
        readonly AddToCartViewModel.Factory viewModelFactory;

        public CartController(
            IRepository repository,
            CartCalculator cartCalculator,
            AddToCartViewModel.Factory viewModelFactory,
            CartItem.Factory cartItemFactory,
            CartListItemViewModel.Factory listItemViewModelFactory,
            CartViewModel.Factory cartViewModelFactory)
        {
            this.repository = repository;
            this.cartCalculator = cartCalculator;
            this.viewModelFactory = viewModelFactory;
            this.cartItemFactory = cartItemFactory;
            this.listItemViewModelFactory = listItemViewModelFactory;
            this.cartViewModelFactory = cartViewModelFactory;
        }

        public ActionResult Add(int productId)
        {
            var product = repository.Products.FirstOrDefault(p => p.Id == productId);
            var viewModel = viewModelFactory.Invoke(product);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(AddToCartViewModel viewModel)
        {
            var cookie = Request.Cookies[CartCookieName] ?? new HttpCookie(CartCookieName);
            IList<CartItem> items = JsonConvert.DeserializeObject<List<CartItem>>(cookie.Value ?? "[]");
            items.Add(cartItemFactory.Invoke(viewModel.ProductId, viewModel.Quantity));
            cookie.Value = JsonConvert.SerializeObject(items);
            Response.SetCookie(cookie);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {
            var cookie = Request.Cookies[CartCookieName] ?? new HttpCookie(CartCookieName);
            IList<CartItem> items = JsonConvert.DeserializeObject<List<CartItem>>(cookie.Value ?? "[]");
            IList<CartListItemViewModel> output = new List<CartListItemViewModel>();
            foreach (var item in items)
            {
                var product = repository.Products.FirstOrDefault(p => p.Id == item.ProductId);
                output.Add(listItemViewModelFactory.Invoke(item.Quantity, product));
            }

            var viewModel = cartViewModelFactory.Invoke();
            viewModel.Items = output;
            //viewModel.Subtotal = cartCalculator.CalculateSubtotal(output);
            //viewModel.Tax = cartCalculator.CalculateTax(output);
            //viewModel.Total = viewModel.Subtotal + viewModel.Tax;
            return View(viewModel);
        }
    }
}