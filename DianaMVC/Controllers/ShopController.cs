using Microsoft.AspNetCore.Mvc;

namespace DianaMVC.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
