using HotelInvatare.DAL;
using HotelInvatare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelInvatare.Controllers
{
    public class ReviewsController : Controller
    {
        // GET: Reviews
        public ActionResult Index()
        {
            ReviewRepository r = new ReviewRepository();
            List<ReviewModel> opinii = r.GetAll();
            return View(opinii);
        }

        public ActionResult Sterge(int id)
        {
            ReviewRepository r = new ReviewRepository();
            r.Delete(id);
            return RedirectToAction("Index");
        }
    }
}