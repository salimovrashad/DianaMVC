using DianaMVC.Contexts;
using DianaMVC.Models;
using DianaMVC.ViewModels.ProductVM;
using DianaMVC.ViewModels.SliderVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DianaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        DianaDBContext _db { get; }
        public ProductController(DianaDBContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _db.Products.Select(p => new ProductListItemVM
            {
                Description = p.Description,
                Size = p.Size,
                Color = p.Color,
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Price = p.Price,
            }).ToListAsync();
            return View(items);
        }

        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(ProductCreateItemVM vm)
        {
            Product product = new Product
            {
                Color = vm.Color,
                Size = vm.Size,
                Description = vm.Description,
                ImageUrl= vm.ImageUrl,
                Name = vm.Name,
                Price = vm.Price,
            };
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = _db.Products.Find(id);
            _db.Remove(item);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var item = _db.Products.Find(id);
            return View(new ProductUpdateItemVM
            {
                Color = item.Color,
                Size = item.Size,
                Description = item.Description,
                ImageUrl= item.ImageUrl,
                Name = item.Name,
                Price = item.Price,
            });
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, ProductUpdateItemVM vm)
        {
            var item = await _db.Products.FindAsync(id);
            item.Color = vm.Color;
            item.Size = vm.Size;
            item.Description = vm.Description;
            item.ImageUrl = vm.ImageUrl;
            item.Name = vm.Name;
            item.Price = vm.Price;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
