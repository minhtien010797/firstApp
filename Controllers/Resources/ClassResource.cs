using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace firstApp.Controllers.Resource
{
    public class ClassResource
    {
        public int ClassId{get;set;}
        public string ClassName{get;set;}
        public List<ClassStudentResource> ClassStudents{get;set;}
    }
}