using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvSon.Models.entity;
using MvcCvSon.repositories;
namespace MvcCvSon.Controllers
{
    public class hobiController : Controller
    {
        // GET: hobi
        GenericRepository<TBL_HOBILER> repo = new GenericRepository<TBL_HOBILER>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobi = repo.list();
            return View(hobi);
        }
        [HttpPost]
        public ActionResult Index(TBL_HOBILER p)
        {
            var t = repo.find(x => x.ID == 1);
            t.ACIKLAMA1 = p.ACIKLAMA1;
            t.ACIKLAMA2 = p.ACIKLAMA2;
            t.ACIKLAMA3= p.ACIKLAMA3;
            t.ACIKLAMA4 = p.ACIKLAMA4;
            repo.tupdate(t);
            return RedirectToAction("Index");
        }
    }
}