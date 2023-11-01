using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<TblSertifikalarım> repo = new GenericRepository<TblSertifikalarım>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }

       [HttpGet]
       public ActionResult SertifikaGetir(int id)
        {
            var t = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(t);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarım p)
        {
            var t = repo.Find(x => x.ID == p.ID);
            t.Aciklama = p.Aciklama;
            t.Tarih = p.Tarih;
            t.Resim = p.Resim;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSertifika(TblSertifikalarım p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}