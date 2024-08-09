using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using UrumsalWeb.Models;
using UrumsalWeb.Models.DataContext;
using UrumsalWeb.Models.Model;

namespace UrumsalWeb.Controllers
{
    public class AdminController : Controller
    {
        UrumsalDBContext db = new UrumsalDBContext();

        // GET: Admin
        public ActionResult Index()
        {
            var sorgu = db.Kategori.ToList();
            return View(sorgu);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login = db.Admin.Where(x => x.Eposta == admin.Eposta && x.Sifre == admin.Sifre).SingleOrDefault();
            if (login == null)
            {
                ViewBag.Uyari = "Kullanıcı adı ya da şifre yanlış";
                return View(admin);
            }

            Session["adminid"] = login.AdminId;
            Session["eposta"] = login.Eposta;
            return RedirectToAction("Index", "Admin");

        }
        public ActionResult Logout()
        {
            Session["adminid"] = null;
            Session["eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");



        }
    }
}