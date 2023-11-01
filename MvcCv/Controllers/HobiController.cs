using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;


namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();

        [HttpGet]
        public ActionResult Index()
        {
            var h = repo.List();
            return View(h);
        }

        [HttpPost]
        public ActionResult Index(TblHobilerim p)
        {
            var h = repo.Find(x => x.ID == 1);
            h.Aciklama1 = p.Aciklama1;
            h.Aciklama2 = p.Aciklama2;
            repo.TUpdate(h);
            return RedirectToAction("Index");
        }
    }
}