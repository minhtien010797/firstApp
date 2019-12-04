using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace firstApp.Entities
{
    public class Class
    {
        [Required]
        public int ClassId{get;set;}
        [Required]
        [StringLength(255)]
        public string ClassName{get;set;}

        public virtual ICollection<ClassStudent> ClassStudents{get;set;}
    }
}