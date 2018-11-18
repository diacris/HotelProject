using HotelInvatare.Common;
using HotelInvatare.DAL;
using HotelInvatare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelInvatare.Controllers
{
    public class RezervareController : Controller
    {
        // GET: Rezervare/Create
        public ActionResult AdaugaRezervare()
        {
            ViewBag.TipCamere = TipCameraSelectie.Selectii();
            return View();
        }

        // POST: Rezervare/Create
        [HttpPost]
        public ActionResult AdaugaRezervare(RezervareModel rezervare)
        {

            if (ModelState.IsValid)
            {
                CameraRepository c = new CameraRepository();
                var camereGasite = c.CautaCamereDisponibile(rezervare.CheckIn, rezervare.CheckOut, rezervare.TipCamera);
                if (camereGasite > 0)
                {
                    RezervariRepository r = new RezervariRepository();
                    r.Add(rezervare);
                    return RedirectToAction("Multumire");
                }
                ModelState.AddModelError("TipCamera", "Nu avem disponibilitate, va rugam selectati o alta perioada sau alt tip de camera.");
            }
            ViewBag.TipCamere = TipCameraSelectie.Selectii();
            return View(rezervare);
        }

        public ActionResult Multumire()
        {
            return View();
        }
    }
}
