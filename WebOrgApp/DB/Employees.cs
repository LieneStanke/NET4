using System;
using System.Collections.Generic;

namespace WebOrgApp.DB
{
    public partial class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthYear { get; set; }
        public string Profession { get; set; }
        public string Department { get; set; }
    }
}
