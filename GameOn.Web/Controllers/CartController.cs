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
        readonly CartRepository cartRepository;
        readonly CartSerializer cartSerializer;

        readonly IRepository repository;

        readonly AddToCartViewModel.Factory viewModelFactory;

        public CartController(IRepository repository, AddToCartViewModel.Factory viewModelFactory, CartSerializer cartSerializer, CartRepository cartRepository)
        {
            this.repository = repository;
            this.viewModelFactory = viewModelFactory;
            this.cartSerializer = cartSerializer;
            this.cartRepository = cartRepository;
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
            AddItemToCart(viewModel, cartData, cookie);
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

        void AddItemToCart(AddToCartViewModel viewModel, string cartData, HttpCookie cookie)
        {
            var cart = cartSerializer.Deserialize(cartData);
            cart = cartRepository.AddItem(cart, viewModel.ProductId, viewModel.Quantity);
            cookie.Value = cartSerializer.Serialize(cart);
        }
    }
}