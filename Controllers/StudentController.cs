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

            // create("11A","Huynh Nhu");
            // update(7,"Nguyen Van Be");
            // delete(7);

            var studentList = await (from cls in context.Classes
                                     join ct in context.ClassStudents on cls.ClassId equals ct.ClassId
                                     join st in context.Students on ct.StudentId equals st.StudentId
                                     select new ClassStudentResource
                                     {
                                         ClassId = ct.ClassId,
                                         StudentId = ct.StudentId,
                                         StudentName = ct.Student.StudentName,
                                         ClassName = ct.Class.ClassName,
                                     }).ToListAsync();
            //inner join way
            var stdList = await context.ClassStudents.Join(context.Students,
                                                    ct => ct.StudentId,
                                                    std => std.StudentId,
                                                    (ct, std) => new { ct, std })
                                                .Join(context.Classes,
                                                    css => css.ct.ClassId,
                                                    c => c.ClassId,
                                                    (css, c) => new
                                                    {
                                                        ClassId = c.ClassId,
                                                        studentId = css.std.StudentId,
                                                        StudentName = css.std.StudentName,
                                                        ClassName = c.ClassName
                                                    }).ToListAsync();

            //left join way
            var leftJoin = await (from s in context.Students
                           join ct in context.ClassStudents on s.StudentId equals ct.StudentId into tempStudent
                           from sct in tempStudent.DefaultIfEmpty()
                           select new {
                                ClassId = sct.ClassId,
                                studentName = s.StudentName,
                           }).ToListAsync();

            //right join way
            var rightJoin = await (from ct in context.ClassStudents
                           join s in context.Students on ct.StudentId equals s.StudentId into tempStudent
                           from sct in tempStudent.DefaultIfEmpty()
                           select new {
                                ct.ClassId,
                                studentName = sct.StudentName??string.Empty,
                           }).ToListAsync();

            // full-Outer-join way
            var fullOuterJoin = leftJoin.Union(rightJoin);
            return null;
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


        // INSERT: EF Many-to-Many
        private void create(string className, string studentName)
        {
            var classEntity = new firstApp.Entities.Class()
            {
                ClassName = className
            };
            var student = new Student()
            {
                StudentName = studentName
            };

            student.ClassStudents = new List<ClassStudent>
            {
                new ClassStudent{
                    Class = classEntity,
                    Student = student
                }
            };

            // var studentClass = new ClassStudent()
            // {
            //     ClassName = classEntity.ClassName;
            //     StudentId = student.StudentId,
            //     ClassId = classEntity.ClassId
            // };

            context.Students.Add(student);
            context.SaveChanges();
        }

        //UPDATE:  EF Many-to-Many
        private void update(int studentId, string newName)
        {
            // var student =   (from st in context.Students 
            //                 where st.StudentId == studentId
            //                 select st).FirstOrDefault();
            // ANOTHER WAY WRITE LINQ
            var student = context.Students.Where(s => s.StudentId == studentId).FirstOrDefault();
            student.StudentName = newName;
            context.SaveChanges();
        }

        //DELETE: EF Many-to-Many
        private void delete(int studentId)
        {
            // var student =  (from st in context.Students 
            //                 where st.StudentId == studentId
            //                 select st).FirstOrDefault();
            // ANOTHER WAY WRITE LINQ
            var student = context.Students.Where(s => s.StudentId == studentId).FirstOrDefault();
            context.Students.Remove(student);
            context.SaveChanges();
        }
    }

}