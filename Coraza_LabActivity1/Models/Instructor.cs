using System.ComponentModel.DataAnnotations;

namespace Coraza_LabActivity1.Models
{

    public enum Rank
    {
        Instructor, AssistantProfessor, AssociateProfessor, Professor
    }
    public enum IsTenured
    {
        Permanent, Probationary
    }
    public class Instructor
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First name")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last name")]
        public string? LastName { get; set; }
        [Display(Name = "Is tenured")]
        public IsTenured IsTenured { get; set; }
        [Required]
        [Display(Name = "Academic rank")]
        public Rank Rank { get; set; }
        [Display(Name = "Hiring date")]
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }
    }
}
