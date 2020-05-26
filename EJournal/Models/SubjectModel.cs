using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EJournal.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name: ")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string SubjectName { get; set; }
    }
}
