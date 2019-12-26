using System.Collections.Generic;
using firstApp.Controllers.Resource;

namespace firstApp.Services
{
    public interface IStudentClassService
    {
        List<StudentResource> getAll();
        StudentResource getById(int id);
        bool add(StudentResource student, int classId);
        bool update(StudentResource student);
        bool delete(int id);
    }
}