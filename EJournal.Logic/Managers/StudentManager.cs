using EJournal.Logic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJournal.Logic
{
    public class StudentManager
    {
        public static List<Students> GetAllStudents()
        {
            using(var db = new DB())
            {
                return db.Students.OrderBy(s => s.Surname).ThenBy(s => s.Name).ToList();
            }
        }

        public static void AddNewStudent(string name, string surname, string birthYear, string schoolClass)
        {
            using(var db = new DB())
            {
                db.Students.Add(new Students()
                {
                    Name = name,
                    Surname = surname,
                    BirthYear = birthYear,
                    Class = schoolClass,
                });

                db.SaveChanges();
            }
        }

        public static Students GetByNameAndSurname(string name, string surname)
        {
            using (var db = new DB())
            {
                return db.Students.FirstOrDefault(g => g.Name == name && g.Surname == surname);
            }
        }
    }
}
