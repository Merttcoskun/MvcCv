using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcCvSon.Models.entity;
using MvcCvSon.repositories;
namespace MvcCvSon.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TBL_SERTIFIKA> repo=new GenericRepository<TBL_SERTIFIKA>();
        public ActionResult Index()
        {
            var sertifika = repo.list();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult sertifikagetir(int id)
        {
            var sertifika = repo.find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult sertifikagetir(TBL_SERTIFIKA t)
        {
            var sertifika = repo.find(x => x.ID == t.ID);
            sertifika.ACIKLAMA=t.ACIKLAMA;
            sertifika.TARIH=t.TARIH;
            repo.tupdate(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult yenisertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenisertifika(TBL_SERTIFIKA p)
        {
            repo.tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult sertifikasil(int id)
        {
            var sertifika=repo.find(x => x.ID == id);
            repo.tdelete(sertifika);
            return RedirectToAction("Index");
        }

    }
}