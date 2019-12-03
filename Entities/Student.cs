using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace firstApp.Entities
{
    public class Student
    {
        [Required]
        public int StudentId{get;set;}
        [Required]
        public string StudentName{get;set;}

        public virtual ICollection<ClassStudent> ClassStudents{get;set;}
    }
}