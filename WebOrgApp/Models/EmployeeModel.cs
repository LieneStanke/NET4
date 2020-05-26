using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebOrgApp.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Surname: ")]
        public string Surname { get; set; }

        [Display(Name = "Birth Year: ")]
        [DataType(DataType.Text)]
        [StringLength(4)]
        public string BirthYear { get; set; }

        [DataType(DataType.Text)]
        [StringLength(500)]
        [Display(Name = "Profession: ")]
        public string Profession { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(150)]
        [Display(Name = "Department: ")]
        public string Department { get; set; }
    }
}
