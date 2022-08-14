using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok.Models.Entity;
namespace Stok.Controllers
{
    public class SatislarController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var satislar = db.Tbl_satislar.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            //ÜRÜNLER
            List<SelectListItem> urun = (from x in db.Tbl_urunler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()
                                        }).ToList();


            ViewBag.drop1 = urun;
           
            //MÜŞTERİLER
            List<SelectListItem> must = (from x in db.Tbl_musteri.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad +" " + x.soyad,
                                             Value = x.id.ToString()
                                         }).ToList();


            ViewBag.drop2 = must;
            //PERSONEL
            List<SelectListItem> pers = (from x in db.Tbl_personel.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad +" " + x.soyad,
                                             Value = x.id.ToString()
                                         }).ToList();


            ViewBag.drop3 = pers;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(Tbl_satislar p)
        {
            var urun = db.Tbl_urunler.Where(x => x.id == p.Tbl_urunler.id).FirstOrDefault();
            var musteri = db.Tbl_musteri.Where(x => x.id == p.Tbl_musteri.id).FirstOrDefault();
            var personel = db.Tbl_personel.Where(x => x.id == p.Tbl_personel.id).FirstOrDefault();

            p.Tbl_urunler = urun;
            p.Tbl_musteri = musteri;
            p.Tbl_personel = personel;
            p.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_satislar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}