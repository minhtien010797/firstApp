using System.Collections.Generic;

namespace firstApp.Controllers.Resource
{
    public class ClassResource
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public List<StudentResource> Students { get; set; }
    }
}