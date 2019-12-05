using System.Collections.Generic;
using firstApp.Core;
using Microsoft.AspNetCore.Mvc;
using firstApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;
using firstApp.Controllers.Resource;
using System.Linq;

namespace firstApp.Controllers
{
    public class StudentController : ControllerBase
    {
        private readonly SiteContext context;
        public StudentController(SiteContext context)
        {
            this.context = context;

        }

        [HttpGet("/api/students")]
        public async Task<IEnumerable<ClassStudentResource>> GetStudents()
        {
            var studentList = await context.ClassStudent.Include(c => c.Class)
                                                        .Include(s => s.Student)
                                                        .Select(ct => new ClassStudentResource
                                                        {
                                                            ClassId = ct.ClassId,
                                                            StudentId = ct.StudentId,
                                                            StudentName = ct.Student.StudentName,
                                                            ClassName = ct.Class.ClassName,
                                                        }).ToListAsync();
            return studentList;
        }

        [HttpPost("/createStudent")]
        public async Task<IActionResult> createStudent()
        {     
            
        }               
    }
}