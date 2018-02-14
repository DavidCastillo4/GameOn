//  --------------------------------------------------------------------------------------
// GameOn.AccountController.cs
// 2018/02/10
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GameOn.Database;
using GameOn.Mapper;
using GameOn.Models;

namespace GameOn.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        // TODO:  Remove this hard-coded value.  Default for the id parameter should be 0.
        public ActionResult Index(int id = 4)
        {
            var repository = new Repository();

            // This is an extremely dangerous pattern to get into - you are taking raw input
            // from the client side and passing it to a stored procedure.  This opens you
            // up to potential sql injection attacks.  Since we're using ADO.NET, it's better
            // to pony up and use the parameterized SqlCommand pattern, which will automatically
            // escape the supplied parameters.
            var query = "spGetAccountInfo @CustomerId=" + id;

            var ds = repository.ReturnDataSet(query);
            // NOTE:  This is an ugly approach necessitated by using raw ADO.NET.  It's another
            // bad pattern to get into.
            if (ds.Tables.Count != 3)
                return HttpNotFound($"Customer id {id} does not exist.");
            var mapper = new CustomerMapper();
            var customer = mapper.Map(ds);
            CreateSelectLists();
            return View(customer);
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            // A POST request (denoted by the HttpPostAttribute above)
            // typically updates a resource on the back-end, so you will
            // want to map your customer to an UPDATE query here.
            // TODO:  Implement ADO.NET code to update the supplied customer in the
            // database.

            // The below line of code will send the user back to the form, displaying
            // the updated data.
            return View(customer);
        }

        public ActionResult Login()
        {
            return View();
        }

        [Authorize]
        public ActionResult RequiresAuthorization()
        {
            return View();
        }

        static IEnumerable<SelectListItem> CreateGendersSelectList()
        {
            var values = new Dictionary<string, string> {{string.Empty, null}, {"M", "Male"}, {"F", "Female"}};
            return values.Select(p => new SelectListItem {Text = p.Value, Value = p.Key});
        }

        static IEnumerable<SelectListItem> CreateMaritalStatusesSelectList()
        {
            var values = new Dictionary<string, string> {{"S", "Single"}, {"M", "Married"}};
            return values.Select(p => new SelectListItem {Text = p.Value, Value = p.Key});
        }

        void CreateSelectLists()
        {
            ViewBag.Genders = CreateGendersSelectList();
            ViewBag.MaritalStatuses = CreateMaritalStatusesSelectList();
        }
    }
}