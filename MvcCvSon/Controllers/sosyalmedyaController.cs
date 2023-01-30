using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvSon.Models.entity;
using MvcCvSon.repositories;
namespace MvcCvSon.Controllers
{
    public class sosyalmedyaController : Controller
    {
        // GET: sosyalmedya
        GenericRepository<TBLSOSYALMEDYA> repo=new GenericRepository<TBLSOSYALMEDYA>();
        
        public ActionResult Index()
        {
            var veriler=repo.list();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ekle(TBLSOSYALMEDYA p)
        {
            repo.tadd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult sayfagetir(int id)
        {
            var hesap=repo.find(x=>x.ID==id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult sayfagetir(TBLSOSYALMEDYA p)
        {
            var hesap = repo.find(x => x.ID == p.ID);
            hesap.AD=p.AD;
            hesap.DURUM = true;
            hesap.LINK=p.LINK;
            hesap.IKON=p.IKON;
            repo.tupdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult sil(int id)
        {
            var hesap=repo.find(x=>x.ID == id);
            hesap.DURUM = false;
            repo.tupdate(hesap);
            return RedirectToAction("Index");
        }

    }
}