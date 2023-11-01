﻿using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace MvcCv.Controllers
{

    public class EgitimController : Controller
    {
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();

      
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }


        public ActionResult EgitimSil(int id)
        {
            var t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }

            var t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik1 = p.AltBaslik1;
            t.AltBaslik2 = p.AltBaslik2;
            t.Tarih = p.Tarih;
            t.GNO = t.GNO;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}