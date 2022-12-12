using CRMEducacional.Models;

namespace CRMEducacional.Repositories
{
    public interface ILeadRepository
    {
        void Create(Lead lead);
        void Delete(int id);
        Task<IEnumerable<Lead>> GetAllLeads();
        Task<Lead> GetLeadById(int id);
        Task<Lead> Update(Lead lead, int id);
    }
}