using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;// ilk olarak entity klasörüne ulaşıyoruz 

using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        MVCStokDBEntities db= new MVCStokDBEntities();//ikinci olarak entity klasöründe bulunan modeli db ye aktardık 
        public ActionResult Index(int sayfa=1)
        {

            //var degerler=db.Kategoriler.ToList();// select işleminin kısa yoludu r-- değerler nesnesine veritabanındaki kategoriler  verilerini aktarır ve listeler  
            var degerler = db.Kategoriler.ToList().ToPagedList(sayfa, 4);// buradaki 4 kaç tane itemin olacağını belirtiyor 
            return View(degerler);// degerleri döndürür
            
        }

        [HttpGet] // sayfa yenilendiğinde yapılacak işlemi gösterir 
        public ActionResult YeniKategori() 
        {
            return View();
        }

        [HttpPost]//arka plan işllemi olursa çalışacak yer
        // yeni kategori ekleme
        public ActionResult YeniKategori(Kategoriler p1) //hangi tabloya eklenecekse tablonun adı ve parametre belirle
        {

            if(!ModelState.IsValid)
            {
                return View("YeniKategori"); // hata mesajı alırsa sayfayı yenile
            }


            db.Kategoriler.Add(p1);//inster into işlemi 
            db.SaveChanges();// değişlikleri kaydet
            return View();//sayfayı döndür
        }

        public ActionResult Sil (int id)
        {
            var kategori = db.Kategoriler.Find(id);
            db.Kategoriler.Find(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr=db.Kategoriler.Find(id);
            return View("KategoriGetir",ktgr);
        }

    }
}