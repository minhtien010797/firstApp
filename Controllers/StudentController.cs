using System.Collections.Generic;
using firstApp.Core;
using Microsoft.AspNetCore.Mvc;
using firstApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;
using firstApp.Controllers.Resource;
using System.Linq;
using firstApp.services;

namespace firstApp.Controllers
{
    [ApiController]
    [Route("/api/students/")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        //GET Method
        [HttpGet]
        public List<StudentResource> GetAllStudents()
        {
            var stdList = _studentService.getAll();
            return stdList;
        }

        [HttpGet("{id}")]
        public ActionResult<StudentResource> GetStudentById(int id)
        {
            var std = _studentService.getById(id);
            if(std == null)
            {
                return NotFound();
            }
            return std;
        }

        //POST Method
        [HttpPost]
        public ActionResult Post(StudentResource student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Data Invalid.");
            _studentService.add(student);
            // // context.Students.Add(new Student()
            // // {
            // //     StudentName = student.StudentName
            // // });
            // // await context.SaveChangesAsync();
            return Ok();
        }

        //PUT Method
        [HttpPut("{id}")]
        public ActionResult<StudentResource> Put(StudentResource student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _studentService.update(student);
            // var std = await context.Students.Where(st => st.StudentId == student.StudentId)
            //                         .FirstOrDefaultAsync();

            // if (std != null)
            // {
            //     std.StudentName = student.StudentName;

            //     context.SaveChanges();
            // }
            // else
            // {
            //     return NotFound();
            // }
            return Ok();
        }

        //DELETE Method
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // if (std.StudentId == 0)
            //     return NotFound();
            _studentService.delete(id);
            return Ok();
        }



        // Way 1: Eager Loading
        // [HttpGet("students")]
        // public async Task<IEnumerable<ClassStudentResource>> GetStudents()
        // {
        //     // var studentList = await context.Classes.Include(c => c.Class)
        //     //                                             .Include(s => s.Student)
        //     //                                             .Select(ct => new ClassStudentResource
        //     //                                             {
        //     //                                                 ClassId = ct.ClassId,
        //     //                                                 StudentId = ct.StudentId,
        //     //                                                 StudentName = ct.Student.StudentName,
        //     //                                                 ClassName = ct.Class.ClassName,
        //     //                                             }).ToListAsync();
        //     // return studentList;

        //     // create("11A","Huynh Nhu");
        //     // update(7,"Nguyen Van Be");
        //     // delete(7);

        //     var studentList = await (from cls in context.Classes
        //                              join ct in context.ClassStudents on cls.ClassId equals ct.ClassId
        //                              join st in context.Students on ct.StudentId equals st.StudentId
        //                              select new ClassStudentResource
        //                              {
        //                                  ClassId = ct.ClassId,
        //                                  StudentId = ct.StudentId,
        //                                  StudentName = ct.Student.StudentName,
        //                                  ClassName = ct.Class.ClassName,
        //                              }).ToListAsync();
        //     //-----------------------------------------------------------------------------------------------------------------
        //     var studList = await context.Students.ToListAsync();
        //     //Quantifier Opers: All, Any, Contain
        //     // Aggregation Opers: Aggregate, Average, Count, Max, Min, Sum
        //     // Element Opers: ElementAt, ElementAtDefault, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault
        //     // Equality Oper: SequenceEqual
        //     // Concatenation Oper: concat()
        //     // Generation Oper: DefaultIfEmpty, Empty, Range, Repeat
        //     // Set Opers: Distinct, Except, Intersect, Union
        //     // Partitioning Opers: Skip, SkipWhile, Take, TakeWhile
        //     // Conversion Opers:

        //     var stdEleAt = studList.ElementAtOrDefault(7); // Out of range: INT: 0 || STRING: NULL
        //     var stdFirst = studList.FirstOrDefault(std => std.StudentName.Contains("Nguyen Van Cu"));
        //     var stdLast = studList.LastOrDefault();
        //     var stdConcat = studList.Concat(studList);

        //     // Aggregate
        //     var studentInList = studentList.Aggregate<ClassStudentResource, string>("Student Names:", 
        //                                                                             (std,s)=> std = std + s.StudentName + ",");
        //     //Count
        //     var countStudent = studList.Count();                                                                  

        //     //inner join way
        //     var stdList = await context.ClassStudents.Join(context.Students,
        //                                             ct => ct.StudentId,
        //                                             std => std.StudentId,
        //                                             (ct, std) => new { ct, std })
        //                                         .Join(context.Classes,
        //                                             css => css.ct.ClassId,
        //                                             c => c.ClassId,
        //                                             (css, c) => new
        //                                             {
        //                                                 ClassId = c.ClassId,
        //                                                 studentId = css.std.StudentId,
        //                                                 StudentName = css.std.StudentName,
        //                                                 ClassName = c.ClassName
        //                                             }).ToListAsync();

        //     //left join way
        //     var leftJoin = await (from s in context.Students
        //                    join ct in context.ClassStudents on s.StudentId equals ct.StudentId into tempStudent
        //                    from sct in tempStudent.DefaultIfEmpty()
        //                    select new {
        //                         ClassId = sct.ClassId,
        //                         studentName = s.StudentName,
        //                    }).ToListAsync();

        //     //right join way
        //     var rightJoin = await (from ct in context.ClassStudents
        //                    join s in context.Students on ct.StudentId equals s.StudentId into tempStudent
        //                    from sct in tempStudent.DefaultIfEmpty()
        //                    select new {
        //                         ct.ClassId,
        //                         studentName = sct.StudentName??string.Empty,
        //                    }).ToListAsync();

        //     // full-Outer-join way
        //     var fullOuterJoin = leftJoin.Union(rightJoin);
        //     return null;
        // }


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
        // private void create(string className, string studentName)
        // {
        //     var classEntity = new firstApp.Entities.Class()
        //     {
        //         ClassName = className
        //     };
        //     var student = new Student()
        //     {
        //         StudentName = studentName
        //     };

        //     student.ClassStudents = new List<ClassStudent>
        //     {
        //         new ClassStudent{
        //             Class = classEntity,
        //             Student = student
        //         }
        //     };

        //     context.Students.Add(student);
        //     context.SaveChanges();
        // }

        //UPDATE:  EF Many-to-Many
        // private void update(int studentId, string newName)
        // {
        //     // var student =   (from st in context.Students 
        //     //                 where st.StudentId == studentId
        //     //                 select st).FirstOrDefault();
        //     // ANOTHER WAY WRITE LINQ
        //     var student = context.Students.FirstOrDefault(s => s.StudentId == studentId);
        //     student.StudentName = newName;
        //     context.SaveChanges();
        // }

        //DELETE: EF Many-to-Many
        // private void delete(int studentId)
        // {
        //     // var student =  (from st in context.Students 
        //     //                 where st.StudentId == studentId
        //     //                 select st).FirstOrDefault();
        //     // ANOTHER WAY WRITE LINQ
        //     var student = context.Students.FirstOrDefault(s => s.StudentId == studentId);
        //     context.Students.Remove(student);
        //     context.SaveChanges();
        // }
    }
}