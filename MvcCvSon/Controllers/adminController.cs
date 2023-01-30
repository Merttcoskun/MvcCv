using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvSon.Models.entity;
using MvcCvSon.repositories;

namespace MvcCvSon.Controllers
{
    
    public class adminController : Controller
    {
        // GET: admin
        GenericRepository<TBL_ADMIN> repo=new GenericRepository<TBL_ADMIN>();
        public ActionResult Index()
        {
            var liste = repo.list();
            return View(liste);
        }
        [HttpGet]
        public ActionResult adminekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult adminekle(TBL_ADMIN p)
        {
            repo.tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult adminsil(int id)
        {
            TBL_ADMIN t = repo.find(x => x.ID == id);
            repo.tdelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult admindüzenle(int id)
        {
            TBL_ADMIN t = repo.find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult admindüzenle(TBL_ADMIN p)
        {
            TBL_ADMIN t = repo.find(x => x.ID == p.ID);
            t.KULLANICIADI = p.KULLANICIADI;
            t.SIFRE = p.SIFRE;
            repo.tupdate(t);
            return RedirectToAction("Index");
        }
    }
}