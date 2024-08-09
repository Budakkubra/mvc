using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrumsalWeb.Models.DataContext;

namespace UrumsalWeb.Controllers
{
    public class HomeController : Controller
    {
        private UrumsalDBContext db=new UrumsalDBContext();
        // GET: Home
        public ActionResult Index()
        {

            ViewBag.Hizmetler=db.Hizmet.ToList().OrderByDescending(x=>x.HizmetId);
           
            ViewBag.Hizmetler = db.Hizmet.ToList().OrderByDescending(x => x.HizmetId);
            ViewBag.Hakkimizdaa = db.Hakkimizda.ToList().OrderByDescending(x => x.HakkimizdaId);
            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);



            return View();
        }
        public ActionResult Iletisim()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Iletisim.SingleOrDefault());

        }
        public ActionResult SliderPartial()
        {
            return View(db.Slider.ToList().OrderByDescending(x=>x.SliderId));  
        }

        public ActionResult HizmetPartial()
        {
            return View(db.Hizmet.ToList());
        }

        public ActionResult Hizmetlerimiz()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Hizmet.ToList().OrderByDescending(x => x.HizmetId));

        }



        public ActionResult Hakkimizda()
        {
            return View(db.Hakkimizda.SingleOrDefault());
        }

        public ActionResult FooterPartial()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            ViewBag.Hizmetler = db.Hizmet.ToList().OrderByDescending(x => x.HizmetId);
            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();
            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);
            ViewBag.Hakkimizda = db.Hakkimizda.SingleOrDefault();
            return PartialView();
        }
    }
}