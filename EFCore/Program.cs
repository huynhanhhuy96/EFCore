namespace EFCore
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    class Program
    {
        static void Main(string[] args)
        {
            /* Entity -> Database, Table
            Database -> SQL server: EFCore, DbContext
            -- product */

            // DropDatabase();
            // CreateDatabase();

            // InsertData();

            #region Insert, Select, Update, Delete -> CRUD
            // InsertProduct();
            // ReadProduct();
            // RenameProduct(id: 2, newName: "Laptop");
            // DeleteProduct(id: 3);
            #endregion

            // -- Logging

            #region Select
            /*
            using var dbcontext = new ShopContext();
            // var product = (from p in dbcontext.products where p.ProductId == 3 select p).FirstOrDefault();
            var product = dbcontext.products.Select(x => x).Where(x => x.ProductId == 3).FirstOrDefault();
            var e = dbcontext.Entry(product);
            e.Reference(p => p.Category).Load();
            
            product.PrintInfo();

            if (product.Category != null)
            {
                Console.WriteLine($"{product.Category.CategoryName} - {product.Category.Description}");
            }
            else Console.WriteLine("Category == null");
            */

            // using var dbcontext = new ShopContext();

            // var category = dbcontext.categories.Select(x => x).Where(x => x.CategoryId == 2).FirstOrDefault();
            // Console.WriteLine($"{category.CategoryId} - {category.CategoryName}");

            // if (category.Products != null)
            // {
            //     Console.WriteLine($"So san pham: {category.Products.Count()}");
            //     category.Products.ForEach(x => x.PrintInfo());
            // }
            // else Console.WriteLine("Products == null");
            #endregion

            #region Linq test
            using var dbcontext = new ShopContext();

            // dbcontext.products.Find(6).PrintInfo();

            // dbcontext.products.Where(x => x.Price >= 500).ToList().ForEach(x => x.PrintInfo());

            // dbcontext.products.Where(x => x.ProductName.Contains("i")).OrderByDescending(x => x.Price).ToList().ForEach(x => x.PrintInfo());

            // dbcontext.products.Where(x => x.ProductName.Contains("i")).OrderBy(x => x.Price).Take(2).ToList().ForEach(x => x.PrintInfo());

            dbcontext.products.Join(dbcontext.categories, x => x.CateId, c => c.CategoryId, (x, c) => new
            {
                ten = x.ProductName,
                danhmuc = c.CategoryName,
                gia = x.Price
            }).ToList().ForEach(x => Console.WriteLine(x));
            #endregion
        }

        static void CreateDatabase()
        {
            using var dbcontext = new ShopContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;

            var result = dbcontext.Database.EnsureCreated();

            if (result)
                Console.WriteLine($"Tao db {dbname} thanh cong");
            else
                Console.WriteLine($"Khong tao duoc {dbname}");
        }

        static void DropDatabase()
        {
            using var dbcontext = new ShopContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;

            var result = dbcontext.Database.EnsureDeleted();

            if (result)
                Console.WriteLine($"Xoa db {dbname} thanh cong");
            else
                Console.WriteLine($"Khong Xoa duoc {dbname}");
        }

        static void InsertData()
        {
            using var dbcontext = new ShopContext();

            Category c1 = new Category() { CategoryName = "Dien thoai", Description = "Cac loai dien thoai" };
            Category c2 = new Category() { CategoryName = "Do uong", Description = "Cac loai do uong" };

            dbcontext.categories.Add(c1);
            dbcontext.categories.Add(c2);

            // var c1 = (from c in dbcontext.categories where c.CategoryId == 1 select c).FirstOrDefault();
            // var c2 = (from c in dbcontext.categories where c.CategoryId == 2 select c).FirstOrDefault();

            dbcontext.Add(new Product() { ProductName = "Iphone X", Price = 1000, CateId = 1 });
            dbcontext.Add(new Product() { ProductName = "Samsung", Price = 900, Category = c1 });
            dbcontext.Add(new Product() { ProductName = "Ruou vang Abc", Price = 500, Category = c2 });
            dbcontext.Add(new Product() { ProductName = "Nokia Xyz", Price = 600, Category = c1 });
            dbcontext.Add(new Product() { ProductName = "Cafe Abc", Price = 100, Category = c2 });
            dbcontext.Add(new Product() { ProductName = "Nuoc ngot", Price = 50, Category = c2 });
            dbcontext.Add(new Product() { ProductName = "Bia", Price = 200, Category = c2 });

            dbcontext.SaveChanges();
        }
    }
}
