//  --------------------------------------------------------------------------------------
// GameOn.Web.CartController.cs
// 2018/02/18
//  --------------------------------------------------------------------------------------

using System.Web.Mvc;

namespace GameOn.Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
    }
}