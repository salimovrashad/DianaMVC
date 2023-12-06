using DianaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DianaMVC.Contexts
{
    public class DianaDBContext : DbContext
    {
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DianaDBContext(DbContextOptions opt) : base(opt) { }
    }
}
