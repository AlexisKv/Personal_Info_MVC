using System.ComponentModel.DataAnnotations;


namespace PersonalInfo.Models
{
    public class Person
    {   
        [Key]
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

        public List<Addresses> AllAddresses { get; set; }
        
        [Display(Name = "Is person married?")]
        public bool IsMerriged { get; set; }
        
        public string? Relationship { get; set; }

    }
    
    public class Addresses
    {
        public int Id { get; set; }
        public string Address { get; set; }
    }
}