using Microsoft.AspNetCore.Mvc;
using Agri_EnergyConnect2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Agri_EnergyConnect2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Employee/Farmers
        public IActionResult Farmers()
        {
           

            var farmers = _context.Farmers.ToList();
            return View(farmers);
        }

        // GET: /Employee/FarmerProfile/5
        public IActionResult FarmerProfile(int id)
        {
            

            var farmer = _context.Farmers.Include(f => f.Products).FirstOrDefault(f => f.Id == id);
            if (farmer == null) return NotFound();

            return View(farmer);
        }

        // GET: /Employee/AllProducts
        public IActionResult AllProducts(string category, DateTime? productionDate)
        {
            

            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category.Contains(category));
            }

            if (productionDate.HasValue)
            {
                products = products.Where(p => p.ProductionDate == productionDate.Value);
            }

            return View(products.ToList());
        }

        // GET: /Employee/AddFarmer
        public IActionResult AddFarmer()
        {
            

            return View();
        }

        // POST: /Employee/AddFarmer
        [HttpPost]
        public IActionResult AddFarmer(Farmer farmer)
        {
          

            if (ModelState.IsValid)
            {
                _context.Farmers.Add(farmer);
                _context.SaveChanges();
                return RedirectToAction("Farmers");
            }

            return View(farmer);
        }
    }
}
