using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Stok.Models.Entity;

namespace Stok.Controllers
{
    
    public class GirisController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();

        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(Tbl_admin t)
        {
            var bilgiler = db.Tbl_admin.FirstOrDefault(x => x.kullanici == t.kullanici && x.sifre == t.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                return View();
            }
           
           
        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Giris");
        }

    }
}