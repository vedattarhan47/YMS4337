using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Layout.Controllers
{
    using MVC_Layout.Areas.Admin.Models;
    public class ProductsController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public JsonResult _GetProducts()
        {
            var products = db.Products.Select(x => new
            {
                x.ProductID    ,
                x.ProductName  ,
                x.UnitPrice    ,
                x.UnitsInStock ,
                ImageUrl = "/Content/images/shop/products/14.jpg"
            }).ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}