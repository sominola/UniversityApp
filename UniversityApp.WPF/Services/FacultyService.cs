using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityApp.Models;

namespace UniversityApp.Services
{
    public static class FacultyService
    {
        public static event Action<Faculty, Student> StudentRegisterForFaculty;
        public static readonly IEnumerable<Faculty> Faculties;

        static FacultyService()
        {
            Faculties = new List<Faculty>(GetFaculties());
        }

        private static IEnumerable<Faculty> GetFaculties()
        {
            using var db = new ApplicationContext();
            return db.Faculties.Include(s => s.Students).Include(t => t.Teachers).Include(e => e.Exams).ToList();
        }

        public static void RegisterStudentForFaculty(Faculty faculty, Student student)
        {
            if (faculty is null || student is null)
                throw new NullReferenceException();
            if (!Faculties.Contains(faculty))
                throw new Exception("Faculty does not exist");
            if (student.Faculty != null)
                throw new Exception("Student has a faculty");


            faculty.Students.Add(student);

            using var db = new ApplicationContext();
            db.Faculties.Update(faculty);
            db.SaveChanges();

            StudentRegisterForFaculty?.Invoke(faculty, student);
        }
    }
}