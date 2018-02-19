//  --------------------------------------------------------------------------------------
// GameOn.Web.CartController.cs
// 2018/02/18
//  --------------------------------------------------------------------------------------

using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameOn.Repository;
using GameOn.Web.Infrastructure;
using GameOn.Web.ViewModel;

namespace GameOn.Web.Controllers
{
    public class CartController : Controller
    {
        const string CartCookieName = "cart";
        readonly CartSerializer cartSerializer;

        readonly CartListItemViewModel.Factory listItemViewModelFactory;
        readonly IRepository repository;

        readonly AddToCartViewModel.Factory viewModelFactory;

        public CartController(
            IRepository repository,
            AddToCartViewModel.Factory viewModelFactory,
            CartListItemViewModel.Factory listItemViewModelFactory,
            CartSerializer cartSerializer)
        {
            this.repository = repository;
            this.viewModelFactory = viewModelFactory;
            this.listItemViewModelFactory = listItemViewModelFactory;
            this.cartSerializer = cartSerializer;
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
            var cartData = cookie.Value ?? "[]";
            var cart = cartSerializer.Deserialize(cartData);

            var existingItem = cart.Items.FirstOrDefault(p => p.ProductId == viewModel.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += viewModel.Quantity;
            }
            else
            {
                var product = repository.Products.FirstOrDefault(p => p.Id == viewModel.ProductId);
                var itemViewModel = listItemViewModelFactory.Invoke(viewModel.Quantity, product);
                cart.Items.Add(itemViewModel);
            }

            cookie.Value = cartSerializer.Serialize(cart);
            Response.SetCookie(cookie);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {
            var cookie = Request.Cookies[CartCookieName] ?? new HttpCookie(CartCookieName);
            var cartData = cookie.Value ?? "[]";
            var viewModel = cartSerializer.Deserialize(cartData);

            return View(viewModel);
        }
    }
}