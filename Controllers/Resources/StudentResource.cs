using System.Collections.Generic;
using System.Collections.ObjectModel;
using firstApp.Entities;

namespace firstApp.Controllers.Resource
{
    public class StudentResource
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        // public StudentResource(Student student)
        // {
        //     StudentId = student.StudentId;
        //     StudentName = student.StudentName;
        // }
        // public List<ClassResource> Classes { get; set; }
    }
}