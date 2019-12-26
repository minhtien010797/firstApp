using System.Collections.Generic;
using System.Linq;
using firstApp.Controllers.Resource;
using firstApp.Entities;
using firstApp.Manager;
using Microsoft.EntityFrameworkCore;

namespace firstApp.Services
{
    public class StudentClassService : IStudentClassService
    {
        private readonly IStudentClassManager _studentClassManager;
        public StudentClassService(IStudentClassManager studentClassManager)
        {
            _studentClassManager = studentClassManager;
        }
        public List<StudentResource> getAll()
        {
            var studentList = _studentClassManager.get()
            .Include(ct => ct.ClassStudents)
            .ThenInclude(c => c.Class)
            .Select(sr => new StudentResource
            {
                StudentId = sr.StudentId,
                StudentName = sr.StudentName,
                Classes = sr.ClassStudents.Select(x => new ClassResource
                {
                    ClassId = x.Class.ClassId,
                    ClassName = x.Class.ClassName
                }).ToList()
            }).ToList();

            return studentList;
        }

        public StudentResource getById(int id)
        {
            var student = _studentClassManager.get()
            .Include(ct => ct.ClassStudents)
            .ThenInclude(c => c.Class)
            .FirstOrDefault(ct => ct.StudentId == id);

            if (student != null)
            {

                return new StudentResource
                {
                    StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    Classes = student.ClassStudents.Select(x => new ClassResource
                    {
                        ClassId = x.Class.ClassId,
                        ClassName = x.Class.ClassName
                    }).ToList()
                };
            }
            return null;
        }

        public bool add(StudentResource student, int classId)
        {
            _studentClassManager.add(new Student
            {
                StudentName = student.StudentName
            }, classId);
            _studentClassManager.SaveChange();
            return true;
        }

        public bool update(StudentResource student)
        {
            _studentClassManager.update(new Student
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName
            });
            _studentClassManager.SaveChange();
            return true;
        }

        public bool delete(int id)
        {
            _studentClassManager.delete(id);
            _studentClassManager.SaveChange();
            return true;
        }
    }
}