using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApp.Models
{
    [Table("Teachers")]
    public class Teacher : Human
    {
        public int? FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}