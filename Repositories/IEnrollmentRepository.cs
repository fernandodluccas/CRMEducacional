using CRMEducacional.Models;

namespace CRMEducacional.Repositories
{
    public interface IEnrollmentRepository
    {
        void Create(Enrollment enrollment);
        void Delete(int id);
        Task<IEnumerable<Enrollment>> GetAllEnrollments();
        Task<Enrollment> GetEnrollmentById(int id);
        Task<Enrollment> Update(Enrollment enrollment, int id);
    }
}