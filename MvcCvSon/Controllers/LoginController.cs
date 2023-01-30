using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcCvSon.Models.entity;

namespace MvcCvSon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBL_ADMIN p)
        {
            dbcvEntities db = new dbcvEntities();
            var bilgi = db.TBL_ADMIN.FirstOrDefault(x => x.KULLANICIADI == p.KULLANICIADI && x.SIFRE == p.SIFRE);
            if(bilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KULLANICIADI, false);
                Session["kullaniciadi"] = bilgi.KULLANICIADI.ToString();
                return RedirectToAction("Index", "deneyim");
            }
            else
            {
                return RedirectToAction("Index", "login");
            }
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "login");
        }

    }
}