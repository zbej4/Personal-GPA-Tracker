/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name	    : Brandon Jones
// Department Name	: Computer and Information Sciences 
// File Name		: HomeController.cs
// Purpose          : Methods for displaying views related to Courses 
// Author			: Brandon Jones, E-Mail: zbej4@etsu.edu
// Create Date		: Friday, November 25, 2016
//
//-----------------------------------------------------------------------------------
//
// Modified Date	: Sunday, November 27, 2016
// Modified By		: Brandon Jones
//
/////////////////////////////////////////////////////////////////////////////////////

using Project_3___Personal_GPA_Tracker.DataContexts;
using Project_3___Personal_GPA_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project_3___Personal_GPA_Tracker.Controllers
{
    public class HomeController : Controller
    {
        //Database object
        private GradesDb _db = new GradesDb();

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose (bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Function to retrieve Home page View
        /// </summary>
        /// <returns>Index view</returns>
        public ActionResult Index ()
        {
            ViewBag.Grades = _db.Grades.OrderByDescending(g => g.GradePoints).ToList();
            var query = _db.Courses;
            return View(query.ToList());
        }

        /// <summary>
        /// Creates the course object and stores it in database
        /// </summary>
        /// <param name="course">The course</param>
        /// <returns>Partial view of course list</returns>
        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Grades = _db.Grades.OrderByDescending(g => g.GradePoints).ToList();
                var query = _db.Courses.Where(c => c.CourseCode.Equals(course.CourseCode));
                if (query.Count() < 1)
                {
                    _db.Courses.Add(course);
                    _db.SaveChanges();
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("_CourseList", _db.Courses.ToList());
                    }
                    return PartialView("_CourseList", _db.Courses.ToList());
                }
                return PartialView("_CourseList", _db.Courses.ToList());
            }
            return PartialView("_CourseList", _db.Courses.ToList());

        }

        /// <summary>
        /// GET function to retrieve Edit course view.
        /// </summary>
        /// <param name="id">Id of Course to edit</param>
        /// <returns>Partial view of course to edit</returns>
        public ActionResult EditCourse(string id)
        {
            Course course = _db.Courses.Find(id);
            ViewBag.Grades = _db.Grades.OrderByDescending(g => g.GradePoints).ToList();
            return PartialView("_EditCourse", course);
        }

        /// <summary>
        /// Edits the course and saves it to database
        /// </summary>
        /// <param name="course">The course</param>
        /// <returns>Partial view of course list</returns>
        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            ViewBag.Grades = _db.Grades.OrderByDescending(g => g.GradePoints).ToList();
            if (ModelState.IsValid)
            {
                _db.Entry(course).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_CourseList", _db.Courses.ToList());
                }
                return PartialView("_CourseList", _db.Courses.ToList());
            }
            return PartialView("_CourseList", _db.Courses.ToList());
        }

        /// <summary>
        /// GET function to retrieve Delete course view.
        /// </summary>
        /// <param name="id">Id of Course to be deleted</param>
        /// <returns>Partial view of course to delete</returns>
        public ActionResult DeleteCourse(string id)
        {
            Course course = _db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeleteCourse", course);
        }

        /// <summary>
        /// Deletes course from database
        /// </summary>
        /// <param name="id">Id of Course to be deleted</param>
        /// <returns>Partial view of course list</returns>
        [HttpPost, ActionName("DeleteCourse")]
        public ActionResult ConfirmDeleteCourse(string id)
        {
            Course course = _db.Courses.Find(id);
            _db.Courses.Remove(course);
            _db.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                ViewBag.Grades = _db.Grades.OrderByDescending(g => g.GradePoints).ToList();
                return PartialView("_CourseList", _db.Courses.ToList());
            }
            return PartialView("_CourseList", _db.Courses.ToList());
        }
       
    }
}