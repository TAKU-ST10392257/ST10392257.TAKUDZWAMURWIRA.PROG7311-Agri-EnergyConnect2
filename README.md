# 🌱 Agri-EnergyConnect2

Agri-EnergyConnect2 is an ASP.NET Core MVC web application built with .NET 9 and Entity Framework Core. It serves as a platform for managing agricultural products between two user roles: **Farmers** and **Employees**. The application uses a local SQL Server database (`MSSQLLocalDB`).

---

## 🧱 Tech Stack

- **.NET 9**
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **MSSQLLocalDB**
- **Visual Studio 2022**
- **Razor Views**
- **Gruvbox-inspired Olive Grove theme**

---

## 👥 User Roles

- **Farmer**
  - Add products (name, category, production date)
  - View only their own products
- **Employee**
  - Add and manage farmer profiles
  - View products from all farmers
  - Filter products by category or production date

---

## 🚀 Getting Started

### 1. Clone the repository
```bash
git clone https://github.com/your-username/Agri-EnergyConnect2.git
cd Agri-EnergyConnect2
```

### 2. Open in Visual Studio 2022
Launch `Agri-EnergyConnect2.sln` in Visual Studio 2022.

### 3. Configure the database
Ensure your `appsettings.json` contains the following connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AgriEnergyConnect2Db;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### 4. Restore NuGet packages
In Visual Studio:
```
Tools > NuGet Package Manager > Package Manager Console
```
Then run:
```powershell
Update-Package -reinstall
```

### 5. Apply EF Core Migrations
```powershell
Update-Database
```

> This will create the database using the seeded data if available.

### 6. Run the application
Press `F5` or click the green “Run” button in Visual Studio.

---

## 🧪 Sample Accounts

If the system uses seeded farmer and employee accounts, they will be listed here for testing. If not, users can enter directly through the homepage role selector.

---

## 🎨 Styling

The application uses a light mode **Olive Grove** theme inspired by the Gruvbox color palette, with:
- Fonts: **Merriweather** (headings), **Lato** (body)
- Color accents in sage green, clay, and charcoal

---

## 📂 Project Structure Overview

```
Agri-EnergyConnect2/
│
├── Controllers/
│   ├── FarmerController.cs
│   └── EmployeeController.cs
│
├── Models/
│   ├── Farmer.cs
│   ├── Product.cs
│   └── ViewModels/
│
├── Views/
│   ├── Farmer/
│   ├── Employee/
│   ├── Shared/
│   └── _Layout.cshtml
│
├── Data/
│   ├── ApplicationDbContext.cs
│   └── SeedData.cs
│
├── wwwroot/
│   ├── css/
│   │   └── olive-grove.css
│   └── lib/
│
├── appsettings.json
├── Program.cs
└── Agri-EnergyConnect2.csproj
```

---

## ❗ Notes

- Make sure `.NET 9 SDK` is installed on your machine.
- You must be using **Visual Studio 2022 (v17.8 or later)** for .NET 9 compatibility.
- If errors occur with migrations, ensure your database is deleted and re-run `Update-Database`.
- Farmer logins:
  Email:john@aec.com
  Password: Password123

  Email:john@aec.com
  Password: Password123

- Admin Login
  Email:employee@aec.com
  Password:AdminPass123 

## REFERENCES
This project was completed with the help of the following links

https://learn.microsoft.com/en-us/ef/core/cli/powershell

https://learn.microsoft.com/en-us/ef/core/

https://www.youtube.com/watch?v=gNvuZTg0H1k&list=LL&index=35&t=743s&ab_channel=%F0%9D%90%82%F0%9D%90%A8%F0%9D%90%9D%F0%9D%90%9E%F0%9D%90%96%F0%9D%90%A2%F0%9D%90%AD%F0%9D%90%A1%F0%9D%90%86%F0%9D%90%A8%F0%9D%90%A9%F0%9D%90%A2

With assitance from chatgpt.com when i ran into errors or needed help.
