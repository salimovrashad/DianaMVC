using DianaMVC.Contexts;
using DianaMVC.Models;
using DianaMVC.ViewModels.SliderVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DianaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        DianaDBContext _db { get; }
        public SliderController(DianaDBContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _db.Sliders.Select(s => new SliderListItemVM
            {
                ImageUrl = s.ImageUrl,
                Title = s.Title,
                Description = s.Description,
                Id = s.Id,

            }).ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(SliderCreateItemVM vm)
        {
            Slider slider = new Slider
            {
                Title = vm.Title,
                Description = vm.Description,
                ImageUrl = vm.ImageUrl,
            };
            await _db.AddAsync(slider);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.Sliders.FindAsync(id);
            _db.Remove(item);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var item = await _db.Sliders.FindAsync(id);
            return View(new SliderUpdateItemVM
            {
                Description = item.Description,
                ImageUrl= item.ImageUrl,
                Title= item.Title,
            });
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, SliderUpdateItemVM vm)
        {
            var data = await _db.Sliders.FindAsync(id);
            data.Description = vm.Description;
            data.ImageUrl = vm.ImageUrl;
            data.Title = vm.Title;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
