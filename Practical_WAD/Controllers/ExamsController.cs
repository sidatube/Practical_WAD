using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practical_WAD.Data;
using Practical_WAD.Models;

namespace Practical_WAD.Controllers
{
    public class ExamsController : Controller
    {
        private DataContect db = new DataContect();

        // GET: Exams
        public ActionResult Index()
        {
            var exams = db.Exams.Include(e => e.Classroom).Include(e => e.Falculty).Include(e => e.Status).Include(e => e.Subject);
            return View(exams.ToList());
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            ViewBag.classroomId = new SelectList(db.Classrooms, "id", "name");
            ViewBag.falcultyId = new SelectList(db.Falculties, "id", "name");
            ViewBag.statusId = new SelectList(db.Statuses, "id", "status");
            ViewBag.subjectId = new SelectList(db.Subjects, "id", "name");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,subjectId,startTime,examDate,dutation,classroomId,falcultyId,statusId")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.classroomId = new SelectList(db.Classrooms, "id", "name", exam.classroomId);
            ViewBag.falcultyId = new SelectList(db.Falculties, "id", "name", exam.falcultyId);
            ViewBag.statusId = new SelectList(db.Statuses, "id", "status", exam.statusId);
            ViewBag.subjectId = new SelectList(db.Subjects, "id", "name", exam.subjectId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.classroomId = new SelectList(db.Classrooms, "id", "name", exam.classroomId);
            ViewBag.falcultyId = new SelectList(db.Falculties, "id", "name", exam.falcultyId);
            ViewBag.statusId = new SelectList(db.Statuses, "id", "status", exam.statusId);
            ViewBag.subjectId = new SelectList(db.Subjects, "id", "name", exam.subjectId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,subjectId,startTime,examDate,dutation,classroomId,falcultyId,statusId")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.classroomId = new SelectList(db.Classrooms, "id", "name", exam.classroomId);
            ViewBag.falcultyId = new SelectList(db.Falculties, "id", "name", exam.falcultyId);
            ViewBag.statusId = new SelectList(db.Statuses, "id", "status", exam.statusId);
            ViewBag.subjectId = new SelectList(db.Subjects, "id", "name", exam.subjectId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
            db.SaveChanges();
            return RedirectToAction("Index");
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
