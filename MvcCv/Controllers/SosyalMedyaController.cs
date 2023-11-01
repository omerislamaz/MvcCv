using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
       
        public ActionResult Index()
        {
            var s = repo.List();
            return View(s);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult Ekle(TblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var s = repo.Find(x => x.ID == id);
            return View(s);
        }
        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedya p)
        {
            var s = repo.Find(x => x.ID == p.ID);
            s.Ad = p.Ad;
            s.Link = p.Link;
            s.ikon = p.ikon;
            s.Durum = true;
            repo.TUpdate(s);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var s = repo.Find(x => x.ID == id);
            s.Durum = false;
            repo.TUpdate(s);
            return RedirectToAction("Index");
        }
    }
}