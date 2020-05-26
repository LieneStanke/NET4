using EJournal.Logic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJournal.Logic
{
    public class SubjectManager
    {
        public static List<Subjects> GetAllSubjects()
        {
            using(var db = new DB())
            {
                return db.Subjects.OrderBy(s => s.SubjectName).ToList();
            }
        }

        public static void CreateNewSubject(string subjectName)
        {
            using(var db = new DB())
            {
                db.Subjects.Add(new Subjects()
                {
                    SubjectName = subjectName,
                });

                db.SaveChanges();
            }
        }

        public static Subjects GetBySubjectName(string subjectname)
        {
            using (var db = new DB())
            {
                return db.Subjects.FirstOrDefault(g => g.SubjectName == subjectname);
            }
        }
    }
}
