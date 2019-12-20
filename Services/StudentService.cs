using System.Linq;
using System.Threading.Tasks;
using firstApp.Controllers.Resource;
using firstApp.Core;
using firstApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstApp.services
{
    public class StudentClass : IStudentService
    {
        private readonly SiteContext _context;
        public StudentClass(SiteContext context)
        {
            _context = context;
        }
        public IQueryable<StudentResource> getAll()
        {
            return _context.Students.Select(s => new StudentResource
            {
                StudentId = s.StudentId,
                StudentName = s.StudentName
            });
        }
        public IQueryable<StudentResource> getSingle(int id)
        {
            return _context.Students.Where(s => s.StudentId == id).Select(st => new StudentResource
            {
                StudentId = st.StudentId,
                StudentName = st.StudentName
            });
        }

        // public async Task<ActionResult<StudentResource>> add(StudentResource student)
        // {
        //     _context.Students.Add(student);
        //     await _context.SaveChangesAsync();
        //     return CreatedAtAction(nameof(getAll), new { id = student.StudentId }, student);
        // }

        // public IQueryable<StudentResource> update(StudentResource student)
        // {
        //     throw new System.NotImplementedException();
        // }

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
    }
}