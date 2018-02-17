//  --------------------------------------------------------------------------------------
// GameOn.Web.HomeController.cs
// 2018/02/16
//  --------------------------------------------------------------------------------------

using System.Linq;
using System.Web.Mvc;
using GameOn.Repository;

namespace GameOn.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly IRepository repository;

        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: Home
        // This is the default page for this controller.  Since this is
        // the default controller for the application, this can be considered
        // the 'home' page (i.e. what the user first sees when visiting the domain)
        public ActionResult Index()
        {
            var allProducts = repository.Products;
            return View(allProducts);
        }

        public ActionResult ProductDetails(int productId)
        {
            var product = repository.Products.FirstOrDefault(p => p.Id == productId);
            return View(product);
        }
    }
}