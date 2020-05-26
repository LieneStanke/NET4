using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EJournal.Logic;
using EJournal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJournal.Controllers
{
    public class GradeController : Controller
    {
        public IActionResult GradeIndex()
        {
            var grade = GradeManager.GetAllGrades().Select(g => g.ToModel()).ToList();

             return View(grade);
        }

        [HttpGet]
        public IActionResult AddGrade()
        {
            var grade = new GradeModel();
            return View(grade);
        }

        [HttpPost]
        public IActionResult AddGrade(GradeModel model)
        {
            if (ModelState.IsValid)
            {
                StudentModel student = StudentManager.GetByNameAndSurname(model.Name, model.Surname).ToModel();

                if (student == null)
                {
                    ModelState.AddModelError("pass", "In list of students don't exists student with this name and surname!");
                }
                else
                {
                    SubjectModel subject = SubjectManager.GetBySubjectName(model.SubjectName).ToModel();

                    if (subject == null)
                    {
                        ModelState.AddModelError("pass", "In list of subjects don't exists subject with this name!");
                    }
                    else
                    {
                        var grade = GradeManager.GetByGradesInterval1To10().ToList();

                        if (grade != null)
                        {
                            ModelState.AddModelError("pass", "The grade aren't in interval 1 to 10!");
                        }
                        else
                        {
                             GradeManager.AddNewGrade(model.Name, model.Surname, model.SubjectName, model.Grade, model.Description);

                              return RedirectToAction(nameof(GradeIndex));
                        }
                    }
                }
            }

            return View(model);
        }

        public IActionResult AverageGrade()
        {
           var average = GradeManager.GetAverageGrade();

              return View(average);
        }

        public IActionResult StudentGrades(GradeModel model)
        {
            var grades = GradeManager.GetStudentGrades(model.Name, model.Surname).ToList();
               
            return View(grades);
        }

        public IActionResult SubjectGrades(GradeModel model)
        {
            var grades = GradeManager.GetSubjectGrades(model.SubjectName).ToList();

             return View(grades);
        }
    }
}