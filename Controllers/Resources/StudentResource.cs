using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace firstApp.Controllers.Resource
{
    public class StudentResource
    {
        public int StudentId{get;set;}
        public string StudentName{get;set;}
        public ICollection<ClassStudentResource> ClassStudents{get;set;}

         public StudentResource()
        {
            ClassStudents = new Collection<ClassStudentResource>();
        }
    }
}