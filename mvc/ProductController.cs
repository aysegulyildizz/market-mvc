using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvc.Controllers
{
    public class ProductController : Controller
    {
        // Ürün listesini gösterir
        public IActionResult Index()
        {
            var products = ProductRepository.Products;
            return View(products);
        }

        // Yeni ürün ekleme formu (GET)
        [HttpGet]
        public IActionResult Create()
        {
            
            ViewBag.Kategoriler = new SelectList(KategoriRepository.Kategoriler, "Id", "Name");

            return View();
        }

        // Yeni ürün ekleme işlemi (POST)
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            ProductRepository.Add(product);
            return RedirectToAction("Index");
        }

        // Ürün silme
        public IActionResult Delete(int id)
        {
            ProductRepository.Remove(id);
            return RedirectToAction("Index");
        }

        // Ürün arama
        [HttpGet]
        public IActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction("Index");
            }

            var results = ProductRepository.Products
                .Where(p => p.Name.ToLower().Contains(query.ToLower()))
                .ToList();

            return View("Index", results);
        }
    }
}