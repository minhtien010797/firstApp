using System.Collections.Generic;

namespace firstApp.Controllers.Resource
{
    public class StudentResource
    {
        public int StudentId{get;set;}
        public string StudentName{get;set;}

        public List<ClassStudentResource> ClassStudents{get;set;}
    }
}