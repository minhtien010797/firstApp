using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstApp.Controllers.Resource;
using firstApp.Core;
using firstApp.Entities;
using firstApp.manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstApp.services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentManager _studentManager;
        public StudentService(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        public List<StudentResource> getAll()
        {
            return _studentManager.get().Select(s => new StudentResource
            {
                StudentId = s.StudentId,
                StudentName = s.StudentName
            }).ToList();
        }
        public StudentResource getById(int id)
        {
            var x = _studentManager.getById(id);
            return new StudentResource
            {
                StudentId = x.StudentId,
                StudentName = x.StudentName
            };
        }

        public bool add(StudentResource student)
        {
            _studentManager.add(new Student
            {
                StudentName = student.StudentName
            });
            _studentManager.SaveChange();
            return true;
        }

        // public async Task<ActionResult<StudentResource>> add(StudentResource student)
        // {
        //     _context.Students.Add(student);
        //     await _context.SaveChangesAsync();
        //     return CreatedAtAction(nameof(getAll), new { id = student.StudentId }, student);
        // }

        public bool update(StudentResource student)
        {
            _studentManager.update(new Student{
                StudentId = student.StudentId,
                StudentName = student.StudentName
            });
            _studentManager.SaveChange();
            return true;
        }

        // public IQueryable<StudentResource> delete(int id)
        // {
        //     if (id <= 0)
        //         return BadRequest("Not a valid student id");
        //     var std = _context.Students.Where(st => st.StudentId == id).FirstOrDefault();

        //     if (std.StudentId == 0)
        //         return NotFound();

        //     _context.Students.Remove(std);
        //     _context.SaveChanges();

        //     return Ok();
        // }

        public bool delete(int id)
        {
            _studentManager.delete(id);
            _studentManager.SaveChange();
            return true;
        }
    }
}