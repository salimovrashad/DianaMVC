using DianaMVC.Contexts;
using DianaMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DianaMVC.Controllers
{
    public class HomeController : Controller
    {
        DianaDBContext _db { get; }
        public HomeController(DianaDBContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            Class class1 = new Class();
            var sliders = await _db.Sliders.ToListAsync();
            var products = await _db.Products.ToListAsync();
            class1.products = products;
            class1.sliders = sliders;
            return View(class1);
        }
    }
}
