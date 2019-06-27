namespace MVC_Layout.Areas.Admin.Controllers
{
    using MVC_Layout.Areas.Admin.Models;
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    public class AccountsController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            if (Request.Cookies.AllKeys.Contains("login"))
            {  
                var requested_cookie = Request.Cookies["login"];
                LoginVM vm = new LoginVM();
                vm.Email = requested_cookie.Values["username"];
                vm.Password = requested_cookie.Values["password"];
                vm.IsPersistant = true;
                return View(vm);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, model.IsPersistant);
                    HttpCookie cookie = new HttpCookie("login");
                    if (model.IsPersistant)
                    {
                        cookie.Values.Add("username", model.Email);
                        cookie.Values.Add("password", model.Password);
                    }
                    else
                    {
                        cookie.Expires = DateTime.Now.AddDays(-1);
                    }
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Accounts");
        }
    }
}