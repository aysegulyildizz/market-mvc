
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Data;
using System.Linq;

namespace mvc.ViewComponents
{
    public class UrunListesiViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int? kategoriId = null)
        {
            var urunler = ProductRepository.Products;

            if (kategoriId.HasValue)
            {
                urunler = urunler.Where(p => p.KategoriId == kategoriId.Value).ToList();
            }

            return View(urunler);
        }
    }
}

