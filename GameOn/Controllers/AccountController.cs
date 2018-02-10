//  --------------------------------------------------------------------------------------
// GameOn.AccountController.cs
// 2018/02/10
//  --------------------------------------------------------------------------------------

using System.Web.Mvc;
using GameOn.Database;
using GameOn.Mapper;
using GameOn.Models;

namespace GameOn.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index(int id)
        {
            var repository = new Repository();

            // This is an extremely dangerous pattern to get into - you are taking raw input
            // from the client side and passing it to a stored procedure.  This opens you
            // up to potential sql injection attacks.  Since we're using ADO.NET, it's better
            // to pony up and use the parameterized SqlCommand pattern, which will automatically
            // escape the supplied parameters.
            var query = "spGetAccountInfo @CustomerId=" + id;

            var ds = repository.ReturnDataSet(query);

            var mapper = new CustomerMapper();
            var customer = mapper.Map(ds);

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
    }
}