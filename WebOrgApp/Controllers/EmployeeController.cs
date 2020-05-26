using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebOrgApp.Models;
using WebOrgApp.DB;

namespace WebOrgApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index(int? id)
        {
            // pieslēdzamies datubāzei
            using(var db = new Database())
            { 
                var model = db.Employees
                    .OrderBy(x => x.Department)
                    .ThenBy(x => x.Surname)
                    .Select(e => new EmployeeModel()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Surname = e.Surname,
                        Profession = e.Profession,
                        Department = e.Department,
                        BirthYear = e.BirthYear,
                    })
                    .ToList();

                if(id.HasValue)
                {
                    model = model.Where(x => x.Id == id).ToList();
                }

                return View(model);
            }
        }


        public IActionResult AllDepartments()
        {
            using(var db = new Database())
            { 
                var model = db.Employees
                    .Select(c => c.Department)
                    .Distinct()
                    .ToList();

                return View(model);
            }
        }


        [HttpGet]
        public IActionResult Add()
        {
            var employee = new EmployeeModel();

            return View(employee);
        }


        [HttpPost]
        public IActionResult Add(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Database())
                {
                    db.Employees.Add(new DB.Employees()
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        BirthYear = model.BirthYear,
                        Department = model.Department,
                        Profession = model.Profession,
                    });

                    db.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }
    }
}