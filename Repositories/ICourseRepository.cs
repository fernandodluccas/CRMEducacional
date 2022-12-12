using CRMEducacional.Models;

namespace CRMEducacional.Repositories
{
    public interface ICourseRepository
    {
        void Create(Course course);
        void Delete(int id);
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);
        Task<Course> Update(Course course, int id);
    }
}