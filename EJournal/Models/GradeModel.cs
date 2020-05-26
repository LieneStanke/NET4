using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EJournal.Models
{
    public class GradeModel
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
        [Display(Name = "Name of subject: ")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string SubjectName { get; set; }

        [Required]
        [Display(Name = "Grade: ")]
        public int Grade { get; set; }

        [Display(Name = "Description: ")]
        [DataType(DataType.Text)]
        [StringLength(150)]
        public string Description { get; set; }
    }
}
