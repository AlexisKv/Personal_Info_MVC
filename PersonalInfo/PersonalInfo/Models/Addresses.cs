using PersonalInfo.Core.Models;

namespace PersonalInfo.Models;

public class Addresses: Entity
{
        public int Id { get; set; }
        public string? Address { get; set; }
}       