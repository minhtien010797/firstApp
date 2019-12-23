using System.Collections.Generic;
using System.Linq;
using firstApp.Controllers.Resource;
using firstApp.Core;
using firstApp.Entities;

namespace firstApp.manager
{
    public interface IStudentManager
    {
       IQueryable<Student> get();
       Student getById(int id);
       void add(Student student);
       void update(Student student);
       void delete(int id);
       void SaveChange();
    }
}