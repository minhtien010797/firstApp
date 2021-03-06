using System.Linq;
using firstApp.Entities;

namespace firstApp.Manager
{
    public interface IStudentClassManager
    {
        IQueryable<Student> get();
        void add(Student student, int classId);
        void update(Student student);
        void delete(int id);
        void SaveChange();
    }
}