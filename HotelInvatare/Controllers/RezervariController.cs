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
    public class RezervariController : Controller
    {
        // GET: Rezervari
        public ActionResult Index()
        {
            RezervariRepository r = new RezervariRepository();
            List<RezervareModel> rezervari = r.GetAll();
            return View(rezervari);
        }

        // GET: Rezervari/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rezervari/Create
        public ActionResult Adauga()
        {
            ViewBag.TipCamere = TipCameraSelectie.Selectii();
            return View();
        }

        // POST: Rezervari/Create
        [HttpPost]
        public ActionResult Adauga(RezervareModel rezervare)
        {
            if (ModelState.IsValid)
            {
                CameraRepository c = new CameraRepository();
                var camereGasite = c.CautaCamereDisponibile(rezervare.CheckIn, rezervare.CheckOut, rezervare.TipCamera);
                if (camereGasite > 0)
                {
                    RezervariRepository r = new RezervariRepository();
                    r.Update(rezervare);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("TipCamera", "Nu mai este disponibilitate, verificati ce date sunt disponibile in rezervari");
            }
            ViewBag.TipCamere = TipCameraSelectie.Selectii();
            return View(rezervare);
        }

        // GET: Rezervari/Edit/5
        public ActionResult Editeaza(int id)
        {
            RezervariRepository r = new RezervariRepository();
            RezervareModel rezervare = r.GetById(id);
            ViewBag.TipCamere = TipCameraSelectie.Selectii();
            return View(rezervare);
        }

        // POST: Rezervari/Edit/5
        [HttpPost]
        public ActionResult Editeaza(RezervareModel rezervare)
        {
            if (ModelState.IsValid)
            {
                CameraRepository c = new CameraRepository();
                var camereGasite = c.CautaCamereDisponibile(rezervare.CheckIn, rezervare.CheckOut, rezervare.TipCamera);
                if (camereGasite > 0)
                {
                    RezervariRepository r = new RezervariRepository();
                    r.Update(rezervare);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("TipCamera", "Nu mai este disponibilitate, verificati ce date sunt disponibile in rezervari");
            }
            ViewBag.TipCamere = TipCameraSelectie.Selectii();
            return View(rezervare);
        }

        // GET: Rezervari/Delete/5
        public ActionResult Sterge(int id)
        {
            RezervariRepository r = new RezervariRepository();
            r.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
