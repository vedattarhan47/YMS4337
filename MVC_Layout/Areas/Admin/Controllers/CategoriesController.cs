using MVC_Layout.Areas.Admin.Models;
using System.Linq;
using System.Web.Mvc;
namespace MVC_Layout.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult _Index()
        {
            var categories = db.Categories.Select(x => new
            {
                x.CategoryID,
                x.CategoryName,
                x.Description
            }).ToList();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
         
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Category category)
        {
            string[] message = { "false", "Kategori Ekleme Hatası!" };
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                bool result = db.SaveChanges() > 0;
                if (result)
                {
                    message[0] = "true";
                    message[1] = "Kategori Başarıyla Eklendi!";
                }
            }

            ViewBag.Message = message;
            return View();
        }
    }
}