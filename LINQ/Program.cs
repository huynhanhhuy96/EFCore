namespace LINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // LINQ (Languege Integrated Query) : Ngôn ngữ truy vấn tích hợp
    // SQL
    // Nguồn dữ liệu : IEnumable, IEnumable<T>, (Array, List, Stack, Queue ...)
    //                 XML, SQL

    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }         // tên
        public double Price { set; get; }        // giá
        public string[] Colors { set; get; }     // cá màu
        public int Brand { set; get; }           // ID Nhãn hiệu, hãng
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }
        // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
        override public string ToString()
           => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";
    }

    public class Brand
    {
        public string Name { set; get; }
        public int ID { set; get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Product p = new Product(1, "Abc", 1000, new string[] { "Xanh", "Do" }, 2);
            // Console.WriteLine(p);

            var brands = new List<Brand>() {
                new Brand{ID = 1, Name = "Công ty AAA"},
                new Brand{ID = 2, Name = "Công ty BBB"},
                new Brand{ID = 4, Name = "Công ty CCC"},
            };

            var products = new List<Product>(){
                new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };

            int[] numbers = { 1, 2, 7, 4, 9, 4, 5, 2, 3, 4, 2, 5 };

            #region Select
            // products.Select(x => $"{x.Name} ({x.Price})").ToList().ForEach(x => Console.WriteLine(x));
            // products.Select(x => new { Ten = x.Name, Gia = x.Price }).ToList().ForEach(x => Console.WriteLine(x));
            #endregion

            #region  Where
            // products.Where(x => x.Name.Contains("tr")).ToList().ForEach(x => Console.WriteLine(x));
            // products.Where(x => x.Brand == 2).ToList().ForEach(x => Console.WriteLine(x));
            // products.Where(x => x.Price >= 200 && x.Price <= 300).ToList().ForEach(x => Console.WriteLine(x));
            #endregion

            #region SelectMany
            // products.Select(x => x.Colors).ToList().ForEach(x => Console.WriteLine(x));
            // products.SelectMany(x => x.Colors).ToList().ForEach(x => Console.WriteLine(x));
            #endregion

            #region Min, Max, Sum, Average
            // Console.WriteLine(numbers.Max()); // 9
            // Console.WriteLine(numbers.Min()); // 1
            // Console.WriteLine(numbers.Sum()); // 48
            // Console.WriteLine(numbers.Average()); // 4

            // Console.WriteLine(numbers.Where(x => x % 2 == 0).Sum());
            // Console.WriteLine(numbers.Where(x => x % 2 != 0).Sum());

            // Console.WriteLine(products.Min(x => x.Price));
            // Console.WriteLine(products.Average(x => x.Price));
            #endregion

            #region Join, GroupJoin
            // products.Join(brands, p => p.Brand, b => b.ID, (p, b) => new { Ten = p.Name, Thuonghieu = b.Name }).ToList().ForEach(x => Console.WriteLine(x));

            // brands.GroupJoin(products, b => b.ID, p => p.Brand, (brand, pros) => new { Thuonghieu = brand.Name, Cacsanpham = pros }).ToList().ForEach(x => { Console.WriteLine(x.Thuonghieu); x.Cacsanpham.ToList().ForEach(x => Console.WriteLine(x)); });
            #endregion

            #region Take, Skip
            // products.Skip(2).Take(4).ToList().ForEach(x => Console.WriteLine(x));
            #endregion

            #region OrderBy, OrderByDescending
            // products.OrderBy(x => x.Price).ToList().ForEach(x => Console.WriteLine(x));
            // products.OrderByDescending(x => x.Price).ToList().ForEach(x => Console.WriteLine(x));
            // products.OrderByDescending(x => x.Brand).ToList().ForEach(x => Console.WriteLine(x));
            #endregion

            #region Reserse
            // numbers.Reverse().ToList().ForEach(x => Console.WriteLine(x));
            #endregion

            #region GroupBy
            // products.GroupBy(x => x.Price).ToList().ForEach(x => { Console.WriteLine(x.Key); x.ToList().ForEach(x => Console.WriteLine(x)); });
            /// products.GroupBy(x => x.Brand).ToList().ForEach(x => { Console.WriteLine(x.Key); x.ToList().ForEach(x => Console.WriteLine(x)); });
            #endregion

            #region Distinct
            // products.SelectMany(x => x.Colors).Distinct().ToList().ForEach(x => Console.WriteLine(x));
            #endregion

            #region Single, SingleOrDefault - First, FirstOrDefault
            // Console.WriteLine(products.Single(x => x.Price == 600)); // -> 1 result
            // Console.WriteLine(products.Single(x => x.Price == 400)); // 2 result -> exception
            // Console.WriteLine(products.Single(x => x.Price == 1000)); // 0 result -> exception
            // Console.WriteLine(products.SingleOrDefault(x => x.Price == 600)); // -> 1 result
            // Console.WriteLine(products.SingleOrDefault(x => x.Price == 400)); // 2 result -> exception
            // Console.WriteLine(products.SingleOrDefault(x => x.Price == 1000)); // 0 result -> Null (default)

            // Console.WriteLine(products.First(x => x.Price == 600)); // -> 1 result
            // Console.WriteLine(products.First(x => x.Price == 400)); // 2 result -> first result
            // Console.WriteLine(products.First(x => x.Price == 1000)); // 0 result -> exception
            // Console.WriteLine(products.FirstOrDefault(x => x.Price == 600)); // -> 1 result
            // Console.WriteLine(products.FirstOrDefault(x => x.Price == 400)); // 2 result -> first result
            // Console.WriteLine(products.FirstOrDefault(x => x.Price == 1000)); // 0 result -> Null (default)
            #endregion

            #region Any, All
            // Console.WriteLine(products.Any(x => x.Price == 600)); // -> True
            // Console.WriteLine(products.Any(x => x.Price == 1000)); // -> False

            // Console.WriteLine(products.All(x => x.Price >= 200)); // -> True
            // Console.WriteLine(products.All(x => x.Price > 200)); // -> False
            #endregion

            #region Count
            // Console.WriteLine(products.Count(x => x.Price >= 300));
            // Console.WriteLine(products.Count(x => x.Price > 300));
            // Console.WriteLine(products.Count(x => x.Price == 300));
            #endregion

            // -- Lấy sản phẩm giá 400
            // products.Where(x => x.Price == 400).ToList().ForEach(x => Console.WriteLine(x));

            // -- In ra tên sản phẩm, tên thương hiệu, có giá (300 - 400)
            // -- Giá giảm dần
            // products.Where(x => x.Price >= 300 && x.Price <= 400).OrderByDescending(x => x.Price).Join(brands, p => p.Brand, b => b.ID, (p, b) => new { TenSP = p.Name, TenTH = b.Name, Gia = p.Price }).ToList().ForEach(x => Console.WriteLine($"{x.TenSP,15} - {x.TenTH,15} - {x.Gia,15}"));

            /*
                1 - Xác định nguồn: from tenphantu in IEnumable
                    ... join, where, orderby, let tenbien = ??? ...
                2 - Lấy dữ liệu: select, group by ...
            */
            /*
            var qr = from a in products
                     select new
                     {
                         Ten = a.Name,
                         Gia = a.Price,
                         Abc = "asafsafa"
                     };
            qr.ToList().ForEach(x => Console.WriteLine(x));
            */
            /*
            // Các phần tử giá <= 500, mau xanh
            var qr = from x in products
                     from c in x.Colors
                     where x.Price <= 400 && c == "Xanh"
                     orderby x.Price descending
                     select new
                     {
                         Ten = x.Name,
                         Gia = x.Price,
                         Cacmau = x.Colors
                     };
            qr.ToList().ForEach(x => Console.WriteLine($"{x.Ten} - {x.Gia} {string.Join(", ", x.Cacmau)}"));
            */
            /*
            // Đối tượng: Gia, Cacsanpham, Soluong
            var qr = from x in products
                     group x by x.Price into z
                     orderby z.Key
                     let sl = $"Số lượng là: {z.Count()}"
                     select new
                     {
                         Gia = z.Key,
                         Cacsanpham = z.ToList(),
                         Soluong = sl
                     };
            qr.ToList().ForEach(x => { Console.WriteLine(x.Gia); Console.WriteLine(x.Soluong); x.Cacsanpham.ForEach(x => Console.WriteLine(x)); });
            */
            /*
            var qr = from p in products
                     join b in brands on p.Brand equals b.ID into j
                     from i in j.DefaultIfEmpty()
                     select new
                     {
                         Ten = p.Name,
                         Gia = p.Price,
                         Thuonghieu = (i != null) ? i.Name : "No brand"
                     };
            qr.ToList().ForEach(x => Console.WriteLine($"{x.Ten,10} - {x.Thuonghieu,15} - {x.Gia,5}"));
            */
        }
    }
}
