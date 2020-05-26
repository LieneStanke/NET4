using EJournal.Logic.Database;
using EJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJournal
{
    public static class MappingExtensions
    {
        public static SubjectModel ToModel(this Subjects subjects)
        {
            return new SubjectModel()
            {
                Id = subjects.Id,
                SubjectName = subjects.SubjectName,
            };
        }

        public static StudentModel ToModel(this Students students)
        {
            return new StudentModel()
            {
                Id = students.Id,
                Name = students.Name,
                Surname = students.Surname,
                BirthYear = students.BirthYear,
                Class = students.Class,
            };
        }

        public static GradeModel ToModel(this Grades grades)
        {
            return new GradeModel()
            {
                Id = grades.Id,
                Name = grades.Name,
                Surname = grades.Surname,
                SubjectName = grades.SubjectName,
                Grade = grades.Grade,
                Description = grades.Description,
            };
        }
    }
}
