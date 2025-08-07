

using mvc.Models;
using System.Collections.Generic;
using System.Linq;
using mvc.Data;

namespace mvc.Data
{
    public static class KategoriRepository
    {
        public static List<Kategori> Kategoriler { get; set; } = new List<Kategori>
        {
            new Kategori { Id = 1, Name = " Fruits " },
            new Kategori { Id = 2, Name = " Vegetables" },
            new Kategori { Id = 3, Name = " Drinks " }
        };

        public static void Add(Kategori kategori)
        {
            if (Kategoriler.Any())
                kategori.Id = Kategoriler.Max(k => k.Id) + 1;
            else
                kategori.Id = 1;

            Kategoriler.Add(kategori);
        }

        public static void Remove(int id)
        {
            var item = Kategoriler.FirstOrDefault(k => k.Id == id);
            if (item != null) Kategoriler.Remove(item);
        }
    }
}
