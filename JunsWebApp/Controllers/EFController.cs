using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JunsWebApp.Models;

namespace JunsWebApp.Controllers
{
    public class EFController : Controller
    {
        // GET: EF
        public ActionResult Index(string searchStu = null)
        {
            List<Class> model;
            using (EFDbSet db = new EFDbSet())
            {
                var sel= from c in db.Classes
                    orderby c.Students.Count ascending 
                    select c;
                model = sel.ToList();
                model = db.Classes.OrderBy(c=>c.Students.Count).Where(c=>c.Students.Any(s=> (searchStu == null ||s.Name.StartsWith(searchStu)))).Include("Students").ToList();
            }
            return View(model);
        }
    }
}