using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
   
    public class HakkimdaController : Controller
    {
        DbCvEntities db = new DbCvEntities();

        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();

        [HttpGet]
        public ActionResult Index()
        {
            var h = repo.List();
            return View(h);
        }

        [HttpPost]
        public ActionResult Index(TblHakkimda p)
        {
            var h = repo.Find(x => x.ID == 1);
            h.Ad = p.Ad;
            h.Soyad = p.Soyad;
            h.Adres = p.Adres;
            h.Mail = p.Mail;
            h.Telefon = p.Telefon;
            h.Aciklama = p.Aciklama;
            h.Resim = p.Resim;
            repo.TUpdate(h);
            return RedirectToAction("Index");
        }
    }
}