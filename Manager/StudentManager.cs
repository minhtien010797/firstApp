using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstApp.Controllers.Resource;
using firstApp.Core;
using firstApp.Entities;

namespace firstApp.manager
{
    public class StudentManager : IStudentManager
    {
        private readonly SiteContext _siteContext;
        public StudentManager(SiteContext siteContext)
        {
            _siteContext = siteContext;
        }

        public IQueryable<Student> get()
        {
            return _siteContext.Students;
        }

        public Student getById(int id)
        {
            return _siteContext.Students.FirstOrDefault(s => s.StudentId == id);
        }

        public void add(Student student)
        {
            _siteContext.Students.Add(new Student
            {
                StudentName = student.StudentName
            });
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

        public void SaveChange()
        {
            _siteContext.SaveChanges();
        }
    }
}