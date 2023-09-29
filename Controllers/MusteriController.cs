using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri

        MVCStokDBEntities db =new MVCStokDBEntities();

        public ActionResult Index(string p)
        {
            var degerler=from d in db.Musteriler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MusteriAdı.Contains(p));
            }
            return View(degerler.ToList());


            //var degerler=db.Musteriler.ToList();
            //return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(Musteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri"); // hata mesajı alırsa sayfayı yenile
            }


            db.Musteriler.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var musteri=db.Musteriler.Find(id);
            db.Musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteri=db.Musteriler.Find(id);
            return View("MusteriGetir", musteri);
        }

        public ActionResult Guncelle(Musteriler p1)
        {
            var musteri = db.Musteriler.Find(p1.MusteriID);
            musteri.MusteriAdı=p1.MusteriAdı;
            musteri.MusteriSoyadı = p1.MusteriSoyadı;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}