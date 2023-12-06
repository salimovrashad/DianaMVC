using Microsoft.AspNetCore.Mvc;

namespace DianaMVC.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
