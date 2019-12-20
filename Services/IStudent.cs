using System.Linq;
using firstApp.Controllers.Resource;
using firstApp.Entities;

namespace firstApp.services
{
    public interface IStudentService
    {
         IQueryable<StudentResource> getAll();
         IQueryable<StudentResource> getSingle(int id);
        //  Task<ActionResult<StudentResource>> add(StudentResource student);
        //  IQueryable<StudentResource> update(StudentResource student);
        //  IQueryable<StudentResource> delete(int id);
    }
}