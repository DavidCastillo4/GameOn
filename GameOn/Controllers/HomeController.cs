//  --------------------------------------------------------------------------------------
// slnGameOn.HomeController.cs
// 2018/02/09
//  --------------------------------------------------------------------------------------

using System.Web.Mvc;
using GameOn.Database;
using GameOn.Mapper;
using GameOn.Models;

namespace GameOn.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string btSubmit)
        {
            var ModelCust = new Customer(6);
            return View("Cart", ModelCust);
        }

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult OrderHistory()
        {
            return View();
        }
    }
}