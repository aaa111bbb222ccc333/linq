using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CarLibrary;

namespace linq
{
    public class ProductInfo
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberInStock { get; set; }
    }

    class Program
    {
        static void Main()
        {
            /*
            int[] numbers = new int[] { 10, 20, 30, 40, 1, 2, 3, 8 };

            // List<int>
            var subset = (from i in numbers where i < 10 select i); // ToList()

            foreach (var el in subset)
            {
                Console.Write($"{el}  ");
            }

            numbers[0] = -1;

            Console.WriteLine();

            foreach (var el in subset)
            {
                Console.Write($"{el}  ");
            }
            */


            /*
            object[] objects = new object[] { 1, "2", 3.0, "4", "5" };

            foreach (var el in objects.OfType<string>())
            {
                Console.Write($"{el}  ");
            }
            */


            /*
            ProductInfo[] itemsInStock = new ProductInfo[] { new ProductInfo { Name = "Coffee", NumberInStock = 24, Description = "111111" },
                                                             new ProductInfo { Name = "Water", NumberInStock = 100, Description = "222222" },
                                                             new ProductInfo { Name = "Pizza", NumberInStock = 73, Description = "333333" } };

            var allProducts = from i in itemsInStock select i;

            foreach (var product in allProducts)
            {
                Console.WriteLine(product.Name);
            }

            var names = from i in itemsInStock select i.Name;

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            var overstock = from i in itemsInStock where i.NumberInStock > 25 select i;

            foreach (var product in overstock)
            {
                Console.WriteLine($"{product.Name} {product.NumberInStock}");
            }

            Console.WriteLine();



            var nameDesc = from i in itemsInStock where i.NumberInStock > 25 select new { i.Name, i.NumberInStock };

            foreach (var product in nameDesc)
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine();

            itemsInStock[0].NumberInStock = 1000;

            foreach (var product in nameDesc)
            {
                Console.WriteLine(product.Name);
            }
            */



            /*
            List<int> nums = new List<int> { 1, 5, -44 };

            int count = (from n in nums where n > 5 select n).Count();

            Console.WriteLine(count);

            Console.WriteLine();

            var sorted1 = from n in nums orderby n descending select n;

            foreach (var el in sorted1)
            {
                Console.WriteLine(el);
            }

            Console.WriteLine();

            var sorted2 = nums.OrderByDescending(n => n);

            foreach (var el in sorted2)
            {
                Console.WriteLine(el);
            }

            Console.WriteLine();

            nums.Add(1000);

            foreach (var el in sorted1)
            {
                Console.WriteLine(el);
            }

            Console.WriteLine();

            foreach (var el in sorted2)
            {
                Console.WriteLine(el);
            }

            LazyShit ls = new LazyShit();

            Console.WriteLine(ls.Products.IsValueCreated);

            List<ProductInfo> prods = ls.Products.Value;

            Console.WriteLine(ls.Products.IsValueCreated);

            /*
            ProductInfo[] arr = new ProductInfo[10];
            Console.WriteLine(arr[5]?.Description ?? "it's null");

            Point[] pArr = new Point[10];

            Console.WriteLine($"{pArr[5].X} {pArr[5].Y}");

            string[] strArr = new string[10];

            Console.WriteLine(strArr[5] ?? "null too");

            Console.WriteLine();

            ProductInfo pInfo = new ProductInfo { Name = "" };

            Console.WriteLine(pInfo.Description ?? "Null");

            Console.WriteLine(pInfo.Name ?? "Null");

            Console.WriteLine(pInfo.NumberInStock);
            */

            /*
            foreach (var pr in prods)
            {
                Console.WriteLine($"{pr.Name} {pr.NumberInStock} {pr.Description}");
            }
            */


            var propNames = from p in typeof(ProductInfo).GetProperties() select p.Name;

            foreach (var name in propNames)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            var interfaceNames = from i in typeof(List<int>).GetInterfaces() select i.Name;

            foreach (var name in interfaceNames)
            {
                Console.WriteLine(name);
            }

            try
            {
                Assembly asm = Assembly.Load("CarLibrary");

                foreach (var type in asm.GetTypes())
                {
                    Console.WriteLine($"{type.Name}, IsAbstract: {type.IsAbstract}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 1
            foreach (var attr in typeof(MiniVan).GetCustomAttributes(false))
            {
                if (attr is VehicleDescriptionAttribute descriptionAttribute)
                {
                    Console.WriteLine(descriptionAttribute.Description);
                }
                else
                {
                    Console.WriteLine(attr.ToString());
                }
            }

            // 2
            foreach (var descriptionAttribute in typeof(MiniVan).GetCustomAttributes(false).OfType<VehicleDescriptionAttribute>())
            {
                Console.WriteLine(descriptionAttribute.Description);
            }

            // 3
            foreach (VehicleDescriptionAttribute attr in typeof(MiniVan).GetCustomAttributes(typeof(VehicleDescriptionAttribute), false))
            {
                Console.WriteLine(attr.Description);
            }

        }

        public struct Point
        {
            public int X { get; set; }

            public int Y { get; set; }
        }

        public class LazyShit
        {
            public Lazy<List<ProductInfo>> Products { get; set; } = new Lazy<List<ProductInfo>>(() =>
            {
                List<ProductInfo> products = new List<ProductInfo>();

                for (int i = 0; i < 10000; i++)
                {
                    products.Add(new ProductInfo { Name = i.ToString(), NumberInStock = i, Description = i.ToString() });
                }

                return products;
            }
            );
        }
    }
}
