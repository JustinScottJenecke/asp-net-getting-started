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

        public string Index()
        {
            return "This is my default action.";
        }

        public string Welcome(string? name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return $"Welcome action method";                 
            }

            return $"Welcome {name}";  
        }

    }
}
