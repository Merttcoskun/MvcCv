using MvcCvSon.Models.entity;
using MvcCvSon.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCvSon.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TBL_EGITIM> repo = new GenericRepository<TBL_EGITIM>();

        
        public ActionResult Index()
        {
            var egitim = repo.list();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult egitimekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult egitimekle(TBL_EGITIM p)
        {
            if(!ModelState.IsValid) //modelin durum geçerliliği sağlanmadıysa 
            {
                return View("egitimekle");
            }
            repo.tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult egitimsil(int id)
        {
            var egitim = repo.find(x => x.ID == id);
            repo.tdelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult egitimduzenle(int id)
        {
            var egitim = repo.find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult egitimduzenle(TBL_EGITIM t)
        {
            if (!ModelState.IsValid) //modelin durum geçerliliği sağlanmadıysa 
            {
                return View("egitimduzenle");
            }
            var egitim = repo.find(x => x.ID == t.ID);
            egitim.BASLIK = t.BASLIK;
            egitim.ALTBASLIK1 = t.ALTBASLIK1;
            egitim.ALTBASLIK2 = t.ALTBASLIK2;
            egitim.TARIH = t.TARIH;
            egitim.GNO = t.GNO;
            repo.tupdate(egitim);
            return RedirectToAction("Index");
        }
    }
}