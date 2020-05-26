using EJournal.Logic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJournal.Logic
{
    public class GradeManager
    {
        public static List<Grades> GetAllGrades()
        {
            using(var db = new DB())
            {
                return db.Grades.OrderByDescending(g => g.Grade).ToList();
            }
        }

        public static void AddNewGrade(string name, string surname, string subjectName, int grade, string description)
        {
            using(var db = new DB())
            {
                db.Grades.Add(new Grades()
                {
                    Name = name,
                    Surname = surname,
                    SubjectName = subjectName,
                    Grade = grade,
                    Description = description,
                });

                db.SaveChanges();
            }
        }

        public static List<Grades> GetByGradesInterval1To10()
        {
            using(var db = new DB())
            {
                return db.Grades.Where(g => g.Grade < 11 && g.Grade > 0).ToList();
            }
        }

        public static List<int> GetSubjectGrades(string subjectName)
        {
            using (var db = new DB())
            {
                return db.Grades.Where(g => g.SubjectName == subjectName).Select(g => g.Grade).ToList();
            }
        }

        public static List<int> GetStudentGrades(string name, string surname)
        {
            using (var db = new DB())
            {
                return db.Grades.Where(g => g.Name == name && g.Surname == surname).Select(g => g.Grade).ToList();
            }
        }

        public static double GetAverageGrade()
        {
            using (var db = new DB())
            {
                double AverageGrade = 0;

                foreach (var student in db.Students)
                {
                    AverageGrade = db.Grades.Where(g => g.Name == student.Name && g.Surname == student.Surname).Select(g => g.Grade).Average();
                }
                return AverageGrade;
            }
        }
    }
}
