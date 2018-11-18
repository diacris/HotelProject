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
    public class CameraController : Controller
    {
        // GET: Camera
        public ActionResult Index()
        {
            CameraRepository r = new CameraRepository();
            List<CameraModel> camere = r.GetAll();
            return View(camere);
        }


        // GET: Camera/Create
        public ActionResult Adauga()
        {
            ViewBag.TipCamere = TipCameraSelectie.Selectii();
            return View();
        }

        // POST: Camera/Create
        [HttpPost]
        public ActionResult Adauga(CameraModel camera)
        {
            CameraRepository r = new CameraRepository();
            r.Add(camera);

            return RedirectToAction("Index");
            ViewBag.TipCamere = TipCameraSelectie.Selectii();
        }
    }
}
