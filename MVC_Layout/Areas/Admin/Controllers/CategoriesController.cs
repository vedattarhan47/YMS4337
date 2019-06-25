using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Layout.Areas.Admin.Models;
namespace MVC_Layout.Areas.Admin.Controllers
{
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
    }
}