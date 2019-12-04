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
        // private readonly IMapper mapper;
        public StudentController(SiteContext context)
        {
            // this.mapper = mapper;
            this.context = context;

        }

        [HttpGet("/api/students")]
        public async Task<IEnumerable<ClassStudentResource>> GetStudents()
        {
            // var student = await context.Students.Include(m => m.ClassStudents).Select(x=> new StudentModel{
            //     StudentId = x.StudentId,
            //     StudentName = x.StudentName,
            //     ClassId = x.ClassStudents,
            //     StudentId = x.StudentId,
            // } ).ToListAsync();            

            // var studentList = await (from s in context.ClassStudent
            //                                       .Where(s => s.ClassId == Class.ClassId)
            //                                       .Include(m => m.)
            //                      let studentCLass = s.ClassStudents.FirstOrDefault(c => c.StudentId == s.StudentId)
            //                      select new StudentResource
            //                      {
            //                          StudentId = s.StudentId,
            //                          StudentName = s.StudentName,
            //                          ClassId = ClassStudentResource.Class.ClassId,
            //                          ClassName = ClassStudentResource.Class.ClassName,
            //                      }).ToListAsync();
            // return studentList;

            // var studentList = await (from cs in context.ClassStudent.Include(s => s.Student)
            //                                                 .Include(c => c.Class)
            //                                                 .FirstOrDefault()));

            var studentList = await context.ClassStudent.Include(cs => cs.Class)
                                                    .Include(cs => cs.Student)
                                                    .Select(cs => new ClassStudentResource
                                                    {
                                                        StudentId = cs.StudentId,
                                                        ClassId = cs.ClassId,
                                                        StudentName = new StudentResource{cs.Student.StudentName},
                                                        ClassName = new ClassResource{cs.Class.ClassName} 
                                                    }).ToListAsync();
            // {
            //     StudentId =cs.StudentId,
            //     StudentName = cs.Student.StudentName
            // }).ToListAsync();
            return studentList;
            // return mapper.Map<List<Student>, List<StudentResource>>(student);
        }
    }
}