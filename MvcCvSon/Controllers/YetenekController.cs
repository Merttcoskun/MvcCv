using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;
using MvcCvSon.Models.entity;
using MvcCvSon.repositories ;


namespace MvcCvSon.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        
        GenericRepository<TBL_YETENEKLER> repo=new GenericRepository<TBL_YETENEKLER>();
        public ActionResult Index()
        {
            var yetenekler = repo.list();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult yeniyetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniyetenek(TBL_YETENEKLER p)
        {
            repo.tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult yeteneksil(int id)
        {
            var yetenek = repo.find(x => x.ID == id);
            repo.tdelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult yetenekdüzenle(int id)
        {
            var yetenek = repo.find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult yetenekdüzenle(TBL_YETENEKLER t)
        {
            var y = repo.find(x => x.ID == t.ID);
            y.YETENEK = t.YETENEK;
            y.ORAN = t.ORAN;
            repo.tupdate(y);
            return RedirectToAction("Index");
        }
    }
}