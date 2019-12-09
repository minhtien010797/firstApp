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
    [Route("/api/")]
    public class StudentController : ControllerBase
    {
        private readonly SiteContext context;
        public StudentController(SiteContext context)
        {
            this.context = context;

        }


        // Way 1: Eager Loading
        [HttpGet("/api/students")]
        public async Task<IEnumerable<ClassStudentResource>> GetStudents()
        {
            // var studentList = await context.Classes.Include(c => c.Class)
            //                                             .Include(s => s.Student)
            //                                             .Select(ct => new ClassStudentResource
            //                                             {
            //                                                 ClassId = ct.ClassId,
            //                                                 StudentId = ct.StudentId,
            //                                                 StudentName = ct.Student.StudentName,
            //                                                 ClassName = ct.Class.ClassName,
            //                                             }).ToListAsync();
            // return studentList;

            // create();
            var studentList = await (from cls in context.Set<Class>()
                            join ct in context.Set<ClassStudent>() on cls.ClassId equals ct.ClassId
                            join st in context.Set<Student>() on ct.StudentId equals st.StudentId
                            select new ClassStudentResource{ClassId = ct.ClassId,
                                                            StudentId = ct.StudentId,
                                                            StudentName = ct.Student.StudentName,
                                                            ClassName = ct.Class.ClassName,}).ToListAsync();

            return studentList;
        }

        // Way 2: Lazy Loading
        // [HttpGet("students")]
        // public async Task<IEnumerable<ClassStudentResource>> GetStudents()
        // {
        //     // create();
        //     var studentList = await context.ClassStudents.Select(ct => new ClassStudentResource
        //     {
        //         ClassId = ct.ClassId,
        //         StudentId = ct.StudentId,
        //         StudentName = ct.Student.StudentName,
        //         ClassName = ct.Class.ClassName,
        //     }).ToListAsync();

        //     return null;
        // }

        // [HttpPost("[action]")]
        // public async Task<IActionResult> createStudent([FromBody]ClassStudentResource ct)
        // {
        // var student = new Student()
        // {
        //     StudentName = "Tien"
        // };

        // var classEntity = new firstApp.Entities.Class()
        // {
        //     ClassName = "10A"
        // };

        // var studentClass = new ClassStudent()
        // {
        //     StudentId = student.StudentId,
        //     ClassId = classEntity.ClassId
        // };

        // context.SaveChanges();

        //     return Ok(true);
        // }

        private void create()
        {
            var classEntity = new firstApp.Entities.Class()
            {
                ClassName = "10A"
            };
            var student = new Student()
            {
                StudentName = "Tien"
            };

            // var studentClass = new ClassStudent()
            // {
            //     ClassName = classEntity.ClassName;
            //     StudentId = student.StudentId,
            //     ClassId = classEntity.ClassId
            // };

            context.SaveChanges();
        }
    }

}