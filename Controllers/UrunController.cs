using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MVCStokDBEntities db = new MVCStokDBEntities();

        public ActionResult Index()
        {
            var degerler= db.Urunler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem>degerler=(from i in db.Kategoriler.ToList()
                                          select new SelectListItem
                                          {
                                              Text=i.KategoriAdı,
                                              Value=i.KategoriID.ToString() 
                                          }).ToList();
            ViewBag.dgr = degerler;                 

            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urunler p1)
        {
            //alttaki iki satır sonradan eklendi 
            var ktg=db.Kategoriler.Where(m=> m.KategoriID==p1.Kategoriler.KategoriID).FirstOrDefault();
            p1.Kategoriler= ktg;

            db.Urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil (int id)
        {
            var urun = db.Urunler.Find(id);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
        
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> degerler = (from i in db.Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAdı,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            var urun=db.Urunler.Find(id);
            return View("UrunGetir", urun);

        }

        public ActionResult Guncelle(Urunler p)
        {
            var urun = db.Urunler.Find(p.UrunID);
            urun.UrunAdı = p.UrunAdı;
            urun.Marka=p.Marka;
            urun.Stok=p.Stok;
            urun.Fiyat=p.Fiyat;
            // urun.UrunKategori=p.UrunKategori;
            var ktg = db.Kategoriler.Where(m => m.KategoriID == p.Kategoriler.KategoriID).FirstOrDefault();
            urun.UrunKategori = ktg.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}