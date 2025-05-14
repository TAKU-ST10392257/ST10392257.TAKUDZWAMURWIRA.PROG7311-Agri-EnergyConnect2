using Microsoft.AspNetCore.Mvc;
using Agri_EnergyConnect2.Models;
using Microsoft.EntityFrameworkCore;

namespace Agri_EnergyConnect2.Controllers
{
    public class FarmerController : Controller
    {
        private readonly AppDbContext _context;

        public FarmerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Farmer/MyProducts
        public IActionResult MyProducts()
        {
            // Get the logged-in farmer's ID from the session
            var farmerId = HttpContext.Session.GetInt32("FarmerId");
            if (farmerId == null) return RedirectToAction("Index", "Home");

            // Get the farmer's products
            var products = _context.Products.Where(p => p.FarmerId == farmerId).ToList();
            return View(products);
        }

        // GET: /Farmer/AddProduct
        public IActionResult AddProduct()
        {
            return View();
        }

        // POST: /Farmer/AddProduct
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var farmerId = HttpContext.Session.GetInt32("FarmerId");
            if (farmerId == null) return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                // Set the farmer's ID for the product
                product.FarmerId = farmerId.Value;

                // Add the product to the database
                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction("MyProducts");
            }

            return View(product);
        }
    }
}
