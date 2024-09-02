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

        public string Welcome(string name, int numTimes = 1)
        {
            if (String.IsNullOrEmpty(name))
            {
                return $"Welcome action method return value";  
            }
            return HtmlEncoder.Default.Encode($"Welcome action method, num of times is {numTimes}");
        }

    }
}
