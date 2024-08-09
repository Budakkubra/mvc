using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrumsalWeb.Models.DataContext;
using UrumsalWeb.Models.Model;

namespace UrumsalWeb.Controllers
{
    public class HakkimizdaController : Controller
    {
        UrumsalDBContext db=new UrumsalDBContext();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            var h =db.Hakkimizda.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h=db.Hakkimizda.Where(x=>x.HakkimizdaId==id).FirstOrDefault();
            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id,Hakkimizda h)
        {
            if (ModelState.IsValid)
            {
               var hakkimizda=db.Hakkimizda.Where(x=>x.HakkimizdaId == id).SingleOrDefault();
                hakkimizda.Aciklama = h.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
             }
            
            return View(h); 
        }

    }
}