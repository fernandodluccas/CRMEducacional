using CRMEducacional.Data;
using CRMEducacional.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMEducacional.Repositories
{


    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly DataContext _dataContext;
        public EnrollmentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Create(Enrollment enrollment)
        {
            Lead lead = _dataContext.Leads.FirstOrDefault(l => l.Id == enrollment.LeadId);
            if (lead == null)
                throw new Exception("Lead não encontrada");

            Course course = _dataContext.Courses.FirstOrDefault(c => c.Id == enrollment.CourseId);

            if (course == null)
                throw new Exception("Curso não encontrado");

            _dataContext.Enrollments.Add(enrollment);
            _dataContext.SaveChanges();
        }
        public async void Delete(int id)
        {
            Enrollment enrollment = await _dataContext.Enrollments.FirstOrDefaultAsync(e => e.Id == id);

            if (enrollment == null)
                throw new Exception("Matrícula não encontrada");

            _dataContext.Enrollments.Remove(enrollment);
            _dataContext.SaveChanges();
        }
        public async Task<IEnumerable<Enrollment>> GetAllEnrollments()
        {
            var enrollments = await _dataContext.Enrollments.AsNoTracking().ToListAsync();

            if (enrollments == null)
                throw new Exception("Nenhuma matrícula encontrada");

            return enrollments;
        }
        public async Task<Enrollment> GetEnrollmentById(int id)
        {
            Enrollment enrollment = await _dataContext.Enrollments.FirstOrDefaultAsync(e => e.Id == id);

            if (enrollment == null)
                throw new Exception("Matrícula não encontrada");

            return enrollment;
        }
        public async Task<Enrollment> Update(Enrollment enrollment, int id)
        {
            Lead lead = _dataContext.Leads.FirstOrDefault(l => l.Id == enrollment.LeadId);
            if (lead == null)
                throw new Exception("Lead não encontrada");

            Course course = _dataContext.Courses.FirstOrDefault(c => c.Id == enrollment.CourseId);
            if (course == null)
                throw new Exception("Curso não encontrado");

            Enrollment enrollmentToUpdate = await _dataContext.Enrollments.FirstOrDefaultAsync(e => e.Id == id);
            if (enrollmentToUpdate == null)
                throw new Exception("Matrícula não encontrada");

            enrollmentToUpdate.CourseId = enrollment.CourseId;
            enrollmentToUpdate.LeadId = enrollment.LeadId;
            enrollmentToUpdate.CreatedAt = enrollment.CreatedAt;
            enrollmentToUpdate.UpdatedAt = DateTime.Now;

            _dataContext.Enrollments.Update(enrollmentToUpdate);
            _dataContext.SaveChanges();

            return enrollmentToUpdate;
        }
    }
}