using mvc.Data;
using mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers.ViewComponents
{
    public class KategoriListeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            
            var kategoriler = KategoriRepository.Kategoriler;
            return View(kategoriler);
        }
    }
}