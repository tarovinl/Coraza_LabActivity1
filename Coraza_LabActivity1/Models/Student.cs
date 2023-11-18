using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Coraza_LabActivity1.Models
{

    public enum Course
    {
        BSIT,BSCS,BSIS
    }
   
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string? Name { get; set; }
        public Course Course { get; set; }
        [Display(Name = "Date Enrolled")]
        [DataType(DataType.Date)]
        public DateTime DateEnrolled { get; set; }
    }
}
