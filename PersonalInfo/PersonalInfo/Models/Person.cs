using System.ComponentModel.DataAnnotations;


namespace PersonalInfo.Models
{
    public class Person
    {
        public int Id { get; set; }
        
        
        [Display(Name = "First Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? LastName { get; set; }
        
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        [Display(Name = "Is person merriged?")]
        public bool? IsMerriged { get; set; }
        
        public string? Relationship { get; set; }

    }
}