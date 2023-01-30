using MvcCvSon.Models.entity;
using System.Web.Mvc;
using MvcCvSon.repositories;

namespace MvcCvSon.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<TBL_HAKKINDA> repo=new GenericRepository<TBL_HAKKINDA>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.list();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(TBL_HAKKINDA p)
        {
            var t = repo.find(x => x.ID == 1);
            t.AD = p.AD;
            t.SOYAD = p.SOYAD;
            t.ADRES = p.ADRES;
            t.MAIL = p.MAIL;
            t.TELEFON = p.TELEFON;
            t.ACIKLAMA = p.ACIKLAMA;
            t.RESIM = p.RESIM;
            repo.tupdate(t);
            return RedirectToAction("Index");
        }
    }
}