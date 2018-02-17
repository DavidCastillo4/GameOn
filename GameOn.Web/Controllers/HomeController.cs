//  --------------------------------------------------------------------------------------
// GameOn.Web.HomeController.cs
// 2018/02/16
//  --------------------------------------------------------------------------------------

using System.Linq;
using System.Web.Mvc;
using GameOn.Repository;
using GameOn.Web.ViewModel;

namespace GameOn.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly IRepository repository;
        readonly BrowseViewModel.Factory browseViewModelFactory;

        public HomeController(IRepository repository, BrowseViewModel.Factory browseViewModelFactory)
        {
            this.repository = repository;
            this.browseViewModelFactory = browseViewModelFactory;
        }

        // GET: Home
        // This is the default page for this controller.  Since this is
        // the default controller for the application, this can be considered
        // the 'home' page (i.e. what the user first sees when visiting the domain)
        public ActionResult Index()
        {
            var allProducts = repository.Products;
            var viewModel = browseViewModelFactory.Invoke(allProducts);
            return View(viewModel);
        }

        public ActionResult ProductDetails(int productId)
        {
            var product = repository.Products.FirstOrDefault(p => p.Id == productId);
            return View(product);
        }
    }
}