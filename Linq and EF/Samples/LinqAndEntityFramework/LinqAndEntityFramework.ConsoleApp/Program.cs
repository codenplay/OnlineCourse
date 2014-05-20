﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAndEntityFramework.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = DataProvider.GetProducts();
            var list = (from product in products
                where product.Price > 10
                orderby product.Price
                select
                    new // type?? annonymous type. 
                    {
                        Name = product.Name,
                        Code = product.Code,
                        Price = product.Price,
                        Category = product.Category.Name,
                        Group = product.Category.Group.Name
                    }
                ).ToList();


            double sum = list.Sum(v => v.Price);
            int count = list.Count;
            double d = list.Sum(p=>p.Price);
            double max = list.Max(p => p.Price);
            double min = list.Min(l => l.Price);

            Product first = products.First(p => p.Id == 10);

            Console.WriteLine("Product: " + first.Name + "Category: " + first.Category.Name);
            Console.Read();
        }
    }
}
