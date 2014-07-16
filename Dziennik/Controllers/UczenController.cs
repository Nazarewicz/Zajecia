using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDziennik.Models;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace AppDziennik.Controllers
{
    public class UczenController : Controller
    {
        //
        // GET: /Uczen/

        public ActionResult Index()
        {
            var db_u = new DBDziennik();
            return View("Index", db_u.Uczniowie.ToList());
        }

        //
        // GET: /Uczen/Details/5

        public ActionResult Details(int id_u)
        {
            var db_u = new DBDziennik();
            var u = db_u.Uczniowie.Find(id_u);
            return View("Details", u);
        }

      public ActionResult PartialDetails(int id_u)
      {
          var db_o = new DBDziennik();
          return PartialView("PartialDetails", db_o.Oceny.Where(m => m.Id_u == id_u).ToList());
      }

        //
        // GET: /Uczen/Create

        public ActionResult Create()
        {
            return View("Create");
        }

        //
        // POST: /Uczen/Create

        [HttpPost]
        public ActionResult Create(Uczen U)
        {
            var db_u = new DBDziennik();
            if (ModelState.IsValid)
            {
                db_u.Uczniowie.Add(U);
                db_u.SaveChanges();
                return RedirectToAction("Index");
            }

            {
                return View("Create", U);
            }
        }

        //
        // GET: /Uczen/Edit/5

        public ActionResult Edit(int id_u)
        {
            var db_u = new DBDziennik();
            return View("Edit", db_u.Uczniowie.Find(id_u));
        }

        //
        // POST: /Uczen/Edit/5

        [HttpPost]
        public ActionResult Edit(Uczen U)
        {
            if (ModelState.IsValid)
            {
                var db_u = new DBDziennik();
                db_u.Uczniowie.AddOrUpdate(U);
                db_u.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", U);
        }

        //
        // GET: /Uczen/Delete/5

        public ActionResult Delete(int id_u)
        {
            var db_u = new DBDziennik();
            var u = db_u.Uczniowie.Find(id_u);
            return View("Delete", u);
        }

        //
        // POST: /Uczen/Delete/5

        [HttpPost]
        public ActionResult Delete(int id_u, bool form=true)
        {
            var db_u = new DBDziennik();
            Uczen U = db_u.Uczniowie.Find(id_u);
            if (ModelState.IsValid)
            {
                db_u.Uczniowie.Remove(U);
                db_u.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Delete", U);

        }
    }
}
