//  --------------------------------------------------------------------------------------
// GameOn.Web.CartController.cs
// 2018/02/18
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameOn.Repository;
using GameOn.Web.Models;
using GameOn.Web.ViewModel;
using Newtonsoft.Json;

namespace GameOn.Web.Controllers
{
    public class CartController : Controller
    {
        const string CartCookieName = "cart";
        readonly CartItem.Factory cartItemFactory;
        readonly IRepository repository;
        readonly AddToCartViewModel.Factory viewModelFactory;

        public CartController(IRepository repository, AddToCartViewModel.Factory viewModelFactory, CartItem.Factory cartItemFactory)
        {
            this.repository = repository;
            this.viewModelFactory = viewModelFactory;
            this.cartItemFactory = cartItemFactory;
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
            return View();
        }
    }
}