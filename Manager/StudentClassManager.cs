using System.Collections.Generic;
using System.Linq;
using firstApp.Core;
using firstApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace firstApp.Manager
{
    public class StudentClassManager : IStudentClassManager
    {
        private readonly SiteContext _siteContext;
        public StudentClassManager(SiteContext siteContext)
        {
            _siteContext = siteContext;
        }

        public IQueryable<Student> get()
        {
            return _siteContext.Students;
        }
        public void SaveChange()
        {
            _siteContext.SaveChanges();
        }

        public void add(Student student, int classId)
        {
            var studentEntity = new Student()
            {
                StudentName = student.StudentName
            };

            var classEntity = new Class()
            {
                ClassName = _siteContext.Classes.Where(c => c.ClassId == classId)
                                                .Select(x => x.ClassName)
                                                .FirstOrDefault()
            };

            student.ClassStudents = new List<ClassStudent>
            {
                new ClassStudent{
                    Class = classEntity,
                    Student = studentEntity
                }
            };

            _siteContext.Students.Add(studentEntity);
        }

        public void delete(int id)
        {
            var std = _siteContext.Students.FirstOrDefault(st => st.StudentId == id);
            _siteContext.Students.Remove(std);
        }

        public void update(Student student)
        {
            var std = _siteContext.Students.FirstOrDefault(st => st.StudentId == student.StudentId);
            std.StudentName = student.StudentName;
        }

    }
}