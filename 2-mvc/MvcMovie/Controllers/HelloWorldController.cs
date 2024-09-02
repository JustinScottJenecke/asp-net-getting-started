using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorldController
        // public ActionResult Index()
        // {
        //     return View();
        // }

        public IActionResult Index()
        {
            // return "This is my default action.";
            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["message"] = $"Welcome {name} ";
            ViewData["NumTimes"] = numTimes;

            // if (String.IsNullOrEmpty(name))
            // {
            //     return $"Welcome action method return value";  
            // }
            // return HtmlEncoder.Default.Encode($"Welcome {name}, num of times is {numTimes}");
            return View();
        }

    }
}
