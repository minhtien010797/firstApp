using System.Collections.Generic;
using firstApp.Controllers.Resource;
using firstApp.Manager;
using firstApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace firstApp.Controllers
{
    [ApiController]
    [Route("/api/studentClass/")]
    public class StudentClassController : ControllerBase
    {
        private readonly IStudentClassService _studentClassService;
        public StudentClassController(IStudentClassService studentClassService)
        {
            _studentClassService = studentClassService;
        }

        //GET Method
        [HttpGet]
        public List<StudentResource> GetAllStudents()
        {
            var stdList = _studentClassService.getAll();
            return stdList;
        }

        [HttpGet("{id}")]
        public ActionResult<StudentResource> GetStudentById(int id)
        {
            var std = _studentClassService.getById(id);
            if (std == null)
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
            _studentClassService.add(student);
            // // context.Students.Add(new Student()
            // // {
            // //     StudentName = student.StudentName
            // // });
            // // await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<StudentResource> Put(StudentResource student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _studentClassService.update(student);
            return Ok();
        }

        //DELETE Method
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _studentClassService.delete(id);
            return Ok();
        }
    }
}