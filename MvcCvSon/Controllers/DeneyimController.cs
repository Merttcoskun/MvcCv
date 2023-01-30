using MvcCvSon.Models.entity;
using MvcCvSon.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCvSon.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo=new DeneyimRepository();
        public ActionResult Index()
        {
            var deneyim=repo.list();
            return View(deneyim);
        }
        [HttpGet]
        public ActionResult deneyimekle() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult deneyimekle(TBL_DENEYIM p)
        {
            repo.tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult deneyimsil(int id)
        {
            TBL_DENEYIM t=repo.find(x => x.ID == id);
            repo.tdelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult deneyimgetir(int id)
        {
            TBL_DENEYIM t = repo.find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult deneyimgetir(TBL_DENEYIM p)
        {
            TBL_DENEYIM t = repo.find(x => x.ID == p.ID);
            t.BASLIK = p.BASLIK;
            t.ALTBASLIK = p.ALTBASLIK;
            t.TARIH = p.TARIH;
            t.ACIKLAMA = p.ACIKLAMA;
            repo.tupdate(t);
            return RedirectToAction("Index");
        }
    }
}