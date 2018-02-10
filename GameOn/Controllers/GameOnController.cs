//  --------------------------------------------------------------------------------------
// slnGameOn.GameOnController.cs
// 2018/02/09
//  --------------------------------------------------------------------------------------

using System.Web.Mvc;
using GameOn.Database;
using GameOn.Mapper;
using GameOn.Models;

namespace GameOn.Controllers
{
    public class GameOnController : Controller
    {
        public ActionResult Account()
        {
            var repository = new Repository();
            var customerId = 4;
            var query = "spGetAccountInfo @CustomerId=" + customerId;

            var ds = repository.ReturnDataSet(query);

            var mapper = new CustomerMapper();
            var customer = mapper.Map(ds);
            
            return View(customer);
        }

        [HttpPost]
        public ActionResult Account(string btSubmit)
        {
            var Ctr = "";
            var ModelCust = new Customer(6);
            return View("Account", ModelCust);
        }

        public ActionResult Browse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Browse(string btSubmit)
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