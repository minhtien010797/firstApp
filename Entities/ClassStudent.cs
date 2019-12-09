using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace firstApp.Entities
{
    public class ClassStudent
    {
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}