using Microsoft.AspNetCore.Mvc;

namespace DianaMVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
