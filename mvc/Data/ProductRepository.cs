using mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Data
{
    public static class ProductRepository
    {
        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product { Id = 1, Name = "Elma", Price = 10, Stock = 50 ,  KategoriId = 1 },
            new Product { Id = 2, Name = "Su", Price = 12, Stock = 40 , KategoriId = 3},
            new Product {Id = 3, Name = "Domates", Price = 15, Stock = 30 , KategoriId = 2}
        };

        public static void Add(Product product)
        {
            if (Products.Any())
                product.Id = Products.Max(p => p.Id) + 1;
            else
                product.Id = 1;

            Products.Add(product);
        }

        public static void Remove(int id)
        {
            var item = Products.FirstOrDefault(p => p.Id == id);
            if (item != null) Products.Remove(item);
        }
    }
}