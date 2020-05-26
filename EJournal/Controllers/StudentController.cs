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
    public class StudentController : Controller
    {
        public IActionResult StudentIndex()
        {
            var students = StudentManager.GetAllStudents().Select(s => s.ToModel()).ToList();

             return View(students);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            var student = new StudentModel();
            return View(student);
        }

        [HttpPost]
        public IActionResult AddStudent(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                StudentManager.AddNewStudent(model.Name, model.Surname, model.BirthYear, model.Class);

                return RedirectToAction(nameof(StudentIndex));
            }

            return View(model);
        }
    }
}