using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok.Models.Entity;
namespace Stok.Controllers
{
    public class AdminController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(Tbl_admin p)
        {
            db.Tbl_admin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}