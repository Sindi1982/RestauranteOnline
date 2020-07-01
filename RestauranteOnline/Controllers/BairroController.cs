﻿using RestauranteOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteOnline.Controllers
{
    public class BairroController : BaseController
    {
        private RestauranteDBEntities db = new RestauranteDBEntities();

        // GET: Bairro
        public ActionResult Index()
        {
            var bairros = db.Bairro.ToList();
            return View(bairros);
        }

        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                db.Bairro.Add(bairro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bairro);
        }

        public ActionResult Alterar(int id)
        {
            Bairro bairro = db.Bairro.Find(id);
            return View(bairro);
        }

        [HttpPost]
        public ActionResult Alterar(Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bairro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bairro);
        }

        public ActionResult Excluir(int id)
        {
            Bairro bairro = db.Bairro.Find(id);
            return View(bairro);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusão(int id)
        {
            try
            {
                Bairro bairro = db.Bairro.Find(id);
                db.Bairro.Remove(bairro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErroExcluir");
            }
        }

        public ActionResult ErroExcluir()
        {
            return View();
        }
    }
}