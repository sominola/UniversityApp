using System;
using System.Linq;
using UniversityApp.Models.Exam;

namespace UniversityApp.Services
{
    public class Demonstrate
    {
        public void Main()
        {
            using var db = new ApplicationContext();
            var humans = db.Humans.Where(a => a.LastName.StartsWith("S"));
            foreach (var account in humans)
            {
                Console.WriteLine(account.LastName);
            }

            var students = from student in db.Students
                from teacher in db.Teachers
                where student.FacultyId == teacher.FacultyId
                select student;

            var studentss = from student in db.Students
                group student by student.Faculty.NameFaculty;
            
            studentss = db.Students.GroupBy(f => f.Faculty.NameFaculty);

            foreach (var group in studentss)
            {
                Console.WriteLine(group.Key);
                foreach (var g in group)
                {
                    Console.WriteLine(g.Name);
                }
            }

            var result = from student in db.Students
                join faculty in db.Faculties on student.FacultyId equals faculty.FacultyId
                select new {Name = student.Name, Faculty = student.Faculty.NameFaculty, Exams = faculty.Exams};

            var expansionMethod = db.Students.Join(db.Faculties,
                student => student.FacultyId,
                faculty => faculty.FacultyId,
                (student, faculty) => new
                {
                    Name = student.Name,
                    Faculty = faculty.NameFaculty,
                    Exams = faculty.Exams
                }
            );
            foreach (var t in result)
            {
                Console.WriteLine($"{t.Name} {t.Faculty}");
                foreach (var exam in t.Exams)
                {
                    Console.WriteLine(exam.ExamName);
                }
            }

            foreach (var student in db.Students.OrderBy(t => t.Name))
            {
                
            }


            var union = db.Students.Where(s => s.LastName.Contains("a"))
                .Union(db.Students.Where(s=>s.FacultyId == 1));
            
            var intersect = db.Students.Where(s => s.LastName.Contains("a"))
                .Intersect(db.Students.Where(s=>s.FacultyId == 1));

            var selectFirst = db.Students.Where(s => s.FacultyId == 1);
            var selectSecond = db.Students.Where(s => s.LastName.Contains("a"));
            var except = selectFirst.Except(selectSecond);

            int? count = db.Students.Count(s => s.Age == 19);
            
            int? min = db.Students.Min(s => s.Age);
            double? avg = db.Students.Average(s => s.Age);
            int? max = db.Students.Min(s => s.Age);

            int? sum = db.Students.Sum(s => s.Age);
        }
    }
}