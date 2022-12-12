using CRMEducacional.Data;
using CRMEducacional.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMEducacional.Repositories
{


    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _dataContext;
        public CourseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Create(Course course)
        {
            _dataContext.Courses.Add(course);
            _dataContext.SaveChanges();
        }
        public async void Delete(int id)
        {
            Course course = await _dataContext.Courses.FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
                throw new Exception("Curso não encontrado");

            _dataContext.Courses.Remove(course);
            _dataContext.SaveChanges();
        }
        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            var courses = await _dataContext.Courses.AsNoTracking().ToListAsync();
            if (courses == null)
                throw new Exception("Nenhum curso encontrado");
            return courses;
        }
        public async Task<Course> GetCourseById(int id)
        {
            Course course = await _dataContext.Courses.FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
                throw new Exception("Lead não encontrado");

            return course;
        }
        public async Task<Course> Update(Course course, int id)
        {
            var courseToUpdate = await _dataContext.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (courseToUpdate == null)
                throw new Exception("Curso não encontrado");

            courseToUpdate.Name = course.Name;
            courseToUpdate.Description = course.Description;
            courseToUpdate.CreatedAt = course.CreatedAt;
            courseToUpdate.UpdatedAt = DateTime.Now;

            _dataContext.Courses.Update(courseToUpdate);
            _dataContext.SaveChanges();

            return courseToUpdate;
        }
    }
}