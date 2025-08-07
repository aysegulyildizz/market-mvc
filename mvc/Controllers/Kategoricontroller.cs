using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;
using System.Linq;

namespace mvc.Controllers
{
    public class KategoriController : Controller
    {
        public IActionResult Detay(int id)
        {
            return ViewComponent("KategoriListe", new { kategoriId = id });
        }
        
        // Kategori listesini göster
        public IActionResult Index()
        {
            var kategoriler = KategoriRepository.Kategoriler;
            return View(kategoriler);
        }

        // Yeni kategori ekleme formu (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Yeni kategori ekleme işlemi (POST)
        [HttpPost]
        public IActionResult Create(Kategori kategori)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(kategori.Name))
            {
                ModelState.AddModelError("", "Kategori adı boş olamaz.");
                return View(kategori);
            }

            KategoriRepository.Add(kategori);
            return RedirectToAction("Index");
        }

        // Kategori silme
        public IActionResult Delete(int id)
        {
            KategoriRepository.Remove(id);
            return RedirectToAction("Index");
        }

        // Kategori arama
        [HttpGet]
        public IActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction("Index");
            }

            var results = KategoriRepository.Kategoriler
                .Where(k => k.Name.ToLower().Contains(query.ToLower()))
                .ToList();

            return View("Index", results);
        }
    }
}
