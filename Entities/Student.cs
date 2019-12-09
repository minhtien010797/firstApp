using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace firstApp.Entities
{
    public class Student
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [Required]
        public string StudentName{get;set;}

        public virtual ICollection<ClassStudent> ClassStudents{get;set;}

    }
}