using System.Collections.Generic;
using System.Web.Mvc;

namespace DemoApp.Web.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        private List<CustomerVm> GetCustomers()
        {
            var result = new List<CustomerVm>();
            for (int i = 0; i < 10; i++)
            {
                result.Add(new CustomerVm {FirstName = "foo " + i});
            }
            return result;
        }
    }

    public class CustomerVm
    {
        public string FirstName { get; set; }
    }
}