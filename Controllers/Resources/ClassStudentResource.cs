namespace firstApp.Controllers.Resource
{
    public class ClassStudentResource
    {
         public int ClassStudentId{get;set;}
        public int ClassId{get;set;}
        public ClassResource Class{get;set;}
        public int StudentId{get;set;}
        public StudentResource Student{get;set;}
    }
}