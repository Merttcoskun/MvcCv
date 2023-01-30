using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvSon.Models.entity;
using MvcCvSon.repositories;

namespace MvcCvSon.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<TBL_ILETISIM> repo=new GenericRepository<TBL_ILETISIM>();
        public ActionResult Index()
        {
            var mesajlar=repo.list();
            return View(mesajlar);
        }
    }
}