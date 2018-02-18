//  --------------------------------------------------------------------------------------
// GameOn.Web.CartController.cs
// 2018/02/18
//  --------------------------------------------------------------------------------------

using System.Web.Mvc;
using GameOn.Repository;

namespace GameOn.Web.Controllers
{
    public class CartController : Controller
    {
        readonly IRepository repository;

        public CartController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Add(int productId)
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}