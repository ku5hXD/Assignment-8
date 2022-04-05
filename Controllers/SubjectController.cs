using Assignment_8;
using Assignment_8.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_8.ApplicationDbContextNamespace;

namespace Assignment_8.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SubjectController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string searchString)
        {
            IEnumerable<Subject> objList = _db.Subject;

            if (!String.IsNullOrEmpty(searchString))
            {
                objList = objList.Where(s => s.Subject_Name.Contains(searchString));
            }
            return View(objList);
        }

        [HttpGet]
        public IActionResult Edit(int subjectid)
        {
            var subobj = _db.Subject.Find(subjectid);
            return View(subobj);

        }

        [HttpPost]
        public IActionResult Edit(Subject updatedvaluesobj)
        {
            _db.Subject.Update(updatedvaluesobj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subject subobj)
        {
            if (ModelState.IsValid)
            {
                _db.Subject.Add(subobj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subobj);
        }

        //Get Delete
        public IActionResult Delete(int subjectid)
        {

            var subobj = _db.Subject.Find(subjectid);
            return View(subobj);
        }


        [HttpPost]
        public IActionResult DeletePost(int ID)
        {
            var subobj = _db.Subject.Find(ID);

            if (ModelState.IsValid)
            {
                _db.Subject.Remove(subobj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subobj);
        }


    }
}