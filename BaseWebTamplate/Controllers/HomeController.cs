using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseWebTamplate.Models;

namespace BaseWebTamplate.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            List<string> zemlje = new List<string>();
            zemlje.Add("Htvatska");
            zemlje.Add("Belgija");
            zemlje.Add("Litva");
            zemlje.Add("Španjolska");

            //ViewBag.countries = zemlje;
            ViewData["countries"] = zemlje;


            Vijest post = new Vijest()
            {
                VijestId = 1,
                Autor = "Josip Štavalj",
                Naslov = "Prva tema o slasticama",
                Sadrzaj = "Josš malo sadržaja",
                Timestamp = DateTime.Today,
            };
            return View(post);
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details()
        {
            Vijest post = new Vijest()
            {
                VijestId = 1,
                Autor = "Josip Štavalj",
                Naslov = "Prva tema o slasticama",
                Sadrzaj = "Josš malo sadržaja",
                Timestamp = DateTime.Today,
            };
            return View(post);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
