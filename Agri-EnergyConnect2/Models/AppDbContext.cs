using Microsoft.EntityFrameworkCore;

namespace Agri_EnergyConnect2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Farmers
            modelBuilder.Entity<Farmer>().HasData(
                new Farmer { Id = 1, Name = "John Moyo", Email = "john@aec.com", Password = "Password123" },
                new Farmer { Id = 2, Name = "Grace Banda", Email = "grace@aec.com", Password = "Password123" }
            );

            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Admin One", Email = "employee@aec.com", Password = "AdminPass123" }
            );

            // Seed Products (optional — you can comment these out for now)
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Tomatoes", Category = "Vegetable", ProductionDate = new DateTime(2024, 9, 1), FarmerId = 1 },
                new Product { Id = 2, Name = "Maize", Category = "Grain", ProductionDate = new DateTime(2024, 8, 20), FarmerId = 2 },
                 new Product { Id = 3, Name = "Rice", Category = "Grain", ProductionDate = new DateTime(2025, 1, 1), FarmerId = 1 },
                new Product { Id = 4, Name = "Milk", Category = "Dairy", ProductionDate = new DateTime(2025, 4, 20), FarmerId = 2 },
 new Product { Id = 5, Name = "Bananas", Category = "Fruit", ProductionDate = new DateTime(2025, 5, 1), FarmerId = 1 },
                new Product { Id = 6, Name = "Chicken", Category = "Livestock", ProductionDate = new DateTime(2025, 8, 15), FarmerId = 2 }

            );
        }
    }
}
