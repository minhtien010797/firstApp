using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace firstApp.Entities
{
    public class Class
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId{get;set;}
        [Required]
        [StringLength(255)]
        public string ClassName{get;set;}

        public virtual ICollection<ClassStudent> ClassStudents{get;set;}

        public Class()
        {
            ClassStudents = new Collection<ClassStudent>();
        }
    }
}