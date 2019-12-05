using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace firstApp.Entities
{
    public class Student
    {
        [Required]
        public int StudentId{get;set;}
        [Required]
        [StringLength(255)]
        public string StudentName{get;set;}

        public virtual ICollection<ClassStudent> ClassStudents{get;set;}

        public Student()
        {
            ClassStudents = new Collection<ClassStudent>();
        }
    }
}