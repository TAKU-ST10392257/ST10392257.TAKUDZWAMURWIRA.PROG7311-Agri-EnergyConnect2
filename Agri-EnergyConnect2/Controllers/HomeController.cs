using Microsoft.AspNetCore.Mvc;
using Agri_EnergyConnect2.Models;
using Microsoft.EntityFrameworkCore;

namespace Agri_EnergyConnect2.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Home/Index
        public IActionResult Index()
        {
            // Check the user's role based on session or claims (to be dynamically set after login)
            var userRole = HttpContext.Session.GetString("UserRole"); // Assuming session stores the role

            if (userRole == "Farmer")
            {
                ViewData["Layout"] = "_LayoutFarmer"; // For Farmer
            }
            else if (userRole == "Employee")
            {
                ViewData["Layout"] = "_LayoutEmployee"; // For Employee
            }
            else
            {
                ViewData["Layout"] = "_Layout"; // Default layout (non-logged-in user or initial state)
            }

            return View();
        }

        // GET: /Home/FarmerLogin
        public IActionResult FarmerLogin()
        {
            return View();
        }

        // POST: /Home/FarmerLogin
        [HttpPost]
        public IActionResult FarmerLogin(string email, string password)
        {
            var farmer = _context.Farmers.FirstOrDefault(f => f.Email == email && f.Password == password);
            if (farmer != null)
            {
                // Store the Farmer ID in the session and set the role
                HttpContext.Session.SetInt32("FarmerId", farmer.Id);
                HttpContext.Session.SetString("UserRole", "Farmer");

                return RedirectToAction("MyProducts", "Farmer"); // Redirect to Farmer-specific page
            }

            // Invalid login credentials, show an error message
            ViewBag.Error = "Invalid credentials.";
            return View();
        }

        // GET: /Home/EmployeeLogin
        public IActionResult EmployeeLogin()
        {
            return View();
        }

        // POST: /Home/EmployeeLogin
        [HttpPost]
        public IActionResult EmployeeLogin(string email, string password)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Email == email && e.Password == password);
            if (employee != null)
            {
                // Store the Employee ID in the session and set the role
                HttpContext.Session.SetInt32("EmployeeId", employee.Id);
                HttpContext.Session.SetString("UserRole", "Employee");

                return RedirectToAction("Farmers", "Employee"); // Redirect to Employee-specific page
            }

            // Invalid login credentials, show an error message
            ViewBag.Error = "Invalid credentials.";
            return View();
        }

        // Logout action, clears the session and redirects to the home page
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear all session data
            return RedirectToAction("Index"); // Redirect to the index page after logout
        }
    }
}
