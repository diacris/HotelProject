using HotelInvatare.DAL;
using HotelInvatare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelInvatare.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            ReviewRepository r = new ReviewRepository();
            List<ReviewModel> opinii = r.GetAll();
            return View(opinii);
        }

        // GET: Review/Create
        public ActionResult Adauga()
        {
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Adauga(ReviewModel opinie1)
        {
            if (ModelState.IsValid)
            {
                ReviewRepository r = new ReviewRepository();
                r.Add(opinie1);
                return RedirectToAction("Index");
            }
            return View(opinie1);
        }
    }
}
