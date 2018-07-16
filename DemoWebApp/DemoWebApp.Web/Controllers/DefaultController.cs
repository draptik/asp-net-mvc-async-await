using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DemoWebApp.Web.Controllers
{
    /// <summary>
    /// Currently there is no difference between sync and async.
    /// This is just a basic setup for further investigations.
    /// </summary>
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            var watch = new Stopwatch();
            watch.Start();

            Thread.Sleep(1000);
            var customers = GetCustomers();

            watch.Stop();
            ViewBag.WatchMilliseconds = watch.ElapsedMilliseconds;
            return View(customers);
        }

        public async Task<ActionResult> IndexAsync()
        {
            var watch = new Stopwatch();
            watch.Start();

            var customers = await GetCustomersAsync();

            watch.Stop();
            ViewBag.WatchMilliseconds = watch.ElapsedMilliseconds;
            return View(customers);
        }

        private static List<CustomerVm> GetCustomers()
        {
            var result = new List<CustomerVm>();
            for (int i = 0; i < 10000; i++)
            {
                result.Add(new CustomerVm {FirstName = $"foo {i}"});
            }

            var customers = result;
            return customers;
        }

        private async Task<List<CustomerVm>> GetCustomersAsync()
        {
            await Task.Delay(1000);
            return GetCustomers();
        }
    }

    public class CustomerVm
    {
        public string FirstName { get; set; }
    }
}