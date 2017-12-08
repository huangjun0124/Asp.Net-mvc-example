using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JunsWebApp.Models;

namespace JunsWebApp.Controllers
{
    public class StudentsController : Controller
    {
        private EFDbSet db = new EFDbSet();

        // GET: Students
        public async Task<ActionResult> Index([Bind(Prefix = "id")]int classId)
        {
            //this code here does not have Students got , cause of EF loading....
            //or you can Modify as below step:put virtual before Students of Class
            var cls = await db.Classes.FindAsync(classId);
            var clss = db.Classes.Include("Students").First(c=>c.Id.Equals(classId));
            return View(clss);
        }

        // GET: /Students/Create?classId=2
        public ActionResult Create(int classId)
        {
            var stu = new Student()
            {
                ClassId = classId
            };
            return View(stu);
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction("Index",new{id = student.ClassId});
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( [Bind(Exclude = "Name")]Student student)
        {
            if (ModelState.IsValid)
            {
                var stu = db.Students.Find(student.Id);
                stu.ClassId = student.ClassId;
                stu.Age = student.Age;
                stu.Sex = student.Sex;
                await db.SaveChangesAsync();
                return RedirectToAction("Index",new{id=student.ClassId});
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id, int classId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Student student = await db.Students.FindAsync(id);
            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index",new{id=student.ClassId});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
