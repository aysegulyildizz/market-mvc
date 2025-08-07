
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace mvc.Controllers
{
    public class FolderController : Controller
    {
        public IActionResult List()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            var files = directoryInfo.GetFiles();
            return View(files);
        }

        public IActionResult Delete(string name)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", name);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            return RedirectToAction("List");
        }
    }
}


