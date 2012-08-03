using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackExchange.Profiling;
using System.Threading;

namespace ModernizrTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var profiler = MiniProfiler.Current; // it's ok if this is null
            using (profiler.Step("Init"))
            {
                ViewBag.Message = "Welcome to ASP.NET MVC!";
            }
            using (profiler.Step("A"))
            {
                using (profiler.Step("Step A"))
                { // something more interesting here
                    Thread.Sleep(100);
                }
                using (profiler.Step("Step B"))
                { // and here
                    Thread.Sleep(250);
                }
            }
            

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
