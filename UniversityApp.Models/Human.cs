using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models
{
    public class Human
    {
        [Key] 
        public int HumanId { get; set; }
        
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
    }
}