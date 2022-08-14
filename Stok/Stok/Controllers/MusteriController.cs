using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace Stok.Controllers
{
    public class MusteriController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
         [Authorize]
        public ActionResult Index(int sayfa =2)
        {
            //var musteriliste = db.Tbl_musteri.ToList();
            var musteriliste = db.Tbl_musteri.Where(x => x.durum == true).ToList().ToPagedList(sayfa, 2);
            return View(musteriliste);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(Tbl_musteri p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            p.durum = true;
            db.Tbl_musteri.Add(p);
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(Tbl_musteri p)
        {
            var musteribul = db.Tbl_musteri.Find(p.id);
            musteribul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
           
            var mus = db.Tbl_musteri.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult MusteriGuncelle(Tbl_musteri t)
        {
            var mus = db.Tbl_musteri.Find(t.id);
            mus.ad = t.ad;
            mus.soyad = t.soyad;
            mus.sehir = t.sehir;
            mus.bakiye = t.bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}