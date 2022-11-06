using System.ComponentModel.DataAnnotations;

namespace PersonalInfo.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}