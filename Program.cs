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

            // CreateDatabase();
            // DropDatabase();

            // -- Insert, Select, Update, Delete -> CRUD
            // InsertProduct();
            // ReadProduct();
            // RenameProduct(id: 2, newName: "Laptop");
            // DeleteProduct(id: 3);

            // -- Logging
        }

        static void CreateDatabase()
        {
            using var dbcontext = new ProductDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;

            var result = dbcontext.Database.EnsureCreated();

            if (result)
                Console.WriteLine($"Tao db {dbname} thanh cong");
            else
                Console.WriteLine($"Khong tao duoc {dbname}");
        }

        static void DropDatabase()
        {
            using var dbcontext = new ProductDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;

            var result = dbcontext.Database.EnsureDeleted();

            if (result)
                Console.WriteLine($"Xoa db {dbname} thanh cong");
            else
                Console.WriteLine($"Khong Xoa duoc {dbname}");
        }

        static void InsertProduct()
        {
            using var dbcontext = new ProductDbContext();

            /*
            - Model (Product)
            - Add, AddAysc
            - SaveChange
            */

            /*
            // Add Product
            var p1 = new Product();
            p1.ProductName = "San pham 1";
            p1.Provider = "Cong ty 1";

            dbcontext.Add(p1);
            */

            // Add multi Product
            var product = new Product[]{
                new Product() {ProductName ="San pham 1", Provider = "CTY A"},
                new Product() {ProductName ="San pham 2", Provider = "CTY B"},
                new Product() {ProductName ="San pham 3", Provider = "CTY C"},
            };

            dbcontext.AddRange(product);

            int numberRows = dbcontext.SaveChanges();
            Console.WriteLine($"Da chen {numberRows} du lieu");
        }

        static void ReadProduct()
        {
            using var dbcontext = new ProductDbContext();

            // Linq
            var products = dbcontext.products.ToList();
            products.ForEach(x => x.PrintInfo());

            /*
            var query = from Product in dbcontext.products
                        where Product.Provider.Contains("CTY")
                        orderby Product.ProductId descending
                        select Product;

            query.ToList().ForEach(x => x.PrintInfo());
            */

            /*
            Product product = (from p in dbcontext.products
                               where p.Provider == "CTY A"
                               select p).FirstOrDefault();
            if (product != null)
                product.PrintInfo();
            */
        }

        static void RenameProduct(int id, string newName)
        {
            using var dbcontext = new ProductDbContext();

            Product product = (from p in dbcontext.products
                               where p.ProductId == id
                               select p).FirstOrDefault();

            if (product != null)
            {
                /*
                product -> DbContext
                EntityEntry<Product> entry = dbcontext.Entry(product);
                entry.State = EntityState.Detached;
                */

                product.ProductName = newName;
                int numberRows = dbcontext.SaveChanges();
                Console.WriteLine($"Cap nhap {numberRows} du lieu");
            }
        }

        static void DeleteProduct(int id)
        {
            using var dbcontext = new ProductDbContext();

            Product product = (from p in dbcontext.products
                               where p.ProductId == id
                               select p).FirstOrDefault();

            if (product != null)
            {
                dbcontext.Remove(product);

                int numberRows = dbcontext.SaveChanges();
                Console.WriteLine($"Xoa {numberRows} du lieu");
            }
        }
    }
}
