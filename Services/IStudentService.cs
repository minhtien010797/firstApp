using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstApp.Controllers.Resource;
using firstApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace firstApp.services
{
    public interface IStudentService
    {
         List<StudentResource> getAll();
         StudentResource getById(int id);
         bool add(StudentResource student);
         bool update(StudentResource student);
         bool delete(int id);
    }
}