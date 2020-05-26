using System;
using System.Collections.Generic;

namespace EJournal.Logic.Database
{
    public partial class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthYear { get; set; }
        public string Class { get; set; }
    }
}
