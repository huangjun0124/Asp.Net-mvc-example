using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JunsWebApp.Models;

namespace JunsWebApp.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            var model = from r in ViewItem.GetItems()
                        orderby r.Rating
                        select r;
            return View(model);
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            var review = ViewItem.GetItems().Single(r => r.Id.Equals(id));
                          
            return View(review);
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var review = ViewItem.GetItems().Single(r => r.Id.Equals(id));
            if (TryUpdateModel(review))
                return RedirectToAction("Index");
            return View(review);
        }

       
        [ChildActionOnly]
        public ActionResult BestReview()
        {
            var r = ViewItem.GetItems().First();
            return PartialView("_Review",r);
        }
    }
}
