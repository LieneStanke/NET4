using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EJournal.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name: ")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname: ")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Day of birth: ")]
        [DataType(DataType.Date)]
        [StringLength(10)]
        public string BirthYear { get; set; }

        [Required]
        [Display(Name = "Class: ")]
        [DataType(DataType.Text)]
        [StringLength(4)]
        public string Class { get; set; }

        public GradeModel Grades { get; set; }
    }
}
