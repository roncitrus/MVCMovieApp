using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Welcome(string name, int numtimes = 1)
        {
            ViewData["Message"] = "Hello " + name;  // Viewdata is a dynamic (any Type) dictionary object, empty until you add to it.
            ViewData["NumTimes"] = numtimes; // Viewdata will get passed to the View.
            return View();
         }
    }
}
// Every public method in a controller is callable as an HTTP endpoint. In the sample above, both methods return a string.