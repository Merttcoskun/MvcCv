using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvSon.Models.entity ;
namespace MvcCvSon.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        dbcvEntities db = new dbcvEntities();
        public ActionResult Index()
        {
            var degerler=db.TBL_HAKKINDA.ToList();
            return View(degerler);
        }
        public PartialViewResult deneyim()
        {
            var deneyimler=db.TBL_DENEYIM.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult sosyalmedya()
        {
            var sosyalmedya = db.TBLSOSYALMEDYA.Where(x=>x.DURUM==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult egitim()
        {
            var egitim = db.TBL_EGITIM.ToList();
            return PartialView(egitim);
        }
        public PartialViewResult yetenek()
        {
            var yetenek = db.TBL_YETENEKLER.ToList();
            return PartialView(yetenek);
        }
        public PartialViewResult hobi()
        {
            var hobi = db.TBL_HOBILER.ToList();
            return PartialView(hobi);
        }
        public PartialViewResult sertifika()
        {
            var sertifika = db.TBL_SERTIFIKA.ToList();
            return PartialView(sertifika);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
            
        }
        [HttpPost]
        public PartialViewResult iletisim(TBL_ILETISIM t)
        {
            t.TARIH=DateTime.Parse( DateTime.Now.ToShortDateString());
            db.TBL_ILETISIM.Add(t);
            db.SaveChanges();
            return PartialView();

        }
    }
}