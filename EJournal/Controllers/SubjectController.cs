using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJournal.Logic;
using EJournal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJournal.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult SubjectIndex()
        {
                var subject = SubjectManager.GetAllSubjects().Select(s => s.ToModel()).ToList();

                return View(subject);
        }

        [HttpGet]
        public IActionResult AddSubject()
        {
            var subject = new SubjectModel();
            return View(subject);
        }

        [HttpPost]
        public IActionResult AddSubject(SubjectModel model)
        {
            if (ModelState.IsValid)
            {
                SubjectManager.CreateNewSubject(model.SubjectName);

                return RedirectToAction(nameof(SubjectIndex));
            }

            return View(model);
        }
    }
}